import React from 'react';

export enum LocalStorageKeyEnum {
  LogFilterOptions = 'logFilterOptions',
  UserName = 'username',
}

export const getLocalStorageValue = (
  key: LocalStorageKeyEnum
): string | null => {
  return window.localStorage.getItem(key);
};

export const useLocalStorage = <T>(
  callBack: () => string | null,
  deps: LocalStorageKeyEnum
) => {
  const [storageItem, setStorageItem] = React.useState<T | null>(null);

  const parseJson = React.useCallback((json: string | null) => {
    if (json != null && json.length > 0) {
      const model: T = JSON.parse(JSON.stringify(json));

      setStorageItem(model);
    }
  }, []);

  const getItem = React.useCallback(
    (key: LocalStorageKeyEnum) => {
      const storageJson: string | null =
        window.localStorage.getItem(key) ?? null;

      if (storageJson != null) {
        const model: T = JSON.parse(JSON.stringify(storageJson));

        setStorageItem(model);
      }
    },
    [setStorageItem]
  );

  const setItem = React.useCallback(
    (key: LocalStorageKeyEnum, model: T) => {
      window.localStorage.setItem(key, JSON.stringify(model));

      setStorageItem(model);
    },
    [setStorageItem]
  );

  React.useEffect(() => {
    parseJson(callBack());
  }, [deps, parseJson, callBack]);

  return {
    storageItem,
    getItem,
    setItem,
  };
};
