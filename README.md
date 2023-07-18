# HR.LeaveManagementSystem

# Description:
The goal of this project is to develop a web application through which the employees of a given company will be able to make leave requests, and the managers will be able to review and approve them accordingly. The application will allow employees to edit or delete their requests while the status of the request is still pending approval. Once the manager approves or declines the respective request, the employee will immediately receive an email for information. As technologies to implement the project, I will use .NET Core Web API, .NET Core MVC Application,React.js, Entity Framework Core, BootStrap, SenGrid – Email Delivery Api, XUnit and Moq

# General Requirements:

Implementing Solid

Implementing Clean or Onion Architecture and Best Practices

Add Email Service using SendGrid

Efficient Exception Handling and Routing

Implementing Unit Testing

Moq and Shouldy

Global Error Handling with Custom Middleware and Exceptions

Adding Validation Using Fluent Validation

Build a .NET Core API and MVC UI Application

Build a React UI Client using React router 6 and axios

Implement JWT(JSON Web Token)  Authentication


Use GitHub For Source Control

# Application Structure
# Employees side - React Client
<img width="1440" alt="image" src="https://github.com/marindimitrov12/HR.LeaveManagementSystem/assets/63950527/7f5a11f7-8c16-4cd5-848e-b4c43580f7ee">

When the page first loads, the user can log in as an employee with the username and password previously provided by the manager. 
<img width="1437" alt="image" src="https://github.com/marindimitrov12/HR.LeaveManagementSystem/assets/63950527/c645fd3c-c9b7-4ef2-b573-3f83f9009339">

After logging into the system  the user will be redirected to the home page again, but this time two new fields Request Leave and My Leave will have appeared in the header.
<img width="1440" alt="image" src="https://github.com/marindimitrov12/HR.LeaveManagementSystem/assets/63950527/b39c533b-89cc-43dd-89a4-d5f7c4471b87">

After pressing the Request Leave button the user will be taken to create leaverequest form.
Where he will have the opportunity to create his Leave request.
<img width="1431" alt="image" src="https://github.com/marindimitrov12/HR.LeaveManagementSystem/assets/63950527/aad64e17-0a07-48f5-a086-468e43069a4e">

By pressing the My Leave button, the user will have the opportunity to see all his requests made so far.
<img width="1440" alt="image" src="https://github.com/marindimitrov12/HR.LeaveManagementSystem/assets/63950527/08990a64-f139-4866-92fa-b14a7e77c7b6">

As here he has the opportunity to see the details of his request and to edit or delete it. Given that delete and edit are valid only if the request has a pending approval status.
<img width="1436" alt="image" src="https://github.com/marindimitrov12/HR.LeaveManagementSystem/assets/63950527/b138103f-7767-4a73-aae4-eba1178e2011">


# Manager side - React Client
<img width="1427" alt="image" src="https://github.com/marindimitrov12/HR.LeaveManagementSystem/assets/63950527/4a89d00a-f3ec-4635-80c5-3c7b36607762">
<img width="1439" alt="image" src="https://github.com/marindimitrov12/HR.LeaveManagementSystem/assets/63950527/24aeda23-9d93-4291-8f75-c13b860defde">

After the user logs in with one of the pre-registered manager accounts he will be redirected to the home page.
By pressing the AddUser button, the manager can register new employees in the system.
<img width="1439" alt="image" src="https://github.com/marindimitrov12/HR.LeaveManagementSystem/assets/63950527/f7b6071f-ee64-4447-8657-7b0e56fd22bb">

The Leave Types menu will take the user to the page below
<img width="1437" alt="image" src="https://github.com/marindimitrov12/HR.LeaveManagementSystem/assets/63950527/58f153c4-2eca-4ac4-be87-fb2ac2feaf77">

From there, the manager can create a new leave type that normal employees will be able to book from.After pressing Allocate button the leave type will be allocated to all  employees.

The Leave Request menu will take the manager to this page.
<img width="1434" alt="image" src="https://github.com/marindimitrov12/HR.LeaveManagementSystem/assets/63950527/613adf05-8636-45b6-91b7-4b9a27928ee9">

Here after pressing the Review button he will be able to approve or reject the corresponding request.
<img width="1440" alt="image" src="https://github.com/marindimitrov12/HR.LeaveManagementSystem/assets/63950527/154168bd-de9a-4d65-9a7f-718b8531cfa9">
<img width="1437" alt="image" src="https://github.com/marindimitrov12/HR.LeaveManagementSystem/assets/63950527/f5608ab6-f516-4762-ad60-04c5e4edd772">
<img width="1439" alt="image" src="https://github.com/marindimitrov12/HR.LeaveManagementSystem/assets/63950527/b4ec4d06-c14c-4976-870a-0323b521880d">

Once the request is approved, the relevant employee will receive an email for information.

The Employees Info menu will take the user to this page.
<img width="1434" alt="image" src="https://github.com/marindimitrov12/HR.LeaveManagementSystem/assets/63950527/efac6e24-1472-466c-b28b-22212071998c">
Which gives us detailed information about the employees in the company.

# .NET.CORE.MVC Client

<img width="452" alt="image" src="https://github.com/marindimitrov12/HR.LeaveManagementSystem/assets/63950527/39ec28e6-57d1-4db0-9cf7-68514b25ebbd">

<img width="451" alt="image" src="https://github.com/marindimitrov12/HR.LeaveManagementSystem/assets/63950527/efc86b60-671e-404d-8d76-edce6ec56463">

<img width="452" alt="image" src="https://github.com/marindimitrov12/HR.LeaveManagementSystem/assets/63950527/8bd73ed8-53ae-4e54-b876-757046c25122">

<img width="452" alt="image" src="https://github.com/marindimitrov12/HR.LeaveManagementSystem/assets/63950527/8a296584-2246-4af9-8047-020d67131770">

<img width="452" alt="image" src="https://github.com/marindimitrov12/HR.LeaveManagementSystem/assets/63950527/3cd6ee51-674d-4b45-a23b-c54c84dcd50a">

<img width="452" alt="image" src="https://github.com/marindimitrov12/HR.LeaveManagementSystem/assets/63950527/54a7b46d-db22-4637-80df-2c4439f29271">

<img width="452" alt="image" src="https://github.com/marindimitrov12/HR.LeaveManagementSystem/assets/63950527/0de03da5-af68-484e-8353-5b4efae0f602">

<img width="452" alt="image" src="https://github.com/marindimitrov12/HR.LeaveManagementSystem/assets/63950527/5431d0b9-1d69-4ba4-bb22-69b533560f14">












