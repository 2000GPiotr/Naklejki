import React from "react";
import { UserType } from "./UserTypes";

type PropsType = {
    user:  UserType;
    details: (id: number) => void
 }; 

const UserOverview = (props: PropsType) =>{
    const printArray = (array: any[]) => array.join(", ")
    
    return (
        <div>
          <h2>{props.user.Name} {props.user.Surname}</h2>
          {props.user.ShowDetails ? (
            <div>
              <div>{props.user.Id}</div>
              <div>{props.user.Login}</div>
              <div>{printArray(props.user.Roles.map(r => r.Nazwa))}</div>
            </div>
          ) : null}
        </div>
      );
}

export default UserOverview