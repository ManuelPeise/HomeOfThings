import styled from '@emotion/styled';
import { FormControl, TextField } from '@mui/material';
import { ColorTypeEnum } from '../../lib/enums/ColorTypeEnum';

export const StyledInputContainer = styled(FormControl)({
  '& .MuiInputBase-root': {
    border: 'none',
    minWidth: '120px',
    justifyContent: 'center',
    '& .Mui-disabled': {
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

export const StyledInput = styled(TextField)({
  '&.MuiInputBase-input': {
    color: 'blue',
    fontSize: '1.5rem',
    cursor: 'pointer',
    opacity: 0.7,
    '&.MuiInput-input': {
      '&.Mui-disabled': {
        opacity: 0.5,
        cursor: 'not-allowed',
        backgroundColor: 'red',
      },
    },
    '&:focus': {
      opacity: 1,
      cursor: 'text',
    },
  },
});
