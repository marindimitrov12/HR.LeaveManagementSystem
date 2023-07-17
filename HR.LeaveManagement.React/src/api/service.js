import axios from "axios";
import { json } from "react-router-dom";


export  async function getAllEmployes(){
    
    try {
        var data= await axios.get('https://localhost:7297/api/EmployesInfo').then(res=>res.data)
    
        // Work with the response...
    } catch (err) {
        if (err.response) {
            // The client was given an error response (5xx, 4xx)
            console.log(err.response.data);
            console.log(err.response.status);
            console.log(err.response.headers);
        } else if (err.request) {
            // The client never received a response, and the request was never left
            console.log(err.request);
        } else {
            // Anything else
            console.log('Error', err.message);
        }
    }
 
 
 return data
}
export  async function register(formData){
    try {
        const data= await axios.post('https://localhost:7297/api/Account/register',formData)
        
        // Work with the response...
    } catch (err) {
        if (err.response) {
            // The client was given an error response (5xx, 4xx)
            console.log(err.response.data);
            console.log(err.response.status);
            console.log(err.response.headers);
        } else if (err.request) {
            // The client never received a response, and the request was never left
            console.log(err.request);
        } else {
            // Anything else
            console.log('Error', err.message);
        }
    }
}
export async function login(formData){

    try {
        var response = await axios.post(
            "https://localhost:7297/api/Account/login",
            formData
          );
          
          console.log("obj",response.data.token)
          localStorage.setItem('user', response.data.email)
          localStorage.setItem('token',response.data.token)
        
        // Work with the response...
    } catch (err) {
        if (err.response) {
            // The client was given an error response (5xx, 4xx)
            console.log(err.response.data);
            console.log(err.response.status);
            console.log(err.response.headers);
            return err.response.status
        } else if (err.request) {
            // The client never received a response, and the request was never left
            console.log(err.request);
        } else {
            // Anything else
            console.log('Error', err.message);
        }
    }
    return response
}
export async function getAllLeaveRequests(){
    try {
        var response= await axios.get('https://localhost:7297/api/LeaveRequests?isLoggedInUser=false',{ headers: {"Authorization" : `Bearer ${localStorage.getItem('token')}`} })
        
        // Work with the response...
    } catch (err) {
        if (err.response) {
            // The client was given an error response (5xx, 4xx)
            console.log(err.response.data);
            console.log(err.response.status);
            console.log(err.response.headers);
        } else if (err.request) {
            // The client never received a response, and the request was never left
            console.log(err.request);
        } else {
            // Anything else
            console.log('Error', err.message);
        }
    }
    return response.data
}
export async function changeApproval(id,approved){
   
    try {
        var response= await axios.put(`https://localhost:7297/api/LeaveRequests/changeapproval/${id}`,{
            "id":id,
            "approved":approved,
          },{ headers: {"Authorization" : `Bearer ${localStorage.getItem('token')}`} })
        
        // Work with the response...
    } catch (err) {
        if (err.response) {
            // The client was given an error response (5xx, 4xx)
            console.log(err.response.data);
            console.log(err.response.status);
            console.log(err.response.headers);
        } else if (err.request) {
            // The client never received a response, and the request was never left
            console.log(err.request);
        } else {
            // Anything else
            console.log('Error', err.message);
        }
    }
    
}
export  async function getAllLeaveTypes(){
    try {
        var response= await axios.get('https://localhost:7297/api/LeaveTypes',{ headers: {"Authorization" : `Bearer ${localStorage.getItem('token')}`} })
        
        // Work with the response...
    } catch (err) {
        if (err.response) {
            // The client was given an error response (5xx, 4xx)
            console.log(err.response.data);
            console.log(err.response.status);
            console.log(err.response.headers);
        } else if (err.request) {
            // The client never received a response, and the request was never left
            console.log(err.request);
        } else {
            // Anything else
            console.log('Error', err.message);
        }
    }
    return response.data
}
export async function editLeaveType(id,name,defaultDays){
    try {
        var response= await axios.put(`https://localhost:7297/api/LeaveTypes/${id}`,{
            "name":name,
            "defaultDays":defaultDays,
          },{ headers: {"Authorization" : `Bearer ${localStorage.getItem('token')}`} })
        
        // Work with the response...
    } catch (err) {
        if (err.response) {
            // The client was given an error response (5xx, 4xx)
            console.log(err.response.data);
            console.log(err.response.status);
            console.log(err.response.headers);
        } else if (err.request) {
            // The client never received a response, and the request was never left
            console.log(err.request);
        } else {
            // Anything else
            console.log('Error', err.message);
        }
    }

}
export async function createLeaveType(name,defaultDays){
    try {
        var response= await axios.post(`https://localhost:7297/api/LeaveTypes`,{
            "name":name,
            "defaultDays":defaultDays,
          },{ headers: {"Authorization" : `Bearer ${localStorage.getItem('token')}`} })
        
        // Work with the response...
    } catch (err) {
        if (err.response) {
            // The client was given an error response (5xx, 4xx)
            console.log(err.response.data);
            console.log(err.response.status);
            console.log(err.response.headers);
        } else if (err.request) {
            // The client never received a response, and the request was never left
            console.log(err.request);
        } else {
            // Anything else
            console.log('Error', err.message);
        }
    }

}
export async function deleteLeaveType(id){
    try {
        var response= await axios.delete(`https://localhost:7297/api/LeaveTypes/${id}`
           ,{ headers: {"Authorization" : `Bearer ${localStorage.getItem('token')}`} })
        
        // Work with the response...
    } catch (err) {
        if (err.response) {
            // The client was given an error response (5xx, 4xx)
            console.log(err.response.data);
            console.log(err.response.status);
            console.log(err.response.headers);
        } else if (err.request) {
            // The client never received a response, and the request was never left
            console.log(err.request);
        } else {
            // Anything else
            console.log('Error', err.message);
        }
    }

}
export async function allocateLeaveType(id){
    try {
        var response= await axios.post(`https://localhost:7297/api/LeaveAllocation`
           ,{
            "leaveTypeId": id
          } ,{ headers: {"Authorization" : `Bearer ${localStorage.getItem('token')}`} })
        
        // Work with the response...
    } catch (err) {
        if (err.response) {
            // The client was given an error response (5xx, 4xx)
            console.log(err.response.data);
            console.log(err.response.status);
            console.log(err.response.headers);
        } else if (err.request) {
            // The client never received a response, and the request was never left
            console.log(err.request);
        } else {
            // Anything else
            console.log('Error', err.message);
        }
    }

}
export async function getUserLeaveRequest(){

    try {
        var response= await axios.get(`https://localhost:7297/api/LeaveRequests?isLoggedInUser=true`
           ,{ headers: {"Authorization" : `Bearer ${localStorage.getItem('token')}`} })
        
        // Work with the response...
    } catch (err) {
        if (err.response) {
            // The client was given an error response (5xx, 4xx)
            console.log(err.response.data);
            console.log(err.response.status);
            console.log(err.response.headers);
        } else if (err.request) {
            // The client never received a response, and the request was never left
            console.log(err.request);
        } else {
            // Anything else
            console.log('Error', err.message);
        }
    }
    return response.data
}
export async function deleteLeaveRequest(id){

    try {
        var response= await axios.delete(`https://localhost:7297/api/LeaveRequests?id=${id}`
           ,{ headers: {"Authorization" : `Bearer ${localStorage.getItem('token')}`} })
        
        // Work with the response...
    } catch (err) {
        if (err.response) {
            // The client was given an error response (5xx, 4xx)
            console.log(err.response.data);
            console.log(err.response.status);
            console.log(err.response.headers);
        } else if (err.request) {
            // The client never received a response, and the request was never left
            console.log(err.request);
        } else {
            // Anything else
            console.log('Error', err.message);
        }
    }
    
}
export async function createLeaveRequest(form){

    try {
        var response= await axios.post(`
        https://localhost:7297/api/LeaveRequests`,
        {
            "startDate": form.startDate,
            "endDate": form.endDate,
            "leaveTypeId": form.leaveTypeId,
            "requestComments": form.requestComments
          }
           ,{ headers: {"Authorization" : `Bearer ${localStorage.getItem('token')}`} })
        
        // Work with the response...
    } catch (err) {
        if (err.response) {
            // The client was given an error response (5xx, 4xx)
            console.log(err.response.data);
            console.log(err.response.status);
            console.log(err.response.headers);
        } else if (err.request) {
            // The client never received a response, and the request was never left
            console.log(err.request);
        } else {
            // Anything else
            console.log('Error', err.message);
        }
    }
    
}