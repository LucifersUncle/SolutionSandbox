import React from 'react';
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { AllCoins } from './Components/AllCoins';
import { Navbar } from './Components/Navbar';
import logo from './logo.svg';
import './App.css';
import Login from './Components/Login';

function App() {
    return (
        <Router>
            <Navbar />
            <Routes>
                <Route path='/allcoins' element={<AllCoins />}></Route>
                <Route path='/login' element={<Login />}></Route>

            </Routes>
        </Router>
    );
}

export default App;
