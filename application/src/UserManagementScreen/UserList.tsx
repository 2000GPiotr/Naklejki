import React, { useEffect, useState } from "react"
import {UpdateUserType, UserType} from './UserTypes'
import UserItem from './UserItem'
import { deleteData, fetchData } from "../Helpers"
import { useNavigate } from "react-router-dom"

const UserList = () => {
    const [users, setUsers] = useState<UserType[]>([]);
    
    const navigate = useNavigate();

    useEffect(() => {
      const controller = new AbortController();
      
      var init = async () => 
      {
        const url = 'http://localhost:5021/User';
        console.log('UserList render');

        const signal = controller.signal;

        try {
          var data = await fetchData(url, signal);
          console.log(data);
          setUsers(data);
        }
        catch (error) {
          console.error('Error fetching roles:', error);
        }
      }
      init();
      
      return () => {controller.abort()};
    }, []);

    /*
    useEffect(() => {
      const url = 'http://localhost:5021/User';
      console.log('UserList render');

      const controller = new AbortController();
      const signal = controller.signal;

      fetchData(url, signal)
        .then(data => {
          console.log(data);
          setUsers(data);
        })
        .catch(error => {
          console.error('Error fetching roles:', error);
        });
        return () => {controller.abort()};
    }, []);
    */

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
      navigate("Edit", {state: {user}});
    };

    const handleCreateUser = () => {
        navigate("Add");
    };

    const handleDeleteUser = (id: number) =>{
        const index = users.findIndex(u => u.id === id);
        const url = 'http://localhost:5021/User/' + id;
        deleteData(url)
          .then(responseData => {
            const deletedUser = responseData;
            console.log(deletedUser);
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
      </div>
    );
  }

  export default UserList;