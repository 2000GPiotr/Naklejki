import React from "react"
import { UpdateUserType, UserType } from "./UserTypes";
import UserOverview from "./UserOverview";
import './UserManagementScreen.css'

type PropsType = {
   user:  UserType;
   details: (id: number) => void;
   edit: (user: UpdateUserType) => void;
   delete: (id: number) => void;
}; 

const UserItem = (props: PropsType) => {
    const {user} = props;
    const updateUser: UpdateUserType = {
        Id: user.Id,
        Login: user.Login,
        Name: user.Name,
        Surname: user.Surname,
        Password: '',
        Roles: user.Roles,
    }

    const toggleDetails = () => props.details(props.user.Id)
    const editUser = () => props.edit(updateUser);
    const deleteUser = () => props.delete(props.user.Id);

    return(
        <div className="userCard">
            <UserOverview user={props.user} details={props.details}></UserOverview>           
            <button onClick={toggleDetails}>Details</button>
            <button onClick={editUser}>Edit</button>
            <button onClick={deleteUser}>Delete</button>
        </div>
    )
}

export default UserItem