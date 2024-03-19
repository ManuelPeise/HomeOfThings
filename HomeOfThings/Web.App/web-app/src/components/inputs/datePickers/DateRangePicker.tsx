import React from 'react';
import {
  StyledDatePicker,
  StyledDatePickerContainer,
} from '../../styledComponents/StyledDateInputs';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { LocalizationProvider } from '@mui/x-date-pickers';
import dayjs from 'dayjs';

export interface IDateInputProps {
  property: string;
  date: string;
  disableFuture?: boolean;
  disabled?: boolean;
  fullWidth?: boolean;
  title?: string;
  paddingRight?: number;
  paddingLeft?: number;
  handleDateChanged: (date: string, key: any) => void;
}

interface IProps {
  from: IDateInputProps;
  to: IDateInputProps;
  hasMinDate?: boolean;
}

const DateRangeInput: React.FC<IProps> = (props) => {
  const { from, to, hasMinDate } = props;

  return (
    <div style={{ display: 'flex', flexDirection: 'row' }}>
      <StyledDatePickerContainer
        disabled={from.disabled}
        variant="standard"
        fullWidth={from.fullWidth}
        style={{
          paddingRight: `${from.paddingRight}px`,
          paddingLeft: `${from.paddingLeft}px`,
        }}
        sx={{ m: 1, minWidth: 200 }}
      >
        <LocalizationProvider dateAdapter={AdapterDayjs}>
          <StyledDatePicker
            disableFuture={from.disableFuture}
            label={from.title}
            format="DD/MM/YYYY"
            slotProps={{ textField: { variant: 'standard' } }}
            value={dayjs(from.date)}
            onChange={(value) => {
              console.log(value);
              from.handleDateChanged(value as string, from.property);
            }}
          />
        </LocalizationProvider>
      </StyledDatePickerContainer>
      <StyledDatePickerContainer
        disabled={to.disabled}
        variant="standard"
        fullWidth={to.fullWidth}
        style={{
          paddingRight: `${to.paddingRight}px`,
          paddingLeft: `${to.paddingLeft}px`,
        }}
        sx={{ m: 1, minWidth: 200 }}
      >
        <LocalizationProvider dateAdapter={AdapterDayjs}>
          <StyledDatePicker
            disableFuture={to.disableFuture}
            label={to.title}
            format="DD/MM/YYYY"
            slotProps={{ textField: { variant: 'standard' } }}
            minDate={hasMinDate && dayjs(from.date)}
            value={dayjs(to.date)}
            onChange={(value) => {
              to.handleDateChanged(value as string, to.property);
            }}
          />
        </LocalizationProvider>
      </StyledDatePickerContainer>
    </div>
  );
};

export default DateRangeInput;
