import React, { useState } from "react";
import { RoleType, UpdateUserType, UserType } from "./UserTypes";
import './UserManagementScreen.css'

type PropsType = {
    user: UpdateUserType;
    onSave: (user: UserType) => void;
    onClose: () => void;
};

const UserEdit = (props: PropsType) => {
    const [editedUser, setEditedUser] = useState<UpdateUserType>({ ...props.user });
    const [roles] = useState<RoleType[]>([{Id: 1, Nazwa: 'Admin', Description: 'Opis a'}, {Id: 2, Nazwa: 'User', Description: 'Opis u'}, {Id: 3, Nazwa: 'Magasinier', Description: 'Opis m'}]);

    const handleSave = () => {
      const newUser: UserType = {
        Id: editedUser.Id,
        Login: editedUser.Login,
        Name: editedUser.Name,
        Surname: editedUser.Surname,
        Roles: editedUser.Roles,
        ShowDetails: true
      }
      props.onSave(newUser);
      props.onClose();
    };
  
    const handleCancel = () => {
      props.onClose();
    };
    
    const handleRoleChange = (role: RoleType, isChecked: boolean) => {
        const roles = [...editedUser.Roles];
        if (isChecked) {
          roles.push(role);
        } else {
          const index = roles.indexOf(role);
          if (index !== -1) {
            roles.splice(index, 1);
          }
        }
        setEditedUser({ ...editedUser, Roles: roles });
      };
  
    return (
      <div className="modal">
        <div className="modal-content">
          <h2>Edit user</h2>
          <label>
            Name:
            <input type="text" value={editedUser.Name} onChange={(e) => setEditedUser({ ...editedUser, Name: e.target.value })} />
          </label>
          <label>
            Surname:
            <input type="text" value={editedUser.Surname} onChange={(e) => setEditedUser({ ...editedUser, Surname: e.target.value })} />
          </label>
          <label>
            Login:
            <input type="text" value={editedUser.Login} onChange={(e) => setEditedUser({ ...editedUser, Login: e.target.value })} />
          </label>
          <label>
            Password:
            <input type="password" onChange={(e) => setEditedUser({ ...editedUser, Password: e.target.value })} />
          </label>
          <div>
          <p>Roles:</p>
          {roles.map((role) => (
            <label className="checkboxInput" key={role.Id}>
            <div>{role.Nazwa}</div>
              <input
                type="checkbox"
                checked={editedUser.Roles.some((r) => r.Id === role.Id)}
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
