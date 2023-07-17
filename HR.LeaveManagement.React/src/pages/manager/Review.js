import {useState} from 'react'
import {useParams,useLocation,Link,useNavigate}from 'react-router-dom'
import {changeApproval}from'../../api/service'
export default function Review(){
    const id=useParams()
    const location=useLocation()
    const navigate=useNavigate()
    const emp=location.state
    const [empl,setEmpl]=useState(emp[0])  
    let className;
    let headingText;
    if (emp[0].approved === null)
    {
        className = "warning";
        headingText = "Pending Approval";
    }
    else if (emp[0].approved == true)
    {
        className = "success";
        headingText = "Approved";
    }
    else
    {
        className = "danger";
        headingText = "Rejected";
    }
    const handleApproveClick=async()=>{
         await changeApproval(id.id,true)
         setEmpl(prev=>{
            return {...prev,
              approved:true}
         })
         navigate("/manager/leaveRequest")
    }
    const handleRejectClick=async()=>{
        await changeApproval(id.id,false)
        setEmpl(prev=>{
            return {...prev,
              approved:false}
         })
         navigate("/manager/leaveRequest")
   }
   
    return(
    <>
    <div className={`alert alert-${className}`} role="alert">
    <h4 className="alert-heading">{headingText}</h4>
    <p>
        <strong>Employee name:</strong>{empl.employee.firstname} {empl.employee.lastname}<br />
    </p>
    <hr/>
    <p>
        Date Requested:{empl.dateRequested}
    </p>
</div>


<div>

    <hr />
    <dl className="table">
        <dt className="col-sm-2">
            StartDate
        </dt>
        <dd className="col-sm-10">
            {empl.startDate}
        </dd>
        <dt className="col-sm-2">
           endDate
        </dt>
        <dd className="col-sm-10">
            {empl.endDate}
        </dd>
        <dt className="col-sm-2">
           LeaveType
        </dt>
        <dd className="col-sm-10">
          {empl.leaveType.name}
        </dd>
        
       
    </dl>
</div>
<div className="table">
    <button className="btn btn-success me-1" onClick={handleApproveClick}>
                Approve
            </button>
        
            <button className="btn btn-danger me-1"onClick={handleRejectClick}>
                Reject
            </button>
        
         
 <Link className="btn btn-outline-secondary me-1" to="/manager/leaveRequest">
        Back to List
    </Link>
    
</div>

    </>)
}