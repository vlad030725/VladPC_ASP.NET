import { BrowserRouter, Route, Routes, Link } from 'react-router-dom';
import { useEffect, useState } from 'react';
import React from 'react';
import './App.css';
import Companies from './Components/Companies/Companies';
import TypesProduct from './Components/TypesProduct/TypesProduct';
import Products from './Components/Products/Products';
import Catalog from './Components/Products/Catalog';
import Layout from './Components/Layout/Layout';
import UserObj from './Components/Entities/UserObj';
import Register from './Components/Account/Register';
import Login from './Components/Account/Login';
import Logoff from './Components/Account/Logoff';

interface ResponseModel {
  message: string;
  responseUser: UserObj;
}

function App() {

  const [user, setUser] = useState<UserObj | null>(null);

  useEffect(() => {
    const getUser = async () => {
      const requestOptions = {
        method: "GET",
        headers: {
          "Access-Control-Allow-Credentials": "true"
        },
      };

      return await fetch("api/account/isauthenticated", requestOptions)
        .then((response) => {
          return response.json();
        })
        .then(
          (data: ResponseModel) => {
            setUser(data.responseUser);
          },
          (error) => console.log(error)
        );
    };
    getUser();
  }, []);

  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<Layout user={user}/>}>
          {/* <Route index element={<h3>Магазин компьютерной техники "VladPC"</h3>}/> */}
          <Route path='/companies' element={<Companies/>}/>
          <Route path='/typesProduct' element={<TypesProduct/>}/>
          <Route path='/products' element={<Products/>}/>
          <Route path='/catalog' element={<Catalog/>}/>
          <Route path='/register' element={<Register/>}/>
          <Route path='/login' element={<Login setUser={setUser}/>}/>
          <Route path='/logoff' element={<Logoff setUser={setUser}/>}/>
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
