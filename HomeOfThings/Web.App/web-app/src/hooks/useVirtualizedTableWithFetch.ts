import React from 'react';
import { ApiEndpointEnum } from '../lib/enums/ApiEndpointEnum';
import { TableManager } from '../lib/tableManager';
import { TableCellTypeEnum } from '../lib/enums/TableCellTypeEnum';
import { useStatelessApi } from './api/useStatelessApi';

export const useVirtualizedTableWithFetch = <T>(
  endpoint: ApiEndpointEnum,
  headerHeight: number
) => {
  const manager = new TableManager(headerHeight);

  const apiService = useStatelessApi<T[]>().create({
    serviceUrl: endpoint,
    requestOptions: {
      method: 'GET',
      mode: 'cors',
    },
    parameters: '',
  });

  const [tableItems, setTableItems] = React.useState<T[]>([]);

  const sendRequest = React.useCallback(async () => {
    const response = await apiService.get();

    if (response != null) {
      setTableItems(response);
    }
  }, [apiService]);

  React.useEffect(() => {
    sendRequest();
    // eslint-disable-next-line
  }, []);

  const rowGetter = React.useCallback(
    (index: number): any => {
      if (tableItems == null || tableItems?.length === 0) {
        return null;
      }
      const item = tableItems[index];
      return item;
    },
    [tableItems]
  );

  const headerRenderer = (
    label: string,
    maxWidth: number,
    hasToolTip: boolean,
    onChange: (id: number, checked: boolean) => void,
    onClick: (id: number) => void,
    align?: 'start' | 'center'
  ) => {
    return manager.getCell(
      TableCellTypeEnum.Label,
      label,
      maxWidth,
      hasToolTip,
      onChange,
      onClick,
      0,
      align
    );
  };

  const labelCellRenderer = (
    value: string,
    cellType: TableCellTypeEnum,
    maxWidth: number,
    hasToolTip: boolean,
    onChange: (id: number, checked: boolean) => void,
    onClick: (id: number) => void,
    align?: 'start' | 'center'
  ) => {
    return manager.getCell(
      cellType,
      value,
      maxWidth,
      hasToolTip,
      onChange,
      onClick,
      0,
      align
    );
  };

  const checkBoxCellRenderer = (
    id: number,
    value: boolean,
    cellType: TableCellTypeEnum,
    maxWidth: number,
    hasToolTip: boolean,
    onChange: (id: number, checked: boolean) => void,
    onClick: (id: number) => void,
    align?: 'start' | 'center'
  ) => {
    return manager.getCell(
      cellType,
      value,
      maxWidth,
      hasToolTip,
      onChange,
      onClick,
      id ?? 0,
      align
    );
  };

  const iconButtonRenderer = (
    id: number,
    maxWidth: number,
    hasToolTip: boolean,
    onChange: (id: number, checked: boolean) => void,
    onClick: (id: number) => void,
    cellType: TableCellTypeEnum,
    align?: 'start' | 'center',
    icon?: JSX.Element
  ) => {
    return manager.getCell(
      cellType,
      '',
      maxWidth,
      hasToolTip,
      onChange,
      onClick,
      id,
      align,
      icon
    );
  };

  return {
    tableRows: tableItems,
    rowCount: tableItems?.length,
    headerRenderer,
    labelCellRenderer,
    checkBoxCellRenderer,
    iconButtonRenderer,
    rowGetter,
    rebind: sendRequest,
  };
};
