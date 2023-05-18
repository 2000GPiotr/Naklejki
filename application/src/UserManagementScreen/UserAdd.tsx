import React, { useState } from "react";
import { UserType } from "./UserTypes";
import './UserManagementScreen.css'

type PropsType = {
    user: UserType;
    onSave: (user: UserType) => void;
    onClose: () => void;
};

const UserAdd = (props: PropsType) => {
    const [editedUser, setEditedUser] = useState<UserType>({ ...props.user });
  
    const handleSave = () => {
      props.onSave(editedUser);
      props.onClose();
    };
  
    const handleCancel = () => {
      props.onClose();
    };
    
    const handleRoleChange = (role: string, isChecked: boolean) => {
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
          <h2>Add user</h2>
          <label>
            Name:
            <input type="text" value={editedUser.Name} onChange={(e) => setEditedUser({ ...editedUser, Name: e.target.value })} />
          </label>
          <label>
            Surname:
            <input type="text" value={editedUser.Surname} onChange={(e) => setEditedUser({ ...editedUser, Surname: e.target.value })} />
          </label>
          <div>
          <p>Roles:</p>
          {["admin", "user", "magasinier"].map((role) => (
            <label className="checkboxInput" key={role}>
            <div>{role}</div>
              <input
                type="checkbox"
                checked={editedUser.Roles.includes(role)}
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
