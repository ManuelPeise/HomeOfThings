import styled from '@emotion/styled';
import { FormControl, InputLabel, MenuItem, Select } from '@mui/material';
import { ColorTypeEnum } from '../../lib/enums/ColorTypeEnum';

export const StyledDropdownContainer = styled(FormControl)({
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

export const StyledDropdownLabel = styled(InputLabel)({
  fontSize: '1.1rem',
  fontWeight: '500',
  color: ColorTypeEnum.Blue,
});

export const StyledDropdown = styled(Select)({
  width: 'auto',
  fontSize: '1.1rem',
  color: ColorTypeEnum.Gray,
  fontWeight: '500',
});

export const StyledDropdownItem = styled(MenuItem)({
  '&.MuiButtonBase-root': {
    backgroundColor: ColorTypeEnum.White,
    '&.Mui-selected': {
      backgroundColor: ColorTypeEnum.LightGray,
      opacity: 0.5,
    },
    '&:hover': {
      backgroundColor: ColorTypeEnum.LightGray,
    },
    '& .Mui-disabled': {
      cursor: 'not-allowed',
    },
  },
});
