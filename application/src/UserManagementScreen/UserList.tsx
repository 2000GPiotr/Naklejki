import React, { useState } from "react"
import {CreateUserType, UpdateUserType, UserType} from './UserTypes'
import UserItem from './UserItem'
import UserEdit from "./UserEdit"
import UserAdd from "./UserAdd"


const UserList = () => {
    const [users, setUsers] = useState<UserType[]>([
      {Id: 1, Login: 'JK', Name: 'Jan', Surname: 'Kowalski', Roles: [{Id: 1, Nazwa: 'Admin', Description: 'Opis a'}, {Id: 2, Nazwa: 'User', Description: 'Opis u'}], ShowDetails: false},
      {Id: 2, Login: 'AN', Name: 'Anna', Surname: 'Nowak', Roles: [{Id: 2, Nazwa: 'User', Description: 'Opis u'}], ShowDetails: false},
      {Id: 3, Login: 'KD', Name: 'Krzysztof', Surname: 'Dąb', Roles: [{Id: 2, Nazwa: 'User', Description: 'Opis u'}], ShowDetails: false}
    ]);
    const [userToUpdate, setUserToUpdate] = useState<UpdateUserType | undefined>(undefined);

    const [userToCreate, setUserToCreate] = useState<CreateUserType | undefined>(undefined);

    const details = (id:number) => {
        const index = users.findIndex(x => x.Id === id);
        const newUsers = [...users];
        newUsers[index] = {
            ...newUsers[index],
            ShowDetails: !newUsers[index].ShowDetails
        };
        setUsers(newUsers);
    };

    const handleEditUser = (user: UpdateUserType) => {
      setUserToUpdate(user);
    };

    const handleCreateUser = () => {
        const newUser:CreateUserType = {
            Name: '',
            Surname: '',
            Login: '',
            Password: '',
            Roles: [],
         }
         setUserToCreate(newUser);
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
      setUserToCreate(undefined);
      setUserToUpdate(undefined);
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
        <button onClick={() => handleCreateUser()}>Add new user</button>
        {usersList}
        {userToUpdate && (
        <UserEdit user={userToUpdate} onSave={handleSave} onClose={() => setUserToUpdate(undefined)} />
        )}
        {userToCreate && (
        <UserAdd user={userToCreate} onSave={handleSave} onClose={() => setUserToCreate(undefined)} />
        )}
      </div>
    );
  }

  export default UserList;