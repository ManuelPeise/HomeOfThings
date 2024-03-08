import React from 'react';
import {
  StyledInput,
  StyledInputContainer,
} from '../../styledComponents/StyledInputs';
import { InputAdornment } from '@mui/material';
import { isNumberInput, isValidNumber } from '../../../lib/validation';

interface IProps {
  property: string;
  tempValueProperty: string;
  disabled?: boolean;
  fullWidth?: boolean;
  title?: string;
  value: number;
  tempValue: string;
  unit?: string;
  alignValue?: 'start' | 'center' | 'end';
  handleChange: (value: number, key: any) => void;
  handleTempValueChange: (value: string, key: any) => void;
}

const UnderlinedNumberInput: React.FC<IProps> = (props) => {
  const {
    property,
    tempValueProperty,
    disabled,
    fullWidth,
    title,
    value,
    tempValue,
    unit,
    alignValue,
    handleChange,
    handleTempValueChange,
  } = props;

  const [inputValue, setInputValue] = React.useState<string>('0');

  React.useEffect(() => {
    setInputValue(value === 0 ? '' : value.toString());
  }, [value]);

  React.useEffect(() => {
    if (!tempValue.length) {
      setInputValue('');
    }
  }, [tempValue]);

  const onChange = React.useCallback(
    (e: React.ChangeEvent<HTMLInputElement>) => {
      e.preventDefault();

      const { isNumber, enforcedValue, inputValue } = isNumberInput(
        e.target.value
      );

      if (isNumber) {
        setInputValue(inputValue);
        handleTempValueChange(enforcedValue, tempValueProperty);
        if (isValidNumber(inputValue.replace(',', '.'))) {
          handleChange(parseFloat(enforcedValue), property);
        }
      }
    },
    [property, tempValueProperty, handleChange, handleTempValueChange]
  );

  return (
    <StyledInputContainer
      disabled={disabled}
      variant="standard"
      fullWidth={fullWidth}
      sx={{ m: 1, minWidth: 200 }}
    >
      <StyledInput
        type="text"
        disabled={disabled}
        fullWidth={fullWidth}
        label={title}
        value={inputValue}
        InputProps={{
          endAdornment: <InputAdornment position="end">{unit}</InputAdornment>,
          inputProps: {
            min: 0,
            style: { paddingRight: 1, textAlign: alignValue ?? 'end' },
          },
        }}
        variant="standard"
        onChange={onChange}
      />
    </StyledInputContainer>
  );
};

export default UnderlinedNumberInput;
