import React, { ReactNode, createContext, useEffect, useState } from "react";
import { fetchData } from "../Helpers";
import{ DocumentType} from "./DocumentTypes"

export const DocumentTypeContext = createContext<DocumentType[]>([]);

export const DocumentTypeProvider = ({ children }: {children: ReactNode;}) => {
  const [documentTypes, setDocumentTypes] = useState<DocumentType[]>([]);

  useEffect(() => {
    setDocumentTypes([{symbol:"D1", description: "Desc 1"}, {symbol:"D2", description: "Desc 2"}]);
  }, []);
  

  return (
    <DocumentTypeContext.Provider value={documentTypes}>
      {children}
    </DocumentTypeContext.Provider>
  );
};
