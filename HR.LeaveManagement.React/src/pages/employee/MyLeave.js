import {useEffect,useState} from 'react'
import {Link}from 'react-router-dom'
import { getUserLeaveRequest } from '../../api/service'
import { deleteLeaveRequest } from '../../api/service'
export default function MyLeave(){

    const[requests,setRequests]=useState([])

    useEffect(()=>{
        const fetchData=async()=>{
           const data= await getUserLeaveRequest()
           console.log(data)
           setRequests(data)
        }
        fetchData()
        
    },[])
    
   async function handleDelete(id){

    await deleteLeaveRequest(id)
    const newdata=requests.filter(x=>x.id!==id)
    setRequests(newdata)
   }
    return(<><h1 className="table">Employes Info</h1>
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
                <th> 

                </th>
               
            </tr>
        </thead>
        <tbody>
        {requests.length===0?<tr><td>Loading</td></tr>:requests.map(req=> <tr key={req.id}>
          <td>
              {req.employee.firstname} {req.employee.lastname}
          </td>
          <td>
             {req.startDate}
          </td>
          <td>
             {req.endDate}
          </td>
          <td>
            {req.leaveType.name}
          </td>
          <td>
            {req.dateRequested}
          </td>
          <td>{req.approved===null?"Pending approval":req.approved?"Approved":"Rejected"}</td>
          <td><Link to={`${req.id}`} state={req}className=' btn btn-outline-primary btn-sm me-1'>Details</Link>
          {req.approved===null?
          <button  className="btn btn-outline-danger btn-sm" onClick={async()=>handleDelete(req.id)}>
            Delete
          </button>:null}</td>
         
          
          
      </tr>)} 
     
  
        </tbody>
    </table>
  </>)
}