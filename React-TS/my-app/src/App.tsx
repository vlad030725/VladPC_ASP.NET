import { BrowserRouter, Route, Routes, Link } from 'react-router-dom';
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
