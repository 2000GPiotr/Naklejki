import React, { useContext, useState } from "react";
import { CreateUserType, RoleType, UserType } from "./UserTypes";
import './UserManagementScreen.css'
import { postData } from "../Helpers";
import { RoleContext } from "./RoleContext";
import { useNavigate } from "react-router-dom";


const UserAdd = () => {
    const [addedUser, setAddedUser] = useState<CreateUserType>({ name: '', surname: '', login: '', password: '', rolesId: []})
    const roles = useContext(RoleContext);
  
    const navigate = useNavigate();

    const handleSave = () => {
      postData('http://localhost:5021/User', addedUser)
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
          console.log(user);
        })
        .catch(error => {
          console.error('Error:', error);
        })
        .finally(() => navigate("/UserManagementScreen"));
    };
  
    const handleCancel = () => {
      navigate("/UserManagementScreen")
    };
    
    const handleRoleChange = (role: RoleType, isChecked: boolean) => {
      console.log({role});
      console.log({isChecked});
        const roles = [...addedUser.rolesId];
        if (isChecked) {
          roles.push(role.id);
        } else {
          const index = roles.indexOf(role.id);
          if (index !== -1) {
            roles.splice(index, 1);
          }
        }
        setAddedUser({...addedUser, rolesId: roles})
      };
  
    return (
      <div className="">
        <div className="">
          <h2>Add user</h2>
          <label>
            Name:
            <input type="text" value={addedUser.name} onChange={(e) => setAddedUser({ ...addedUser, name: e.target.value })} />
          </label>
          <label>
            Surname:
            <input type="text" value={addedUser.surname} onChange={(e) => setAddedUser({ ...addedUser, surname: e.target.value })} />
          </label>
          <label>
            Login:
            <input type="text" value={addedUser.login} onChange={(e) => setAddedUser({ ...addedUser, login: e.target.value })} />
          </label>
          <label>
            Password:
            <input type="password" onChange={(e) => setAddedUser({ ...addedUser, password: e.target.value })} />
          </label>
          <div>
          <p>Roles:</p>
          {roles.map((role) => (
            <label className="checkboxInput" key={role.id}>
            <div>{role.name}</div>
              <input
                type="checkbox"
                checked={addedUser.rolesId.includes(role.id)}
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
