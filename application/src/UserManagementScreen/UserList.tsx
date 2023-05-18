import React, { useState } from "react"
import {UserType} from './UserTypes'
import UserItem from './UserItem'
import UserEdit from "./UserEdit"
import UserAdd from "./UserAdd"


const UserList = () => {
    const [users, setUsers] = useState<UserType[]>([
      {Id: 1, Name: 'Jan', Surname: 'Kowalski', Roles: ['admin', 'user'], ShowDetails: false},
      {Id: 2, Name: 'Anna', Surname: 'Nowak', Roles: ['admin', 'user', 'magasinier'], ShowDetails: false},
      {Id: 3, Name: 'Krzysztof', Surname: 'Dąb', Roles: ['user'], ShowDetails: false}
    ]);
    const [selectedUser, setSelectedUser] = useState<UserType | undefined>(undefined);

    const [addUser, setAddUser] = useState<boolean>(true);

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
        setAddUser(false);
        setSelectedUser(user);
      };

    const handleAddUser = () => {
        setAddUser(true);
        const newUser:UserType = {
            Id: Math.random(),
            Name: '',
            Surname: '',
            Roles: ['user'],
            ShowDetails: false
         }
         setSelectedUser(newUser);
    };

    const handleSave = (user: UserType) => {
      const index = users.findIndex(u => u.Id === user.Id);
      if (index !== -1) {
        const newUsers = [...users];
        newUsers[index] = user;
        setUsers(newUsers);
      }
      else{
        const newUsers = [...users, user];
        setUsers(newUsers);
      }
      setSelectedUser(undefined);
    };

    const handleDeleteUser = (id: number) =>{
        const index = users.findIndex(u => u.Id === id);
        const newUsers = [...users];
        const deletedUsers = newUsers.splice(index, 1);
        setUsers(newUsers);
    }

    const usersList = users.map(u => (
      <UserItem user={u} details={details} edit={handleEditUser} delete={handleDeleteUser}/>
    ));
  
    return (
      <div>
        <h1>Users</h1>
        <button onClick={() => handleAddUser()}>Add new user</button>
        {usersList}
        {selectedUser && !addUser && (
        <UserEdit user={selectedUser} onSave={handleSave} onClose={() => setSelectedUser(undefined)} />
        )}
        {selectedUser && addUser && (
        <UserAdd user={selectedUser} onSave={handleSave} onClose={() => setSelectedUser(undefined)} />
        )}
      </div>
    );
  }

  export default UserList;