import React from "react"
import { NavLink, Outlet } from "react-router-dom"

export default function ManagerLayout() {
    const activeStyles = {
        fontWeight: "bold",
        textDecoration: "underline",
        color: "#161616"
    }

    return (
        <>
            <nav className="host-nav">
                <NavLink
                    to="leaveTypes"
                    end
                    style={({ isActive }) => isActive ? activeStyles : null}
                >
                    LeaveTypes
                </NavLink>

                <NavLink
                    to="leaveRequest"
                    style={({ isActive }) => isActive ? activeStyles : null}
                >
                    LeaveRequests
                </NavLink>
                
                <NavLink
                    to="employesInfo"
                    style={({ isActive }) => isActive ? activeStyles : null}
                >
                    Employes info
                </NavLink>

               

            </nav>
            <Outlet />
        </>
    )
}