import { BrowserRouter, Route, Routes, Link } from 'react-router-dom';
import { useEffect, useState } from 'react';
import React from 'react';
import './App.css';
import Companies from './Components/Companies/Companies';
import TypesProduct from './Components/TypesProduct/TypesProduct';
import Products from './Components/Products/Products';
import Catalog from './Components/Products/Catalog';
import Profile from './Components/Profile/Profile';
import Layout from './Components/Layout/Layout';
import UserObj from './Components/Entities/UserObj';
import Register from './Components/Account/Register';
import Login from './Components/Account/Login';
import Logoff from './Components/Account/Logoff';
import axios from 'axios';

function App() {

  const [user, setUser] = useState<UserObj | null>(null);

  useEffect(() => {
    const getUser = async () => {

      try {
        const response = await axios.get("http://localhost:5075/api/account/isauthenticated", {
          withCredentials: true, // включить куки в запросы
        });
        setUser(response.data.user);
      } catch (error) {
        console.log(error);
      }
    };
    getUser();
  }, [user]);

  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<Layout user={user}/>}>
          <Route path='/companies' element={<Companies/>}/>
          <Route path='/typesProduct' element={<TypesProduct/>}/>
          <Route path='/products' element={<Products/>}/>
          <Route path='/catalog' element={<Catalog user={user}/>}/>
          <Route path='/profile' element={<Profile user={user}/>}/>
          <Route path='/register' element={<Register/>}/>
          <Route path='/login' element={<Login setUser={setUser}/>}/>
          <Route path='/logoff' element={<Logoff setUser={setUser}/>}/>
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
