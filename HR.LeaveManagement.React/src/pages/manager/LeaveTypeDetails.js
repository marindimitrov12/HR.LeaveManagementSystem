import React from 'react'
import { Link,useLocation } from 'react-router-dom'
export default function LeaveTypeDetails(){
    const location=useLocation()
    const leavetype=location.state
    console.log(leavetype[0])
    return(
    
    <>

<h1 className='table'>Details</h1>

<div className='table'>
    <h4>LeaveType</h4>
    <hr />
    <dl className="row">
        <dt className = "col-sm-2">
           Id
        </dt>
        <dd className = "col-sm-10">
           {leavetype[0].id}
        </dd>
        <dt className = "col-sm-2">
            Name
        </dt>
        <dd className = "col-sm-10">
           {leavetype[0].name}
        </dd>
        <dt className = "col-sm-2">
        DefaultDays
        </dt>
        <dd className = "col-sm-10">
            {leavetype[0].defaultDays}
        </dd>
    </dl>
</div>
<div className='table'>
    <Link to='/manager/leaveTypes/1/edit'state={leavetype[0]}className='btn btn-outline-secondary btn-sm me-1'>Edit</Link>
    <Link to='/manager/leaveTypes' className='btn btn-outline-secondary btn-sm me-1'>Back to List</Link>
</div>

    </>)
}