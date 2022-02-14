import { render } from "@testing-library/react";
import { useContext, useState } from "react";
import { NavLink, useNavigate } from "react-router-dom";
import CSS from 'csstype';

export function Navbar() {
    const navStyle:CSS.Properties = {
        display: 'flex',
        flexDirection: "row",
        justifyContent: "space-evenly",
    };
    return (
        
        <nav style={navStyle}>   
            {
                <a>
                    <NavLink to="/" >
                        All coins
                    </NavLink>
                </a>
            }
        </nav>
    );
}
