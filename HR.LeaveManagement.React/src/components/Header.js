import React from "react"
import { Link, NavLink } from "react-router-dom"
import {useIsAuthenticated} from 'react-auth-kit';
import { useSignOut } from 'react-auth-kit'

export default function Header(){
    const activeStyles = {
        fontWeight: "bold",
        textDecoration: "underline",
        color: "#161616"
    }
    
    const isAuthenticated=useIsAuthenticated()
    const signOut = useSignOut()
    const user=localStorage.getItem("user");
    let path=""
   if(user==="manager@localhost.com"){
      path="/manager"
   }else if(user===null){
    path="/"
   }else{
    path="/employee"
   }
   
    function onSingOut(){
        signOut()
        localStorage.clear()
        
    }
return (<header>
    <Link className="site-logo" to={path}>#HR.LeaveMangement</Link>
    <nav>
        {!isAuthenticated()?<NavLink 
            to="/login"
            style={({isActive}) => isActive ? activeStyles : null}
        >
           Login
        </NavLink>:null}
        <NavLink 
            to="/about"
            style={({isActive}) => isActive ? activeStyles : null}
        >
            About
        </NavLink>

        {user==='manager@localhost.com'?
        <NavLink style={({isActive}) => isActive ? activeStyles : null}  to="/manager/register">
            AddUser
            </NavLink>:null}
        {isAuthenticated()?
        <NavLink style={({isActive}) => isActive ? activeStyles : null} onClick={onSingOut} to="/">
            Sign Out
            </NavLink>:null}
        
    </nav>
</header>)
}