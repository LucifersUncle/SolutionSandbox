import { render } from "@testing-library/react";
import { useContext, useState } from "react";
import { NavLink, useNavigate, Link } from "react-router-dom";
import CSS from 'csstype';

export function Navbar() {
    const navStyle:CSS.Properties = {
        display: 'flex',
        flexDirection: "row",
        justifyContent: "space-evenly",
    };
    return (    
        <nav className="navbar navbar-expand-md navbar-dark fixed-top bg-dark">
            <div className="container-fluid">
                <Link to="/" className="navbar-brand"> Crypto Asset Portfolio Manager</Link>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarCollapse" aria-controls="navbarCollapse" aria-expanded="false" aria-label="Toggle navigation">
                <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarCollapse">
                <ul className="navbar-nav me-auto mb-2 mb-md-0">
                    <li className="nav-item">
                    <a className="nav-link" href="/allcoins">All Coins</a>
                    </li>
                    <li className="nav-item">
                    <a className="nav-link" href="/login">Login</a>
                    </li>
                    {/* <li className="nav-item">
                    <a className="nav-link" href="/register">Register</a>
                    </li> */}
                </ul>
                <form className="d-flex">
                    <input className="form-control me-2" type="search" placeholder="Search" aria-label="Search"/>
                    <button className="btn btn-outline-success" type="submit">Search</button>
                </form>
                </div>
            </div>
        </nav>
    );
}
