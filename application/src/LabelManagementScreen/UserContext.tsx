import React, { ReactNode, createContext, useEffect, useState } from "react";
import { fetchData } from "../Helpers";
import { UserBaseType } from "../UserManagementScreen/UserTypes";

export const UserContext = createContext<UserBaseType[]>([]);

export const UserProvider = ({ children }: {children: ReactNode;}) => {
  const [documentTypes, setDocumentTypes] = useState<UserBaseType[]>([]);

  useEffect(() => {
    setDocumentTypes([
      {
        "id": 12,
        "name": "string",
        "surname": "1234",
      },
      {
        "id": 13,
        "name": "user",
        "surname": "user",
      },
      {
        "id": 14,
        "name": "admin",
        "surname": "admin",
      }
    ]);
  }, []);
  

  return (
    <UserContext.Provider value={documentTypes}>
      {children}
    </UserContext.Provider>
  );
};
