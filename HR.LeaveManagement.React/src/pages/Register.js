import {useEffect,useState} from "react"
import { useNavigate } from "react-router-dom"
import { useSignIn } from "react-auth-kit";
import {register} from"../api/service"


export default function Register() {
    const navigate=useNavigate()
    const [registerFormData, setRegisterFormData] = useState({ firstname:"",jobTitle:"",
    workExperience:"",salary:"",lastname:"",
    email: "",username:"", password: "" })
    
    async function handleSubmit(e) {
        e.preventDefault()
      await onSubmit(registerFormData)
     navigate("/manager/employesInfo")
    }
    const onSubmit = async (values) => {
         await register(values)
      };

  
    function handleChange(e) {
        const { name, value } = e.target
        setRegisterFormData(prev => ({
            ...prev,
            [name]: value
        }))
    }

    return (
        <div className="login-container">
            <h1>Create new User</h1>
            <form onSubmit={handleSubmit} className="login-form">
                <input
                    name="firstname"
                    onChange={handleChange}
                    type="text"
                    placeholder="FirstName"
                    value={registerFormData.firstname}
                />
                <input
                    name="lastname"
                    onChange={handleChange}
                    type="text"
                    placeholder="LastName"
                    value={registerFormData.lastname}
                />
                 <input
                    name="email"
                    onChange={handleChange}
                    type="email"
                    placeholder="Email"
                    value={registerFormData.email}
                />
                 <input
                    name="salary"
                    onChange={handleChange}
                    type="text"
                    placeholder="Salary"
                    value={registerFormData.salary}
                />
                 <input
                    name="workExperience"
                    onChange={handleChange}
                    type="text"
                    placeholder="WorkExperience"
                    value={registerFormData.workExperience}
                />
                
                 <input
                    name="jobTitle"
                    onChange={handleChange}
                    type="text"
                    placeholder="JobTitle"
                    value={registerFormData.jobTitle}
                />
                <input
                    name="username"
                    onChange={handleChange}
                    type="text"
                    placeholder="UserName"
                    value={registerFormData.username}
                />
                 <input
                    name="password"
                    onChange={handleChange}
                    type="password"
                    placeholder="Password"
                    value={registerFormData.password}
                />
                
                <button>Log in</button>
            </form>
        </div>
    )

}