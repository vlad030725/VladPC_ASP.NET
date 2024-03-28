import { BrowserRouter, Route, Routes } from 'react-router-dom';
import React from 'react';
import './App.css';
import Companies from './Components/Companies/Companies';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route index element={<h3>Магазин компьютерной техники "VladPC"</h3>}/>
        <Route path='/companies' element={<Companies/>}/>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
