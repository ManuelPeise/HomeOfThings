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
  date: string;
  minDate?: string;
  disableFuture?: boolean;
  disabled?: boolean;
  fullWidth?: boolean;
  title?: string;
  paddingRight?: number;
  paddingLeft?: number;

  handleDateChanged: (date: string, key: any) => void;
}

const DateInput: React.FC<IProps> = (props) => {
  const {
    date,
    minDate,
    property,
    disabled,
    fullWidth,
    disableFuture,
    title,
    paddingLeft,
    paddingRight,
    handleDateChanged,
  } = props;

  return (
    <StyledDatePickerContainer
      disabled={disabled}
      variant="standard"
      fullWidth={fullWidth}
      style={{
        paddingRight: `${paddingRight}px`,
        paddingLeft: `${paddingLeft}px`,
      }}
      sx={{ m: 1, minWidth: 200 }}
    >
      <LocalizationProvider dateAdapter={AdapterDayjs}>
        <StyledDatePicker
          disableFuture={disableFuture}
          label={title}
          format="DD/MM/YYYY"
          slotProps={{ textField: { variant: 'standard' } }}
          minDate={dayjs(date)}
          value={minDate && dayjs(minDate)}
          onChange={(value) => {
            handleDateChanged(value as string, property);
          }}
        />
      </LocalizationProvider>
    </StyledDatePickerContainer>
  );
};

export default DateInput;
