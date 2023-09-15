import React, { useState, useEffect } from 'react';
import { Link, useHistory } from 'react-router-dom';

import registerImage from '../images/register.jpg';
import { isEmpty, isEmail, isLength, isMatch } from './../utils/valid';
import { postDataAPI, signupAPI } from './../utils/fetchData';
import { showErrorMsg, showSuccessMsg } from '../components/Notification';

import "../styles/register.css"; 

const Register = () => {
    const state = {
        // username: '',
        email: '',
        password: '',
        cpassword: '',
        err: '',
        success: ''
    };

    const [userData, setUserData] = useState(state);
    const { username, email, password, cpassword, err, success } = userData;
    const history = useHistory();

    useEffect(() => {
        if(localStorage.getItem('firstLogin'))
            history.push('/');
    }, [history]);

    const handleChangeInput = e => {
        const { name, value } = e.target;
        setUserData({...userData, [name]: value, err: '', success: ''});
    }

    const handleSubmit = async (e) => {
        e.preventDefault();
        console.log("In handle")
        // if(isEmpty(username) || isEmpty(password))
        //         return setUserData({...userData, err: "Please fill in all fields.", success: ''});

        if(!isEmail(email))
            return setUserData({...userData, err: "Invalid emails.", success: ''});

        if(isLength(password))
            return setUserData({...userData, err: "Password must be at least 6 characters.", success: ''});
        
        if(!isMatch(password, cpassword))
            return setUserData({...userData, err: "Password did not match.", success: ''});
        console.log("Completed handles")

        try {
            // const res = await postDataAPI('register', userData);
            const userDataSignup = {
                'name': userData.username,
                'email': userData.email,
                'password': userData.password
            }
            const user = await signupAPI(userDataSignup);

            
            const res = {
                'data': { 
                    'msg': 'User Created',
                    'access_token' : 'loggedin'
                }
            }
            setUserData({...userData, err: '', success: res.data.msg});
            // localStorage.setItem("firstLogin", true);
            // localStorage.setItem("user", res.data.access_token);

            window.location.href = "/";
        } catch (err) {
            err.response.data.msg && setUserData({...userData, err: err.response.data.msg, success: ''});
        }
    }

    return (
        <div className="container">
            <img className="reg__image" src={registerImage} alt="register page" />
            <main className="reg__main">
                <h2 id="reg__title">Shell Today</h2>
                <p className="reg__sub">Register to Shell Today</p>
                <form className="reg__form" onSubmit={handleSubmit}>
                    <label className="reg__label" htmlFor="username">Name: </label>
                    <input
                        className="reg__input"
                        type="text"
                        id="username"
                        name="username"
                        placeholder=" &#xF007;  Name"
                        style={{fontFamily: "Arial, FontAwesome"}}
                        onChange={handleChangeInput}
                        value={username}
                    />
                    <label className="reg__label" htmlFor="email">Email Address: </label>
                    <input
                        className="reg__input"
                        type="text"
                        id="email"
                        name="email"
                        placeholder=" &#xF0E0;  Email Address"
                        style={{fontFamily: "Arial, FontAwesome"}}
                        onChange={handleChangeInput}
                        value={email}
                    />
                    <label className="reg__label" htmlFor="password">Password: </label>
                    <input
                        className="reg__input"
                        type="password"
                        id="password"
                        name="password"
                        placeholder=" &#xF023;  Password"
                        style={{fontFamily: "Arial, FontAwesome"}}
                        onChange={handleChangeInput}
                        value={password}
                    />
                    <label className="reg__label" htmlFor="cpassword">Confirm Password: </label>
                    <input
                        className="reg__input"
                        type="password"
                        id="cpassword"
                        name="cpassword"
                        placeholder=" &#xF023;  Confirm Password"
                        style={{fontFamily: "Arial, FontAwesome"}}
                        onChange={handleChangeInput}
                        value={cpassword}
                    />
                    {/* {console.log(err)} */}
                    {err && showErrorMsg(err)}
                    {success && showSuccessMsg(success)}
                    {/* <div className="login-btn"> */}
                        <button className="reg__btn" type="submit">Register</button>
                    {/* </div> */}
                </form>
                <p id="login">
                    Already have an account? <Link className="reg__l__btn" to="/">Login</Link>
                </p>
            </main>
        </div>
    )
};

export default Register;