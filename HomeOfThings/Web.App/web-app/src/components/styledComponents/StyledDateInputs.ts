import styled from '@emotion/styled';
import { FormControl } from '@mui/material';
import { DatePicker } from '@mui/x-date-pickers';
import { ColorTypeEnum } from '../../lib/enums/ColorTypeEnum';

export const StyledDatePickerContainer = styled(FormControl)({
  '&.MuiFormControl-root': {
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

export const StyledDatePicker = styled(DatePicker)({});
