import React from 'react'
import{useLocation,Link}from'react-router-dom'

export default function Details(){
    const req=useLocation().state
    
    let className;
    let headingText;
    if (req.approved === null)
    {
        className = "warning";
        headingText = "Pending Approval";
    }
    else if (req.approved == true)
    {
        className = "success";
        headingText = "Approved";
    }
    else
    {
        className = "danger";
        headingText = "Rejected";
    }
   
    return (
        <>
        <div className={`alert alert-${className}`} role="alert">
        <h4 className="alert-heading">{headingText}</h4>
        <p>
            <strong>Employee name:</strong>{req.employee.firstname} {req.employee.lastname}<br />
        </p>
        <hr/>
        <p>
            Date Requested:{req.dateRequested}
        </p>
    </div>
    
    
    <div>
    
        <hr />
        <dl className="table">
            <dt className="col-sm-2">
                StartDate
            </dt>
            <dd className="col-sm-10">
                {req.startDate}
            </dd>
            <dt className="col-sm-2">
               endDate
            </dt>
            <dd className="col-sm-10">
                {req.endDate}
            </dd>
            <dt className="col-sm-2">
               LeaveType
            </dt>
            <dd className="col-sm-10">
              {req.leaveType.name}
            </dd>
            
           
        </dl>
    </div>
    <div className="table">
          
     <Link className="btn btn-outline-secondary me-1" to="/employee/myLeave">
            Back to List
        </Link>
        
    </div>
    
        </>)
}