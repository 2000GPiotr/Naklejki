import React, { useContext, useState } from 'react';
import { ItemType, ItemRangeType } from './DocumentTypes';
import {LabelTypeContext } from './LabelTypeContext';

export type ItemRangeCardProps = {
  itemRange: ItemRangeType;
  onChange: (itemRange: ItemRangeType) => void;
};

const ItemRangeCard = ({ itemRange, onChange }: ItemRangeCardProps) => {
  const [firstItem, setFirstItem] = useState<ItemType>(itemRange.firstItem);
  const [lastItem, setLastItem] = useState<ItemType>(itemRange.lastItem);
  const labelTypes = useContext(LabelTypeContext);

  const handleFirstItemChange = (field: keyof ItemType, value: string) => {
    setFirstItem(prevItem => ({
      ...prevItem,
      [field]: value,
    }));
  };

  const handleLastItemChange = (field: keyof ItemType, value: string) => {
    setLastItem(prevItem => ({
      ...prevItem,
      [field]: value,
    }));
  };

  const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = event.target;
    handleFirstItemChange(name as keyof ItemType, value);
  };

  const handleLastItemInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = event.target;
    handleLastItemChange(name as keyof ItemType, value);
  };

  const handleCopyFields = () => {
    setLastItem(prevLastItem => ({
        ...prevLastItem,
        labelTypeSymbol: firstItem.labelTypeSymbol,
        labelNumberPrefix: firstItem.labelNumberPrefix,
        labelNumber: firstItem.labelNumber,
        labelNumberSufix: firstItem.labelNumberSufix,
      }));
  };

  return (
    <div>
      <div>
        <select
          onChange={event => handleFirstItemChange('labelTypeSymbol', event.target.value)}
        >
            <option value="none" selected disabled hidden>Wybierz typ</option>
          {labelTypes.map(type => (
            <option key={type.symbol} value={type.symbol}>{type.symbol}</option>
          ))}
        </select>
        <input
          type="text"
          name="labelNumberPrefix"
          value={firstItem.labelNumberPrefix}
          onChange={handleInputChange}
          onBlur={handleCopyFields}
        />
        <input
          type="text"
          name="labelNumber"
          value={firstItem.labelNumber}
          onChange={handleInputChange}
          onBlur={handleCopyFields}
        />
        <input
          type="text"
          name="labelNumberSufix"
          value={firstItem.labelNumberSufix}
          onChange={handleInputChange}
          onBlur={handleCopyFields}
        />
      </div>
      <div>
        <span>{firstItem.labelTypeSymbol}</span>
        <input
          type="text"
          name="labelNumberPrefix"
          disabled
          value={lastItem.labelNumberPrefix}
          onChange={handleLastItemInputChange}
        />
        <input
          type="text"
          name="labelNumber"
          value={lastItem.labelNumber}
          onChange={handleLastItemInputChange}
        />
        <input
          type="text"
          name="labelNumberSufix"
          disabled
          value={lastItem.labelNumberSufix}
          onChange={handleLastItemInputChange}
        />
        <button onClick={handleCopyFields}>Copy Fields</button>
      </div>
    </div>
  );
};

export default ItemRangeCard;
