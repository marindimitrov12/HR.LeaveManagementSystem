import {useState,useEffect} from 'react'
import {getAllLeaveTypes}from '../../api/service'
import {NavLink}from 'react-router-dom'
import { deleteLeaveType } from '../../api/service'
import { allocateLeaveType } from '../../api/service'
export default function LeaveTypes(){
    const activeStyles = {
        fontWeight: "bold",
        textDecoration: "underline",
        color: "#161616"
    }
    const [leavetypes,setLeaveTypes]=useState(null)

    useEffect(()=>{
        const fetchData=async()=>{
            var data=await getAllLeaveTypes()
            console.log(data)
            setLeaveTypes(data)
        }
       fetchData()
    },[])
    const handleAllocate=async(e)=>{
        const td=e.target.parentElement
        window.confirm('Are you sure you want to allocate to all employees?')
        await allocateLeaveType(td.parentElement.id);
        
    }
    const handleDelete=async(e)=>{
        const td=e.target.parentElement
        console.log(td.parentElement.id)
        const newLeavetypes=leavetypes.filter(x=>x.id!=td.parentElement.id)
        console.log(newLeavetypes)
        setLeaveTypes(newLeavetypes)
      await deleteLeaveType(td.parentElement.id)
    }
    return(
    <>
    <h1 className="table">Leave Types</h1>
    <table  className="styled-table">
        <thead>
            <tr>
                <th>
                  Id
                </th>
             
                <th>
                   Name
                </th>
                <th>
                  Default Number Of Days
                </th>
                <th>
                   
                </th>
               
            </tr>
        </thead>
        <tbody>
        {leavetypes===null?<tr><td>Loading</td></tr>:leavetypes.map(lv=> <tr id={lv.id}key={lv.id}>
          <td>
             {lv.id}
          </td>
          <td>
             {lv.name}
          </td>
          <td>
             {lv.defaultDays}
          </td>
          <td>
             <button className='btn btn-outline-primary btn-sm me-1'onClick={handleAllocate}>Allocate</button>
             <button className='btn btn-outline-danger btn-sm me-1'onClick={handleDelete}>Delete</button>

            <NavLink to={`create`}className='btn btn-outline-primary btn-sm me-1'>Create</NavLink>

             <NavLink  state={leavetypes.filter(x=>x.id==lv.id)}to={`${lv.id}`}className='btn btn-outline-secondary btn-sm me-1'>
                 Details
             </NavLink>
          </td>
          
          
      </tr>)} 
     
  
        </tbody>
    </table>
 
       </>)
}