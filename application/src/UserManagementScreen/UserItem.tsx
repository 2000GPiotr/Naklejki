import React from "react"
import { UpdateUserType, UserType } from "./UserTypes";
import './Styles/UserManagementScreen.css'

type PropsType = {
   user:  UserType;
   details: (id: number) => void;
   edit: (user: UpdateUserType) => void;
   delete: (id: number) => void;
}; 

const UserItem = (props: PropsType) => {
    const {user} = props;
    
    const updateUser: UpdateUserType = {
        id: user.id,
        login: user.login,
        name: user.name,
        surname: user.surname,
        password: '',
        rolesId: user.roles.map(r => r.id),
    }

    const toggleDetails = () => props.details(props.user.id)
    const editUser = () => props.edit(updateUser);
    const deleteUser = () => props.delete(props.user.id);

    const printArray = (array: any[]) => array.join(", ");

    return(
        <div className="userCard">
            <div>
                <h2>{props.user.name} {props.user.surname}</h2>
                {props.user.ShowDetails ? (
                <div>
                    <div>{props.user.id}</div>
                    <div>{props.user.login}</div>
                    <div>{printArray(props.user.roles.map(r => r.name))}</div>
                </div>
                ) : null}
            </div>
            
            <button onClick={toggleDetails}>Details</button>
            <button onClick={editUser}>Edit</button>
            <button onClick={deleteUser}>Delete</button>
        </div>
    )
}

export default UserItem