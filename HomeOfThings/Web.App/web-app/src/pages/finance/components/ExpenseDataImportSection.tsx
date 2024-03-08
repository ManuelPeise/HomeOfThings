import React from 'react';
import { useStatelessApi } from '../../../hooks/api/useStatelessApi';
import {
  IBudgetAccount,
  IBudgetDepartmentAccount,
} from '../interfaces/BudgetAccountInterfaces';
import { ApiEndpointEnum } from '../../../lib/enums/ApiEndpointEnum';
import useFormModel from '../../../hooks/useFormModel';
import FormWrapper from '../../../components/wrappers/FormWrapper';
import AccountDepartmentSettings from './AccountDepartmentSettings';

interface IProps {
  sectionId: number;
  selectedSectionId: number;
}

const accountModel: IBudgetDepartmentAccount = {
  budgetAccountId: -1,
  budgetDepartmentId: -1,
  userId: 1,
  amount: 0,
  tempAmount: '',
  timestamp: null,
  isPayment: false,
};

const validateModel = (model: IBudgetDepartmentAccount) => {
  return (
    model.budgetAccountId !== -1 &&
    model.budgetDepartmentId !== -1 &&
    model.amount !== 0
  );
};
const ExpenseDataImportSection: React.FC<IProps> = (props) => {
  const { sectionId, selectedSectionId } = props;
  const [accounts, setAccounts] = React.useState<IBudgetAccount[]>([]);
  const {
    model,
    changesApplied,
    isValidModel,
    handleReset,
    handleNumberChanged,
    handleBooleanChanged,
    handleTextChanged,
  } = useFormModel<IBudgetDepartmentAccount>(accountModel, validateModel);

  const accountApi = useStatelessApi<IBudgetAccount[]>().create({
    serviceUrl: ApiEndpointEnum.GetBudgetAccounts,
    requestOptions: { method: 'GET', mode: 'cors' },
    parameters: '',
  });

  const importApi = useStatelessApi<boolean>().create({
    serviceUrl: ApiEndpointEnum.ImportBudgetAccountDepartment,
    requestOptions: { method: 'POST', mode: 'cors' },
    parameters: '',
  });

  React.useEffect(() => {
    if (sectionId !== selectedSectionId) {
      handleReset();
    }
  }, [sectionId, selectedSectionId, handleReset]);

  React.useEffect(() => {
    const sendRequest = async () => {
      const data = await accountApi.get();

      if (data != null) {
        setAccounts(data);
      }
    };

    sendRequest();
    // eslint-disable-next-line
  }, []);

  const handleCancel = React.useCallback(() => {
    handleReset();
  }, [handleReset]);

  const handleSave = React.useCallback(async () => {
    const response = await importApi.postWithContent({
      serviceUrl: ApiEndpointEnum.ImportBudgetAccountDepartment,
      requestOptions: {
        method: 'POST',
        mode: 'cors',
        body: JSON.stringify(model),
      },
    });

    if (response === true) {
      handleReset();
    }
  }, [importApi, handleReset, model]);

  if (sectionId !== selectedSectionId || accountApi.isLoading) {
    return null;
  }

  return (
    <FormWrapper
      hasCancelButton={true}
      canSave={changesApplied && isValidModel}
      canCancel={changesApplied}
      padding={5}
      handleCancelClick={handleCancel}
      handleSaveClick={handleSave}
    >
      <AccountDepartmentSettings
        accounts={accounts}
        model={model}
        handleNumberChanged={handleNumberChanged}
        handleBooleanChanged={handleBooleanChanged}
        handleTempValueChange={handleTextChanged}
      />
    </FormWrapper>
  );
};

export default ExpenseDataImportSection;
