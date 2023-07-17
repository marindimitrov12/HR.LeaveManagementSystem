import {useEffect,useState} from "react"
import { useNavigate } from "react-router-dom"
import { login } from "../api/service";
import { useSignIn } from "react-auth-kit";

export default function Login() {
    const [loginFormData, setLoginFormData] = useState({ email: "", password: "" })
    const[user,setUser]=useState({})
    const signIn=useSignIn()
    const navigate=useNavigate()
    

    async function handleSubmit(e) {
        e.preventDefault()
      await onSubmit(loginFormData)
    
     
    }
    const onSubmit = async (values) => {
        
       const response= await login(values)
       console.log(response.status)
       if(response.status===200){
        signIn({
            token: response.data.token,
            expiresIn: 3600,
            tokenType: "Bearer",
            authState: { email: values.email },
          });
          if(loginFormData.email==='manager@localhost.com'){
            navigate("/manager")
          }
          else{
            navigate("/employee")
          }
       }
       
        
       
     
      };

  
    function handleChange(e) {
        const { name, value } = e.target
        setLoginFormData(prev => ({
            ...prev,
            [name]: value
        }))
    }

    return (
        <div className="login-container">
            <h1>Sign in to your account</h1>
            <form onSubmit={handleSubmit} className="login-form">
                <input
                    name="email"
                    onChange={handleChange}
                    type="email"
                    placeholder="Email address"
                    value={loginFormData.email}
                />
                <input
                    name="password"
                    onChange={handleChange}
                    type="password"
                    placeholder="Password"
                    value={loginFormData.password}
                />
                <button>Log in</button>
            </form>
        </div>
    )

}