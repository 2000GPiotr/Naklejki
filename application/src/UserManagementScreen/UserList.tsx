import React, { useState } from "react"
import {UserType} from './UserTypes'
import UserItem from './UserItem'
import UserEdit from "./UserEdit"


const UserList = () => {
    const [users, setUsers] = useState<UserType[]>([
      {Id: 1, Name: 'Jan', Surname: 'Kowalski', Roles: ['admin', 'user'], ShowDetails: false},
      {Id: 2, Name: 'Anna', Surname: 'Nowak', Roles: ['admin', 'user', 'magasinier'], ShowDetails: false},
      {Id: 3, Name: 'Krzysztof', Surname: 'Dąb', Roles: ['user'], ShowDetails: false}
    ]);
    const [selectedUser, setSelectedUser] = useState<UserType | undefined>(undefined);

    const details = (id:number) => {
        const index = users.findIndex(x => x.Id === id);
        const newUsers = [...users];
        newUsers[index] = {
            ...newUsers[index],
            ShowDetails: !newUsers[index].ShowDetails
        };
        setUsers(newUsers);
    };

    const handleEditUser = (user: UserType) => {
        setSelectedUser(user);
      };

      const handleSave = (user: UserType) => {
        const index = users.findIndex((u) => u.Id === user.Id);
        if (index !== -1) {
          const newUsers = [...users];
          newUsers[index] = user;
          setUsers(newUsers);
        }
        setSelectedUser(undefined);
      };

    const usersList = users.map(u => (
      <UserItem user={u} details={details} edit={handleEditUser}/>
    ));
  
    return (
      <div>
        <h1>Users</h1>
        {usersList}
        {selectedUser && (
        <UserEdit user={selectedUser} onSave={handleSave} onClose={() => setSelectedUser(undefined)} />
        )}
      </div>
    );
  }

  export default UserList;