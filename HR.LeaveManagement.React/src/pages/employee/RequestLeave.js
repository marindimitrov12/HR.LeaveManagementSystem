import {useState,useEffect} from 'react'
import { getAllLeaveTypes } from '../../api/service'
import { createLeaveRequest } from '../../api/service'
import { useNavigate } from 'react-router-dom'
export default function RequestLeave(){

    const[formData,setFormData]=useState({})
    const navigate=useNavigate()
    const[leaveTypes,setLeaveTypes]=useState([])

    useEffect(()=>{
        const fetchData=async()=>{
            const data=await getAllLeaveTypes()
            setLeaveTypes(data)
            console.log(data)
        }
        fetchData()
    },[])
    const onSubmit = async (e) => {
        e.preventDefault()
        console.log(formData)
        await createLeaveRequest(formData)
        navigate("/employee/myLeave")
       };
    function handleChange(e) {
        const { name, value } = e.target
        setFormData(prev => ({
            ...prev,
            [name]: value
        }))
    }
    return ( <div className="login-container">
    <h1>Request Leave</h1>
    <form  className="login-form" onSubmit={onSubmit}>
    <div  className="text-danger"></div>
            <div className="form-group">
                <label name="leaveTypeId" className="control-label">Select Leave Type:</label>
               
                <select name="leaveTypeId" onChange={handleChange} className="form-control">
                    {leaveTypes.map(type=><option value={type.id}key={type.id}>{type.name}</option>)}
                </select>
                <span name="leaveTypeId" className="text-danger"></span>
            </div>
       
         <div className="row">
                <div className="col-md-6">
                    <div className="form-group">
                        <label name="startDate" className="control-label"></label>
                        <input name="startDate" onChange={handleChange}className="form-control" type="date"/> 
                        <span  className="text-danger"></span>
                    </div>
                </div>
                <div className="col-md-6">
                    <div className="form-group">
                        <label name="endDate" className="control-label"></label>
                        <input name="endDate"onChange={handleChange} className="form-control" type="date"/>
                        <span name="endDate" className="text-danger"></span>
                    </div>
                </div>
            </div>
            
            <div className="form-group">
                <label name="requestComments" className="control-label"></label>
                <textarea name="requestComments" onChange={handleChange}className="form-control"></textarea>
                <span name="requestComments" className="text-danger"></span>
            </div>
            


           
        <button>Request Leave</button>
    </form>
</div>)
}