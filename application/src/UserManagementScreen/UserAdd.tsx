import React, { useContext, useState } from "react";
import { CreateUserType, RoleType, UserType } from "./UserTypes";
import './UserManagementScreen.css'
import { postData } from "../Helpers";
import { RoleContext } from "./RoleContext";

type PropsType = {
    user: CreateUserType;
    onSave: (user: UserType) => void;
    onClose: () => void;
};

const UserAdd = (props: PropsType) => {
    const [AddedUser, setAddedUser] = useState<CreateUserType>({ ...props.user });
    const roles = useContext(RoleContext);
  
    const handleSave = () => {
      postData('http://localhost:5021/User', AddedUser)
        .then(responseData => {
          console.log('Response:', responseData);
          const {id, login, name, surname, roles} = responseData;
          const user: UserType = {
            id: id,
            login: login,
            name: name,
            surname: surname,
            roles: roles,
            ShowDetails: false
          };
          props.onSave(user);
        })
        .catch(error => {
          console.error('Error:', error);
        });

      props.onClose();
    };
  
    const handleCancel = () => {
      props.onClose();
    };
    
    const handleRoleChange = (role: RoleType, isChecked: boolean) => {
      console.log({role});
      console.log({isChecked});
        const roles = [...AddedUser.rolesId];
        if (isChecked) {
          roles.push(role.id);
        } else {
          const index = roles.indexOf(role.id);
          if (index !== -1) {
            roles.splice(index, 1);
          }
        }
        setAddedUser({...AddedUser, rolesId: roles})
      };
  
    return (
      <div className="modal">
        <div className="modal-content">
          <h2>Add user</h2>
          <label>
            Name:
            <input type="text" value={AddedUser.name} onChange={(e) => setAddedUser({ ...AddedUser, name: e.target.value })} />
          </label>
          <label>
            Surname:
            <input type="text" value={AddedUser.surname} onChange={(e) => setAddedUser({ ...AddedUser, surname: e.target.value })} />
          </label>
          <label>
            Login:
            <input type="text" value={AddedUser.login} onChange={(e) => setAddedUser({ ...AddedUser, login: e.target.value })} />
          </label>
          <label>
            Password:
            <input type="password" onChange={(e) => setAddedUser({ ...AddedUser, password: e.target.value })} />
          </label>
          <div>
          <p>Roles:</p>
          {roles.map((role) => (
            <label className="checkboxInput" key={role.id}>
            <div>{role.nazwa}</div>
              <input
                type="checkbox"
                checked={AddedUser.rolesId.includes(role.id)}
                onChange={(e) => handleRoleChange(role, e.target.checked)}
              />
            </label>
          ))}
          </div>
          <button onClick={handleSave}>Save</button>
          <button onClick={handleCancel}>Cancel</button>
        </div>
      </div>
    );
  };

export default UserAdd;
