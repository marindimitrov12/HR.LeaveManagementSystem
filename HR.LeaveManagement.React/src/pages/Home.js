import {useEffect,useState} from 'react'
import { useIsAuthenticated } from 'react-auth-kit'

export default function Home(){
    const isAuthenticated=useIsAuthenticated();
    const [user,setUser]=useState(null)
    
    useEffect(() => {
        const loggedInUser = localStorage.getItem("user");
        if (loggedInUser!==null) {
          
          setUser(loggedInUser);
        }
      });

    
    return (
       <>
       {!isAuthenticated()?
        <div className="about-page-cta">
        <h1>You are currently not logged in!</h1>
        <h2>To use this system you should log in first!</h2>
        </div>:
        <div className="about-page-cta">
        <h1> Wellcome to our system!</h1>
        <h2>Current User: {user} </h2>
        </div>}
       </> 
    
    )
}