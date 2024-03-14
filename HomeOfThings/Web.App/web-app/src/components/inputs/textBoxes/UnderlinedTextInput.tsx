import React from 'react';
import { StyledInput } from '../../styledComponents/StyledInputs';
import { InputAdornment } from '@mui/material';

interface IProps {
  property: string;
  disabled?: boolean;
  fullWidth?: boolean;
  title?: string;
  value: string;
  type?: 'text' | 'password';
  unit?: string;
  alignValue?: 'start' | 'center' | 'end';
  padding?: number;
  handleChange: (value: string, key: any) => void;
}

const UnderlinedTextInput: React.FC<IProps> = (props) => {
  const {
    property,
    disabled,
    fullWidth,
    title,
    type,
    value,
    unit,
    alignValue,
    padding,
    handleChange,
  } = props;

  const onChange = React.useCallback(
    (e: React.ChangeEvent<HTMLInputElement>) => {
      handleChange(e.currentTarget.value as string, property);
    },
    [handleChange, property]
  );

  const styles = {
    input: {
      '&::placeholder': {
        padding: `${20}px`,
      },
    },
  };

  return (
    <StyledInput
      style={{ padding: `${padding}px` }}
      type={type}
      disabled={disabled}
      fullWidth={fullWidth}
      label={title}
      value={value}
      InputLabelProps={{
        style: { paddingLeft: `${padding ?? 0 + 2}px` },
      }}
      InputProps={{
        endAdornment: <InputAdornment position="end">{unit}</InputAdornment>,
        inputProps: {
          classes: { input: styles.input },
          min: 0,
          style: {
            textAlign: alignValue ?? 'end',
          },
        },
      }}
      variant="standard"
      onChange={onChange}
    />
  );
};

export default UnderlinedTextInput;
