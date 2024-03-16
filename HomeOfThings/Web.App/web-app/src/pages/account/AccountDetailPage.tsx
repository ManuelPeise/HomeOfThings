import React from 'react';
import DateInput from '../../components/inputs/datePickers/DateInput';

const AccountDetailPage: React.FC = () => {
  const [date, setDate] = React.useState<Date | null>(null);

  const handleChange = React.useCallback((date: Date, key: any) => {
    setDate(date);
  }, []);

  return (
    <div style={{ margin: '10rem' }}>
      <div>My Account Data</div>
      <DateInput date={date} handleDateChanged={handleChange} property="test" />
    </div>
  );
};

export default AccountDetailPage;
