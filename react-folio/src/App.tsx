import React from 'react';
import {BrowserRouter as Router, Routes, Route} from "react-router-dom";
import {AllCoins} from './AllCoins';
import { Navbar } from './Navbar';
import logo from './logo.svg';
import './App.css';

function App() {
  return (
    <Router>
      <Navbar/>
      <Routes>
        <Route path='/' element={<AllCoins/>}></Route>
      </Routes>
    </Router>
  );
}

export default App;
