import React from 'react';
import { IDropdownItem } from '../../../lib/interfaces/IDropdownItem';
import { SelectChangeEvent } from '@mui/material';
import {
  StyledDropdown,
  StyledDropdownContainer,
  StyledDropdownItem,
  StyledDropdownLabel,
} from '../../styledComponents/styledDropdowns';

interface IProps {
  property?: string;
  title: string;
  selectedItem: number;
  items: IDropdownItem[];
  width?: number;
  disabled?: boolean;
  fullWidth?: boolean;
  onItemChanged: (id: number, key?: any) => void;
}

const UnderlinedDropDown: React.FC<IProps> = (props) => {
  const {
    property,
    title,
    selectedItem,
    items,
    width,
    disabled,
    fullWidth,
    onItemChanged,
  } = props;

  const handleChange = React.useCallback(
    (e: SelectChangeEvent<unknown>) => {
      if (e.target.value !== undefined) {
        const value = parseInt(e.target.value as string);

        onItemChanged(value, property);
      }
    },
    [property, onItemChanged]
  );

  return (
    <StyledDropdownContainer
      disabled={disabled}
      variant="standard"
      fullWidth={fullWidth}
      sx={{ m: 1, minWidth: 200 }}
    >
      <StyledDropdownLabel>{title}</StyledDropdownLabel>
      <StyledDropdown
        style={{ width: `${width}rem` }}
        value={selectedItem === -1 ? '' : selectedItem}
        disabled={disabled}
        onChange={handleChange}
      >
        {items.map((item) => (
          <StyledDropdownItem
            key={item.id}
            value={item.id}
            disabled={item.disabled}
          >
            {item.value}
          </StyledDropdownItem>
        ))}
      </StyledDropdown>
    </StyledDropdownContainer>
  );
};

export default UnderlinedDropDown;
