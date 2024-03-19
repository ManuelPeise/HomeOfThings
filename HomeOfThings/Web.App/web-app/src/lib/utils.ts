import dayjs from 'dayjs';

export const convertUTCDateToLocalDate = (date: Date) => {
  var localUtc = new Date(
    date.getTime() - date.getTimezoneOffset() * 60 * 1000
  );
  return localUtc;
};

export const getPreviousDate = (date: Date, daysToSubtract: number) => {
  return dayjs(date).subtract(daysToSubtract, 'days');
};

export const getDateRange = (offSet: number, subTract: boolean = false) => {
  let calculatedDate = new Date();
  let currentDate = new Date();

  var factor = subTract ? offSet * -1 : offSet;

  calculatedDate.setDate(calculatedDate.getDate() + factor);

  return { currentDate, calculatedDate };
};
