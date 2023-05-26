import React, { useContext, useEffect, useState } from "react"
import {CreateUserType, UpdateUserType, UserType} from './UserTypes'
import UserItem from './UserItem'
import UserEdit from "./UserEdit"
import UserAdd from "./UserAdd"
import { deleteData, fetchData } from "./Helpers"
import { RoleContext } from "./RoleContext"



const UserList = () => {
    const [users, setUsers] = useState<UserType[]>([]);

    const [userToUpdate, setUserToUpdate] = useState<UpdateUserType | undefined>(undefined);
    const [userToCreate, setUserToCreate] = useState<CreateUserType | undefined>(undefined);

    useEffect(() => {
      const url = 'http://localhost:5021/User';
      console.log('UserList render');
      fetchData(url)
        .then(data => {
          console.log(data);
          setUsers(data);
        })
        .catch(error => {
          console.error('Error fetching roles:', error);
        });
    }, []);


    const details = (id:number) => {
        const index = users.findIndex(x => x.id === id);
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
            name: '',
            surname: '',
            login: '',
            password: '',
            rolesId: [],
         }
         setUserToCreate(newUser);
    };

    const handleSave = (user: UserType) => {
      const index = users.findIndex(u => u.id === user.id);
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
        const index = users.findIndex(u => u.id === id);
        const url = 'http://localhost:5021/User/' + id;
        deleteData(url)
          .then(responseData => {
            const deletedUsers = responseData;
          })
          .catch(error => {
            console.error('Error:', error);
          });
        const newUsers = [...users];
        newUsers.splice(index, 1);
        setUsers(newUsers);
    }

    const usersList = users.map(u => (
      <UserItem key = {u.id} user={u} details={details} edit={handleEditUser} delete={handleDeleteUser}/>
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