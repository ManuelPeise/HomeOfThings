import React from "react";
import { StyledInput } from "../../styledComponents/StyledInputs";
import { InputAdornment } from "@mui/material";

interface IProps {
  property: string;
  disabled?: boolean;
  fullWidth?: boolean;
  title?: string;
  value: string;
  type?: "text" | "password";
  unit?: string;
  alignValue?: "start" | "center" | "end";
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
    handleChange,
  } = props;

  const onChange = React.useCallback(
    (e: React.ChangeEvent<HTMLInputElement>) => {
      handleChange(e.currentTarget.value as string, property);
    },
    [handleChange, property]
  );

  return (
    <StyledInput
      type={type}
      disabled={disabled}
      fullWidth={fullWidth}
      label={title}
      value={value}
      InputProps={{
        endAdornment: <InputAdornment position="end">{unit}</InputAdornment>,
        inputProps:{
          min: 0,
          style: { paddingRight: 1, textAlign: alignValue ?? "end" },
        }
      }}
      variant="standard"
      onChange={onChange}
    />
  );
};

export default UnderlinedTextInput;
