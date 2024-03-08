import React from 'react';
import {
  StyledDatePicker,
  StyledDatePickerContainer,
} from '../../styledComponents/StyledDateInputs';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import dayjs from 'dayjs';

interface IProps {
  property: string;
  date: number | null;
  disableFuture?: boolean;
  disabled?: boolean;
  fullWidth?: boolean;
  handleDateChanged: (date: number, key: any) => void;
}

const DateInput: React.FC<IProps> = (props) => {
  const {
    date,
    property,
    disabled,
    fullWidth,
    disableFuture,
    handleDateChanged,
  } = props;

  const handleChange = React.useCallback(
    (date: unknown) => {
      handleDateChanged(date as number, property);
    },
    [property, handleDateChanged]
  );

  return (
    <StyledDatePickerContainer
      disabled={disabled}
      variant="standard"
      fullWidth={fullWidth}
      style={{
        display: 'flex',
        alignItems: 'flex-end',
      }}
      sx={{ m: 1, minWidth: 200 }}
    >
      <LocalizationProvider dateAdapter={AdapterDayjs}>
        <StyledDatePicker
          key="TEst-Picker"
          className="test"
          disableFuture={disableFuture}
          slotProps={{ textField: { variant: 'standard' } }}
          defaultValue={dayjs(new Date().toString())}
          value={dayjs(date)}
          onChange={handleChange}
        />
      </LocalizationProvider>
    </StyledDatePickerContainer>
  );
};

export default DateInput;
