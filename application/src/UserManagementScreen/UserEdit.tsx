import React, { useContext, useState } from "react";
import { RoleType, UpdateUserType, UserType } from "./UserTypes";
import './UserManagementScreen.css'
import { putData } from "../Helpers";
import { RoleContext } from "./RoleContext";
import { useLocation, useNavigate } from "react-router-dom";


const UserEdit = () => {
  const location = useLocation();
  const user = location.state?.user;
  
  const [editedUser, setEditedUser] = useState<UpdateUserType>(user);
  const roles = useContext(RoleContext);
  
  const navigate = useNavigate();
  
  const handleSave = () => {
    const url = 'http://localhost:5021/User/' + editedUser.id;
    putData(url, editedUser)
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
        console.error('Error: ', error);
      })
      .finally(() => navigate("/UserManagementScreen"));
  };

  const handleCancel = () => {
    navigate("/UserManagementScreen")
  };
  
  const handleRoleChange = (role: RoleType, isChecked: boolean) => {
      const roles = [...editedUser.rolesId];
      if (isChecked) {
        roles.push(role.id);
      } else {
        const index = roles.indexOf(role.id);
        if (index !== -1) {
          roles.splice(index, 1);
        }
      }
      setEditedUser({ ...editedUser, rolesId: roles });
    };

  return (
    <div >
      <div>
        <h2>Edit user</h2>
        <label>
          Name:
          <input type="text" value={editedUser.name} onChange={(e) => setEditedUser({ ...editedUser, name: e.target.value })} />
        </label>
        <label>
          Surname:
          <input type="text" value={editedUser.surname} onChange={(e) => setEditedUser({ ...editedUser, surname: e.target.value })} />
        </label>
        <label>
          Login:
          <input type="text" value={editedUser.login} onChange={(e) => setEditedUser({ ...editedUser, login: e.target.value })} />
        </label>
        <label>
          Password:
          <input type="password" onChange={(e) => setEditedUser({ ...editedUser, password: e.target.value })} />
        </label>
        <div>
        <p>Roles:</p>
        {roles.map((role) => (
          <label className="checkboxInput" key={role.id}>
          <div>{role.nazwa}</div>
            <input
              type="checkbox"
              checked={editedUser.rolesId.includes(role.id)}
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

export default UserEdit;
