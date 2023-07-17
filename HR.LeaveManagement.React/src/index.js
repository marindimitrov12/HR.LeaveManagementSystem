import React from 'react';
import ReactDOM from 'react-dom/client';
import { AuthProvider } from 'react-auth-kit';
import App from './components/App';
import reportWebVitals from './reportWebVitals';
import 'bootstrap/dist/css/bootstrap.css';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  
     <AuthProvider
       authType='cookie'
       authName='_auth'
       cookieDomain={window.localStorage.hostname}
       cookieSecure>
     <React.StrictMode>
    <App />
  </React.StrictMode>
  </AuthProvider>
   
 
 
);


// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
