import {useState} from 'react'
import{useLocation}from'react-router-dom'
import { editLeaveType } from '../../api/service'
export default function EditLeaveType(){

    const location=useLocation()

    const[formdata,setFormData]=useState(location.state)


    async function handleSubmit(e) {
        e.preventDefault()
      await onSubmit(formdata)
    
     
    }
    const onSubmit = async (values) => {
        
        console.log(formdata)
        await editLeaveType(location.state.id,formdata.name,formdata.defaultDays)
        
       }

    function handleChange(e) {
        const { name, value } = e.target
        setFormData(prev => ({
            ...prev,
            [name]: value
        }))
    }
    return(<>
    <div className="login-container">
            <h1>Edit</h1>
            <form onSubmit={handleSubmit} className="login-form">
                <input
                    name="name"
                    onChange={handleChange}
                    type="text"
                    placeholder="Name"
                    value={formdata.name}
                />
                <input
                    name="defaultDays"
                    onChange={handleChange}
                    type="number"
                    placeholder="DefaultDays"
                    value={formdata.defaultDays}
                />
                <button>Edit</button>
            </form>
        </div>
    </>)
}