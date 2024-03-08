import { Grid } from '@mui/material';
import React from 'react';
import {
  IBudgetAccount,
  IBudgetDepartmentAccount,
} from '../interfaces/BudgetAccountInterfaces';
import UnderlinedDropDown from '../../../components/inputs/dropdowns/UnderlinedDropDown';
import { useI18n } from '../../../hooks/useI18n';
import { IDropdownItem } from '../../../lib/interfaces/IDropdownItem';
import UnderlinedNumberInput from '../../../components/inputs/textBoxes/UnderlinedNumberInput';
import SingleCheckbox from '../../../components/inputs/checkBoxes/SingleCheckBox';
import DateInput from '../../../components/inputs/datePickers/DateInput';

interface IProps {
  accounts: IBudgetAccount[];
  model: IBudgetDepartmentAccount;
  handleNumberChanged: (value: number, key: any) => void;
  handleBooleanChanged: (value: boolean, key: any) => void;
  handleTempValueChange: (value: string, key: any) => void;
}

const AccountDepartmentSettings: React.FC<IProps> = (props) => {
  const {
    accounts,
    model,
    handleNumberChanged,
    handleBooleanChanged,
    handleTempValueChange,
  } = props;
  const { getResource } = useI18n();

  const accountItems = React.useMemo((): IDropdownItem[] => {
    return accounts?.map((account) => {
      return {
        id: account.id,
        value: getResource(`budget.${account.key}`),
      };
    });
  }, [accounts, getResource]);

  const departmentItems = React.useMemo((): IDropdownItem[] => {
    const selectedAccount = accounts.find(
      (acc) => acc.id === model.budgetAccountId
    );
    if (selectedAccount != null) {
      return selectedAccount?.departments?.map((department) => {
        return {
          id: department.id,
          value: getResource(`budget.${department.key}`),
        };
      });
    }

    return [];
  }, [accounts, model, getResource]);

  return (
    <Grid container>
      <Grid item xs={12}>
        <DateInput
          property="timestamp"
          date={model.timestamp}
          fullWidth={true}
          disableFuture={true}
          handleDateChanged={handleNumberChanged}
        />
      </Grid>
      <Grid item xs={12} style={{ marginTop: '3rem' }}>
        <UnderlinedDropDown
          property="budgetAccountId"
          title={getResource('budget.labelAccount')}
          items={accountItems}
          disabled={model.timestamp == null}
          selectedItem={model.budgetAccountId}
          onItemChanged={handleNumberChanged}
          fullWidth={true}
        />
      </Grid>
      <Grid item xs={12}>
        <UnderlinedDropDown
          property="budgetDepartmentId"
          title={getResource('budget.labelDepartment')}
          items={departmentItems}
          selectedItem={model.budgetDepartmentId}
          onItemChanged={handleNumberChanged}
          fullWidth={true}
          disabled={model.budgetAccountId === -1}
        />
      </Grid>
      <Grid item xs={6}>
        <UnderlinedNumberInput
          property="amount"
          tempValueProperty="tempAmount"
          fullWidth={true}
          unit="€"
          title={getResource('common.labelAmount')}
          value={model.amount}
          tempValue={model.tempAmount}
          handleChange={handleNumberChanged}
          handleTempValueChange={handleTempValueChange}
        />
      </Grid>
      <Grid item xs={6}>
        <SingleCheckbox
          property="isPayment"
          checked={model.isPayment}
          fullWidth={true}
          label={getResource('common.labelIsPayment')}
          handleChange={handleBooleanChanged}
        />
      </Grid>
    </Grid>
  );
};

export default AccountDepartmentSettings;
