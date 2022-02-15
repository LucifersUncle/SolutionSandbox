import {SyntheticEvent, useState} from 'react';
import '../Styles/signin.css';
import { Navigate } from 'react-router-dom';

export function Login() {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [navigate, setNavigate] = useState(false);

    const submit = async (e: SyntheticEvent) => {
        e.preventDefault();

        await fetch('https://localhost:44323/api/Login', {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            credentials: 'include',
            body: JSON.stringify({
                username,
                password
            })
        });

    }

    return (
        <body className="text-center">
    
            <main className="form-signin">
            <form>
                {/* <img className="mb-4" src="/docs/5.1/assets/brand/bootstrap-logo.svg" alt="" width="72" height="57"> */}
                <h1 className="h3 mb-3 fw-normal">Sign in</h1>
            
                <div className="form-floating">
                <input type="email" className="form-control" placeholder="name@example.com"/>
                <label htmlFor="floatingInput">Username</label>
                </div>
                <div className="form-floating">
                <input type="password" className="form-control"placeholder="Password"/>
                <label htmlFor="floatingPassword">Password</label>
                </div>
            
                <div className="checkbox mb-3">
                {/* <label>
                    <input type="checkbox" value="remember-me"> Remember me</input>
                </label> */}
                </div>
                <button className="w-100 btn btn-lg btn-primary" type="submit">Sign in</button>
                {/* <p className="mt-5 mb-3 text-muted">&copy; 2017–2021</p> */}
            </form>
            </main>   
        </body>
    );
};

export default Login;