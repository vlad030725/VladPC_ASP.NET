import { BrowserRouter, Route, Routes, Link } from 'react-router-dom';
import { useEffect, useState } from 'react';
import React from 'react';
import './App.css';
import Companies from './Components/Companies/Companies';
import TypesProduct from './Components/TypesProduct/TypesProduct';
import Layout from './Components/Layout/Layout';
import UserObj from './Components/Entities/UserObj';
import Register from './Components/Account/Register';

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
          <Route index element={<h3>Магазин компьютерной техники "VladPC"</h3>}/>
          <Route path='/companies' element={<Companies/>}/>
          <Route path='/typesProduct' element={<TypesProduct/>}/>
          <Route path='/register' element={<Register/>}/>
        </Route>
      </Routes>
      <NavigateButton/>
    </BrowserRouter>
  );
}

const NavigateButton: React.FC = () => {
  return (
    <Link to="/companies">
      <button>
        Companies
      </button>
    </Link>
  );
};

export default App;
