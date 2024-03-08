import styled from '@emotion/styled';
import { Checkbox, FormControl, FormControlLabel } from '@mui/material';
import { ColorTypeEnum } from '../../lib/enums/ColorTypeEnum';

export const StyledCheckboxContainer = styled(FormControl)({
  '&.MuiFormControl-root': {
    border: 'none',
    minWidth: '120px',
    '&.Mui-disabled': {
      cursor: 'not-allowed',
    },
  },
  '& .MuiSelect-select.MuiSelect-select': {
    padding: 5,
    backgroundColor: ColorTypeEnum.Transparent,
  },
  '& .MuiSelect-select.MuiSelect-select:focus': {
    padding: 5,
    backgroundColor: ColorTypeEnum.Transparent,
  },
});

export const StyledCheckBoxLabel = styled(FormControlLabel)({
  alignItems: 'center',
  padding: '2.6px',
  '&.Mui-disabled': {
    cursor: 'not-allowed',
  },
});

export const StyledCheckBox = styled(Checkbox)({});
