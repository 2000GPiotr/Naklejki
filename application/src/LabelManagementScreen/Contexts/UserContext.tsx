import React, { ReactNode, createContext, useEffect, useState } from "react";
import { fetchData } from "../../Helpers";
import { UserBaseType, UserType } from "../../UserManagementScreen/UserTypes";

export const UserContext = createContext<UserBaseType[]>([]);

export const UserProvider = ({ children }: {children: ReactNode;}) => {
  const [users, setUsers] = useState<UserBaseType[]>([]);

  const fetchUsers = (signal: AbortSignal) => {
    const url = "http://localhost:5021/User";
    return fetchData(url, signal);
  };

  useEffect(() => {

    const controller = new AbortController();
    const signal = controller.signal;

    fetchUsers(signal)
      .then((data) => {
        const mappedUsers: UserBaseType[] = data.map((user: UserType) => ({
          id: user.id,
          name: user.name,
          surname: user.surname,
          ShowDetails: false,
        }));
        setUsers(mappedUsers);
      })
      .catch((error) => console.error("Error fetching users:", error));
      return () => {controller.abort()};
  }, []);

  return (
    <UserContext.Provider value={users}>
      {children}
    </UserContext.Provider>
  );
};
