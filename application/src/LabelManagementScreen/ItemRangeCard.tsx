import React, { useContext, useState } from 'react';
import { ItemType, ItemRangeType } from './DocumentTypes';
import {LabelTypeContext } from './Contexts/LabelTypeContext';

export type ItemRangeCardProps = {
  itemRange: ItemRangeType;
  onChange: (itemRange: ItemRangeType) => void;
};

const ItemRangeCard = (props: ItemRangeCardProps) => {
  const [itemRange, setItemRange] = useState<ItemRangeType>(props.itemRange);
  const labelTypes = useContext(LabelTypeContext);

  const saveChanges = (newItemRange: ItemRangeType) => {
    setItemRange(newItemRange);
    props.onChange(newItemRange);
  };

  const handleFirstItemChange = (field: keyof ItemType, value: string) => {
    const updatedFirstItem = {
      ...itemRange.firstItem,
      [field]: value
    };
    saveChanges({
      ...itemRange,
      firstItem: updatedFirstItem
    });
  };

  const handleLastItemChange = (field: keyof ItemType, value: string) => {
    const updatedLastItem = {
      ...itemRange.lastItem,
      [field]: value
    };
    saveChanges({
      ...itemRange,
      lastItem: updatedLastItem
    });
  };

  const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = event.target;
    handleFirstItemChange(name as keyof ItemType, value);
  };

  const handleLastItemInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = event.target;
    handleLastItemChange(name as keyof ItemType, value);
  };

  const handleCopyFields = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = event.target;
    const updatedLastItem = {
      ...itemRange.lastItem,
      [name]: value
    };
    saveChanges({
      ...itemRange,
      lastItem: updatedLastItem
    });
  };

  return (
    <div>
      <select
        onChange={(e) => {
          const newValue = e.target.value;
          setItemRange(prevRange => ({
            ...prevRange,
            labelTypeSymbol: newValue
          }));
          props.onChange({ // Jakoś ładniej?
            ...itemRange,
            labelTypeSymbol: newValue
          });
        }}
        value={itemRange.labelTypeSymbol}
      >
      <option value="none">Wybierz typ</option>
      {labelTypes.map(type => (
        <option key={type.symbol} value={type.symbol}>{type.symbol}</option>
      ))}
    </select>
      <div>
        <input
          type="text"
          name="labelNumberPrefix"
          value={itemRange.firstItem.labelNumberPrefix}
          onChange={handleInputChange}
          onBlur={handleCopyFields}
        />
        <input
          type="text"
          name="labelNumber"
          value={itemRange.firstItem.labelNumber}
          onChange={handleInputChange}
          onBlur={handleCopyFields}
        />
        <input
          type="text"
          name="labelNumberSufix"
          value={itemRange.firstItem.labelNumberSufix}
          onChange={handleInputChange}
          onBlur={handleCopyFields}
        />
      </div>
      <div>
        <input
          type="text"
          name="labelNumberPrefix"
          disabled
          value={itemRange.lastItem.labelNumberPrefix}
          onChange={handleLastItemInputChange}
        />
        <input
          type="text"
          name="labelNumber"
          value={itemRange.lastItem.labelNumber}
          onChange={handleLastItemInputChange}
        />
        <input
          type="text"
          name="labelNumberSufix"
          disabled
          value={itemRange.lastItem.labelNumberSufix}
          onChange={handleLastItemInputChange}
        />
      </div>
    </div>
  );
};

export default ItemRangeCard;
