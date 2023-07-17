import React from "react"
import { BrowserRouter, Routes, Route, Link } from "react-router-dom"
import Layout from "./Layout";
import About from "../pages/About"
import Login from "../pages/Login"
import Home from "../pages/Home"
import ManagerLayout from "../components/ManagerLayout"
import EmployeeLayout from "./EmployeeLayout";
import EmployesInfo from "../pages/manager/EmployesInfo";
import Register from "../pages/Register";
import ManagerLeaverequests from "../pages/manager/ManagerLeaverequests";
import Review from "../pages/manager/Review";
import LeaveTypes from "../pages/manager/LeaveTypes";
import LeaveTypeDetails from "../pages/manager/LeaveTypeDetails";
import EditLeaveType from "../pages/manager/EditLeaveType";
import CreateLeaveType from"../pages/manager/CreateLeaveType"
import MyLeave from "../pages/employee/MyLeave";
import Details from "../pages/employee/Details";
import RequestLeave from "../pages/employee/RequestLeave";

function App() {
 
  
    return (
   <BrowserRouter>
   <Routes>
     <Route path="/" element={<Layout />}>
      <Route index element={<Home/>}/>
      <Route path="about" element={<About />} />
      <Route path="login"element={<Login/>}/>
      <Route path="manager"element={<ManagerLayout/>}>
      <Route index element={<Home/>}/>
      <Route path="employesInfo" element={<EmployesInfo/>}/>
      <Route path="register" element={<Register/>}/>
      <Route path="leaveRequest" element={<ManagerLeaverequests/>}/>
      <Route path="leaveRequest/:id"element={<Review/>}/>
      <Route path="leaveTypes"element={<LeaveTypes/>}/>
      <Route path="leaveTypes/:id" element={<LeaveTypeDetails/>}/>
      <Route path="leaveTypes/:id/edit" element={<EditLeaveType/>}/>
      <Route path="leaveTypes/create" element={<CreateLeaveType/>}/>
      </Route>
      <Route path="employee"element={<EmployeeLayout/>}>
      <Route index element={<Home/>}/>
      <Route path="myLeave" element={<MyLeave/>}/>
      <Route path="myLeave/:id" element={<Details/>}/>
      <Route path="requestLeave" element={<RequestLeave/>}/>
      </Route>
     </Route>
   </Routes>
   </BrowserRouter>
  );
}

export default App;
