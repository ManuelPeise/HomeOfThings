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
  date: Date | number | null;
  disableFuture?: boolean;
  disabled?: boolean;
  fullWidth?: boolean;
  title?: string;
  paddingRight?: number;
  paddingLeft?: number;
  handleDateChanged: (date: Date, key: any) => void;
}

const DateInput: React.FC<IProps> = (props) => {
  const {
    date,
    property,
    disabled,
    fullWidth,
    disableFuture,
    title,
    paddingLeft,
    paddingRight,
    handleDateChanged,
  } = props;

  const convertUTCDateToLocalDate = React.useCallback((date: Date) => {
    var newDate = new Date(
      date.getTime() - date.getTimezoneOffset() * 60 * 1000
    );
    return newDate;
  }, []);

  const handleChange = React.useCallback(
    (date: unknown) => {
      const newDate: Date = new Date(date as number);

      var localDate = convertUTCDateToLocalDate(newDate);

      handleDateChanged(localDate, property);
    },
    [property, handleDateChanged, convertUTCDateToLocalDate]
  );

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
          format="DD.MM.YYYY"
          slotProps={{ textField: { variant: 'standard' } }}
          defaultValue={dayjs(new Date().toDateString())}
          value={dayjs(date)}
          onChange={handleChange}
        />
      </LocalizationProvider>
    </StyledDatePickerContainer>
  );
};

export default DateInput;
