import {useState,useEffect} from 'react'
import {getAllEmployes} from "../../api/service"

export default  function EmployesInfo(){
    const [employes,setEmployes]=useState(null)

    useEffect(()=>{
      const fetchData=async()=>{
        const data=await getAllEmployes()
        setEmployes(data)
      }
      fetchData()
     
    },[])
    console.log(employes)
    return(<><h1 className="table">Employes Info</h1>
    <table  className="styled-table">
        <thead>
            <tr>
                <th>
                  Employee Name
                </th>
             
                <th>
                    WorkExperiance
                </th>
                <th>
                    Email
                </th>
                <th>
                    JobTitle
                </th>
                
                <th>
                    Salary
                </th>
                
                <th></th>
            </tr>
        </thead>
        <tbody>
        {employes===null?<tr><td>Loading</td></tr>:employes.map(emp=> <tr key={emp.email}>
          <td>
              {emp.firstname} {emp.lastname}
          </td>
          <td>
             {emp.workExperience}
          </td>
          <td>
             {emp.email}
          </td>
          <td>
            {emp.jobTitle}
          </td>
          <td>
             {emp.salary}
          </td>
          
      </tr>)} 
     
  
        </tbody>
    </table>
  </>)
}