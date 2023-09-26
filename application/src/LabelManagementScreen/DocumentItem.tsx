import { DocumentHeaderType, UpdateDocumentType } from "./DocumentTypes";
import './Styles/DocumentManagementScreen.css';
import { useState } from "react";

type PropsType = {
    documentHeader: DocumentHeaderType;
    edit: (document: UpdateDocumentType) => void;
    delete: (id: number) => void;
};

const DocumentItem = (props: PropsType) => {
    const {documentHeader} = props;

    const[showDetails, setShowDetails] = useState<boolean>(false);
    const[showItemList, setShowItemList] = useState<boolean>(false);

    const updateDocument: UpdateDocumentType = {
        id: documentHeader.id,
        documentType: documentHeader.documentType,
        userId: documentHeader.user ? documentHeader.user.id ?? null : null,
        year: documentHeader.year,
        number: documentHeader.number,
        date: documentHeader.date,
        description: documentHeader.description
    }

    const toogleDetailsShow = () => setShowDetails(!showDetails);

    const toogleItemListShow = () => setShowItemList(!showItemList);

    const editDocument = () => props.edit(updateDocument);

    const documentItemList = (
        <div>
            <h4>Items:</h4>
            <ul>
                {documentHeader.itemList.map((i) => (
                <li key={i.labelTypeSymbol + i.labelNumberPrefix + i.labelNumber + i.labelNumberSufix}>
                    {i.labelTypeSymbol}- {i.labelNumberPrefix} {i.labelNumber}{" "}
                    {i.labelNumberSufix}
                </li>
                ))}
             </ul>
         </div>
    );

    const documentDetails = (
      <div>
        <h4>Details:</h4>
        <div>{documentHeader.documentType.symbol}</div>
        <div>{documentHeader.description}</div>
        <div>{documentHeader.year}</div>
        <div>{documentHeader.number}</div>
        <div>{new Date(documentHeader.date).toISOString().split("T")[0]}</div>
        <div>{documentHeader.user?.name}</div>
      </div>
    );

    return(
        <div className="documentCard">
            <div>
                <h3>{documentHeader.id + ' - ' + documentHeader.documentType.symbol + ' ' + documentHeader.year + ' ' + documentHeader.number}</h3>
                {showDetails ? documentDetails : null}
                
                {showItemList ? documentItemList : null}
            </div>
            <button onClick={toogleDetailsShow}>Details</button>
            <button onClick={toogleItemListShow}>Item List</button>
            <button onClick={editDocument}>Edit</button>
            <button>Delete</button>
        </div>
    )
}

export default DocumentItem;