import React from 'react';
import {
  StyledCheckBox,
  StyledCheckBoxLabel,
  StyledCheckboxContainer,
} from '../../styledComponents/StyledCheckBoxes';

interface IProps {
  property: string;
  fullWidth?: boolean;
  checked: boolean;
  disabled?: boolean;
  label: string;
  handleChange: (checked: boolean, key: any) => void;
}

const SingleCheckbox: React.FC<IProps> = (props) => {
  const { checked, disabled, label, property, fullWidth, handleChange } = props;

  const onChange = React.useCallback(
    (e: React.ChangeEvent<HTMLInputElement>, checked: boolean) => {
      handleChange(checked, property);
    },
    [property, handleChange]
  );

  return (
    <StyledCheckboxContainer
      disabled={disabled}
      variant="standard"
      fullWidth={fullWidth}
      style={{
        display: 'flex',
        justifyItems: 'center',
        alignItems: 'center',
      }}
      sx={{ m: 1, minWidth: 200 }}
    >
      <StyledCheckBoxLabel
        label={label}
        disabled={disabled}
        control={<StyledCheckBox checked={checked} onChange={onChange} />}
      />
    </StyledCheckboxContainer>
  );
};

export default SingleCheckbox;
