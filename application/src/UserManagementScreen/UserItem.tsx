import React from "react"
import { UserType } from "./UserTypes";
import UserOverview from "./UserOverview";
import './UserManagementScreen.css'

type PropsType = {
   user:  UserType;
   details: (id: number) => void;
   edit: (user: UserType) => void;
}; 

const UserItem = (props: PropsType) => {
    const toggleDetails = () => props.details(props.user.Id)
    const editUser = () => {
        props.edit(props.user);
    }

    return(
        <div className="userCard">
            <UserOverview user={props.user} details={props.details}></UserOverview>           
            <button onClick={toggleDetails}>Details</button>
            <button onClick={editUser}>Edit</button>
        </div>
    )
}

export default UserItem