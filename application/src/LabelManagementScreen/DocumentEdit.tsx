import React, { useContext, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { UpdateDocumentType } from "./DocumentTypes";
import { UserContext } from "./Contexts/UserContext";
import { putData } from "../Helpers";

const DocumentEdit = () => {
  const location = useLocation();
  const documentHeader = location.state.documentHeader;
  const users = useContext(UserContext);

  const [editedDocumentHeader, setEditedDocumentHeader] = useState<UpdateDocumentType>({
    id: documentHeader.id,
    year: documentHeader.year,
    number: documentHeader.number,
    date: documentHeader.date || new Date(),
    description: documentHeader.description,
    userId: documentHeader.userId ? documentHeader.userId : null,
  });

  const navigate = useNavigate();
  
  const handleYearChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setEditedDocumentHeader((prevHeader) => ({
      ...prevHeader,
      year: parseInt(e.target.value, 10),
    }));
  };

  const handleNumberChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setEditedDocumentHeader((prevHeader) => ({
      ...prevHeader,
      number: parseInt(e.target.value, 10),
    }));
  };

  const handleDateChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setEditedDocumentHeader((prevHeader) => ({
      ...prevHeader,
      date: new Date(e.target.value),
    }));
  };

  const handleDescriptionChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setEditedDocumentHeader((prevHeader) => ({
      ...prevHeader,
      description: e.target.value,
    }));
  };

  const handleUserChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
    const selectedUserId = parseInt(e.target.value, 10);
    setEditedDocumentHeader((prevHeader) => ({
      ...prevHeader,
      userId: selectedUserId,
    }));
  };

  const handleCancle = () => {
    navigate("/Documents");
  };

  const handleSave = () => {
    const url = 'http://localhost:5021/DocumentHeader/' + editedDocumentHeader.id;

    putData(url, editedDocumentHeader)
        .then(responseData => {
            console.log("ResponseData: ", responseData);
        })
        .catch(error => {
            console.error('Error: ', error);
        })
        .finally(() => navigate("/Documents"));
  };

  return (
    <div>
        <div>
        <h2>Edit Document</h2>
        <label>
            Year:
            <input
            type="number"
            value={editedDocumentHeader.year}
            onChange={handleYearChange}
            />
        </label>
        <br />
        <label>
            Number:
            <input
            type="number"
            value={editedDocumentHeader.number}
            onChange={handleNumberChange}
            />
        </label>
        <br />
        <label>
            Date:
            <input
            type="date"
            value={new Date(editedDocumentHeader.date).toISOString().split("T")[0]}
            onChange={handleDateChange}
            />
        </label>
        <br />
        <label>
            Description:
            <input
            type="text"
            value={editedDocumentHeader.description}
            onChange={handleDescriptionChange}
            />
        </label>
        <br />
        <label>
            User:
            <select
                value={editedDocumentHeader.userId ? editedDocumentHeader.userId.toString() : "35"}
                onChange={handleUserChange}
            >                
                {users.map((user) => (
                    <option key={user.id} value={user.id}>
                        {user.name} {user.surname}
                    </option>
                ))}
                <option value="-1">Select</option>
            </select>
        </label>
        </div>
        <button onClick={handleSave}>Save</button>
        <button onClick={handleCancle}>Cancle</button>
    </div>
  );
};

export default DocumentEdit;
