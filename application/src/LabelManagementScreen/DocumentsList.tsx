import React, { useEffect, useState } from "react";
import { DocumentHeaderType, UpdateDocumentType } from "./DocumentTypes";
import { useNavigate } from "react-router-dom";
import { fetchData } from "../Helpers";
import DocumentItem from "./DocumentItem";

const DocumentList = () => {
    const [documents, setDocuments] = useState<DocumentHeaderType[]>([]);

    const navigate = useNavigate();

    useEffect(() => {
        const controller = new AbortController();
        
        var init = async () => 
        {
          const url = 'http://localhost:5021/DocumentHeader';
          console.log('DocumentList render');
  
          const signal = controller.signal;
  
          try {
            var data = await fetchData(url, signal);
            console.log(data);
            setDocuments(data);
          }
          catch (error) {
            console.error('Error fetching documents:', error);
          }
        }
        init();
        
        return () => {controller.abort()};
      }, []);

      const handleCreateDocument = () => {
        navigate("Add");
      }

      const editDocumentHeader = (documentHeader: UpdateDocumentType) => {
        navigate("Edit", {state: {documentHeader}});
      }

      const deleteDocumentHeader = (id: number) => {

      }

      const documentList = documents.map(d => (
        <DocumentItem key = {d.id} documentHeader={d} edit={editDocumentHeader} delete={deleteDocumentHeader} />
      ));

    return(
        <div>
            <h1>Documents</h1>
            <button onClick={handleCreateDocument}>Add Document</button>
            {documentList}
        </div>
    )
}

export default DocumentList;