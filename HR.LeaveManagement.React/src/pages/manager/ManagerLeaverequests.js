import {useEffect,useState} from 'react'
import{getAllLeaveRequests}from "../../api/service"
import{Link}from"react-router-dom"
export default function ManagerLeaverequests(){
    
    const[requests,setRequests]=useState(null)

    useEffect(()=>{
       const fetchData=async()=>{
        const data=await getAllLeaveRequests()
        console.log(data)
        setRequests(data)
       }
       fetchData()
    },[])
    return(
    <>
    <h1 className='table'>Leave Request Log</h1>
    <table  className="styled-table">
        <thead>
            <tr>
                <th>
                  Employee Name
                </th>
             
                <th>
                    Start Date
                </th>
                <th>
                    End Date
                </th>
                <th>
                    Leave Type
                </th>
                
                <th>
                    Date Requested
                </th>
                <th>
                    Approval Status
                </th>
                
                <th></th>
            </tr>
        </thead>
        <tbody>
        {requests===null?<tr><td>Loading</td></tr>:requests.map(emp=> <tr key={emp.id}>
          <td>
              {emp.employee.firstname} {emp.employee.lastname}
          </td>
          <td>
             {emp.startDate}
          </td>
          <td>
             {emp.endDate}
          </td>
          <td>
            {emp.leaveType.name}
          </td>
          <td>
             {emp.dateRequested}
          </td>
          <td>
             {emp.approved?"approved":"rejected"}
             
          </td>
          <td>
          <Link className='btn btn-outline-primary'state={requests.filter(x=>x.id===emp.id)}to={`/manager/leaveRequest/${emp.id}`}>Review</Link>
          </td>
      </tr>)} 
     
  
        </tbody>
    </table>
    </>)
}