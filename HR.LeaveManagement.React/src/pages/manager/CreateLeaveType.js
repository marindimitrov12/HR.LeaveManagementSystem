import { useState } from "react"
import{createLeaveType}from"../../api/service"
export default function CreateLeaveType(){
    

    const[formdata,setFormData]=useState({})


    async function handleSubmit(e) {
        e.preventDefault()
      await onSubmit(formdata)
    }
    const onSubmit = async (values) => {
        
        console.log(formdata)
        await createLeaveType(formdata.name,formdata.defaultDays)
        
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
            <h1>Create LeaveType</h1>
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
                    placeholder="defaultDays"
                    value={formdata.defaultDays}
                />
                <button>Create</button>
            </form>
        </div>
    </>)
}