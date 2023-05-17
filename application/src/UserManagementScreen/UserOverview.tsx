import React from "react";
import { UserType } from "./UserTypes";

type PropsType = {
    user:  UserType;
    details: (id: number) => void
 }; 

const UserOverview = (props: PropsType) =>{
    const printArray = (array: any[]) => array.join(", ")
    
    return(
        <div>
            <h2>{props.user.Name} {props.user.Surname}</h2>
            {props.user.ShowDetails ? <div>{props.user.Id} {printArray(props.user.Roles)}</div> : ''}
        </div>
    )
}

export default UserOverview