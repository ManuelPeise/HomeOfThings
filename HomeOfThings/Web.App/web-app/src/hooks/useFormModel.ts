import React from 'react';
import dayjs from 'dayjs';

const useFormModel = <T>(
  initialState: T,
  validationCallBack?: (model: T) => boolean
) => {
  const [model, setModel] = React.useState<T>(initialState);
  const [isValidModel, setIsValidModel] = React.useState<boolean>(false);

  const changesApplied = React.useMemo(() => {
    return JSON.stringify(model) !== JSON.stringify(initialState);
  }, [model, initialState]);

  const canSave = React.useMemo(() => {
    return changesApplied && isValidModel;
  }, [changesApplied, isValidModel]);

  const handleTextChange = React.useCallback(
    (e: React.ChangeEvent<HTMLInputElement>, property: keyof T) => {
      const update: T = {
        ...model,
        [property]: e.currentTarget.value as string,
      };
      setModel(update);

      if (validationCallBack !== undefined) {
        setIsValidModel(validationCallBack(update));
      }
    },
    [model, validationCallBack]
  );

  const handleTextChanged = React.useCallback(
    (value: string, property: keyof T) => {
      const update: T = { ...model, [property]: value };
      setModel(update);

      if (validationCallBack !== undefined) {
        setIsValidModel(validationCallBack(update));
      }
    },
    [model, validationCallBack]
  );

  const handleNumberChanged = React.useCallback(
    (value: number, property: keyof T) => {
      const update: T = { ...model, [property]: value };
      setModel(update);

      if (validationCallBack !== undefined) {
        setIsValidModel(validationCallBack(update));
      }
    },
    [model, validationCallBack]
  );

  const handleDateChanged = React.useCallback(
    (value: string, property: keyof T) => {
      const update: T = { ...model, [property]: dayjs(value) };
      setModel(update);

      if (validationCallBack !== undefined) {
        setIsValidModel(validationCallBack(update));
      }
    },
    [model, validationCallBack]
  );

  const handleBooleanChanged = React.useCallback(
    (value: boolean, property: keyof T) => {
      const update: T = { ...model, [property]: value };
      setModel(update);

      if (validationCallBack !== undefined) {
        setIsValidModel(validationCallBack(update));
      }
    },
    [model, validationCallBack]
  );

  const handleReset = React.useCallback(() => {
    setModel(initialState);
  }, [initialState]);

  return {
    model,
    isValidModel,
    changesApplied,
    canSave,
    handleTextChange,
    handleTextChanged,
    handleNumberChanged,
    handleBooleanChanged,
    handleDateChanged,
    handleReset,
  };
};

export default useFormModel;
