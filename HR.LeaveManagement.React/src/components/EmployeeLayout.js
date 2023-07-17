import React from "react"
import { NavLink, Outlet } from "react-router-dom"

export default function EmployeeLayout() {
    const activeStyles = {
        fontWeight: "bold",
        textDecoration: "underline",
        color: "#161616"
    }

    return (
        <>
            <nav className="host-nav">
                <NavLink
                    to="requestLeave"
                    end
                    style={({ isActive }) => isActive ? activeStyles : null}
                >
                    Request Leave
                </NavLink>

                <NavLink
                    to="myLeave"
                    style={({ isActive }) => isActive ? activeStyles : null}
                >
                    My Leave
                </NavLink>
                

            </nav>
            <Outlet />
        </>
    )
}