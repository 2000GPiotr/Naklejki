import React, { useState, useContext } from "react";
import { ItemRangeType, AddDocumentType } from "./DocumentTypes";
import { UserContext } from "./UserContext";
import ItemRangeCard from "./ItemRangeCard";
import { DocumentTypeContext } from "./DocumentTypeContext";
import { v4 } from 'uuid';
import { postData } from "../Helpers";
import { error } from "console";

const DocumentScreen = () => {
  const [documentTypeSymbol, setDocumentTypeSymbol] = useState("");
  const [year, setYear] = useState(new Date().getFullYear());
  const [number, setNumber] = useState(0);
  const [date, setDate] = useState(new Date());
  const [description, setDescription] = useState("");
  const [userId, setUserId] = useState<number | null>(null);
  const [itemsList, setItemsList] = useState<ItemRangeType[]>([]);
  
  const users = useContext(UserContext);
  const documentTypes = useContext(DocumentTypeContext);

  const handleItemRangeChange = (index: number, itemRange: ItemRangeType) => {
    setItemsList(prevItemsList => {
      const updatedItemsList = [...prevItemsList];
      updatedItemsList[index] = itemRange;
      return updatedItemsList;
    });
  };

  const handleAddItemRange = () => {
    setItemsList(prevItemsList => [...prevItemsList, 
        { 
          id: v4(),
          labelTypeSymbol: '',
          firstItem: {labelNumberPrefix: '', labelNumber: '', labelNumberSufix: ''}, 
          lastItem: {labelNumberPrefix: '', labelNumber: '', labelNumberSufix: ''} }]);
  };

  const handleRemoveItemRange = (itemId: string) => {
    setItemsList(prevItemsList => prevItemsList.filter(item => item.id !== itemId));
  };

  const handleSubmit = () => {
    const newDocument: AddDocumentType = {
      documentTypeSymbol,
      year,
      number,
      date,
      description,
      userId,
      itemsList,
    };

    // Wyślij dane do serwera lub wykonaj odpowiednie operacje
    console.log(newDocument);

    postData('http://localhost:5021/DocumentHeader', newDocument)
        .then(responseData => {
          console.log('Response:', responseData)
        })
        .catch(error => {
          console.log('Error: ', error);
        })
        .finally() //navigate 

    // Zresetuj stan formularza
    setDocumentTypeSymbol("");
    setYear(new Date().getFullYear());
    setNumber(0);
    setDate(new Date());
    setDescription("");
    setUserId(null);
    setItemsList([]);
  };

  return (
    <div>
      <div>
        Document Type Symbol:
        <select value={documentTypeSymbol} onChange={(e) => setDocumentTypeSymbol(e.target.value)}>
          <option value="">Select</option>
          {documentTypes.map((type) => (
            <option key={type.symbol} value={type.symbol}>
              {type.symbol}
            </option>
          ))}
        </select>
      </div>
      <div>
        Year:
        <input type="number" value={year} onChange={(e) => setYear(Number(e.target.value))} />
      </div>
      <div>
        Number:
        <input type="number" value={number} onChange={(e) => setNumber(Number(e.target.value))} />
      </div>
      <div>
        Date:
        <input type="date" value={date.toISOString().split("T")[0]} onChange={(e) => setDate(new Date(e.target.value))} />
      </div>
      <div>
        Description:
        <input type="text" value={description} onChange={(e) => setDescription(e.target.value)} />
      </div>
      <div>
        User:
        <select value={userId ? userId.toString() : ""} onChange={(e) => setUserId(Number(e.target.value))}>
          <option value="">Select</option>
          {users.map((user) => (
            <option key={user.id} value={user.id}>
              {user.name} {user.surname}
            </option>
          ))}
        </select>
      </div>
      <br/>
      <div>Item Ranges:</div>
      {itemsList.map((itemRange, index) => (
        <div key={itemRange.id}>
          <ItemRangeCard itemRange={itemRange} onChange={(updatedItemRange) => handleItemRangeChange(index, updatedItemRange)} />
          <button onClick={() => handleRemoveItemRange(itemRange.id)}>Remove</button>
        </div>
      ))}
      <button onClick={handleAddItemRange}>Add Item Range</button>
      <button onClick={handleSubmit}>Submit</button>
    </div>
  );
};

export default DocumentScreen;
