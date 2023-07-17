import React from "react"
import bgImg from "../resorses/hr-systems-gmbh-vector-logo.png"
import { Link } from "react-router-dom"

export default function About() {
    const user=localStorage.getItem('user')
    let path=""
    if(user==="manager@localhost.com"){
       path="/manager"
    }else if(user===null){
     path="/"
    }else{
     path="/employee"
    }
    return (
        <div className="about-page-container">
            <img src={bgImg} className="about-hero-image" />
            <div className="about-page-content">
                <h1>The only HR system you can deploy at lightning speed ⚡</h1>
                <p>Sloneek is a modern HR system that contains everything you need to manage the entire journey of employees and freelancers. Save 20 hours per week on HR processes and operations.</p>
             
             
            </div>
            <div className="about-page-cta">
                <h2>Sloneek is also liked by your colleagues and friends!<br />We're not playing games. Our results are confirmed by hundreds of positive references from satisfied clients.</h2>
                <Link className="link-button" to={path}>Back</Link>
            </div>
        </div>
    );
}