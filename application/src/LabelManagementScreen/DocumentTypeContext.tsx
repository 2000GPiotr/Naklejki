import React, { ReactNode, createContext, useEffect, useState } from "react";
import { fetchData } from "../Helpers";
import{ DocumentType} from "./DocumentTypes"

export const DocumentTypeContext = createContext<DocumentType[]>([]);

export const DocumentTypeProvider = ({ children }: {children: ReactNode;}) => {
  const [documentTypes, setDocumentTypes] = useState<DocumentType[]>([]);

  const fetchDocumentTypes = (signal: AbortSignal) => {
    const url = "http://localhost:5021/DocumentType";
    return fetchData(url, signal);
  };

  useEffect(() => {

    const controller = new AbortController();
    const signal = controller.signal;

    fetchDocumentTypes(signal)
      .then((data) => setDocumentTypes(data))
      .catch((error) => console.error("Error fetching roles:", error));
      return () => {controller.abort()};
  }, []);

  return (
    <DocumentTypeContext.Provider value={documentTypes}>
      {children}
    </DocumentTypeContext.Provider>
  );
};
