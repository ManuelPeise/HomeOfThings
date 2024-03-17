import React from 'react';
import { TableManager } from '../lib/tableManager';
import { TableCellTypeEnum } from '../lib/enums/TableCellTypeEnum';

export const useVirtualizedTable = (tableItems: any[]) => {
  const manager = new TableManager(60);

  const rowGetter = React.useCallback(
    (index: number): any => {
      if (tableItems === undefined || tableItems.length === 0) {
        return null;
      }
      const item = tableItems[index];
      return item;
    },
    [tableItems]
  );

  const headerRenderer = (
    label: string,
    onChange: (id: number, checked: boolean) => void,
    align?: 'start' | 'center'
  ) => {
    return manager.getCell(TableCellTypeEnum.Label, label, onChange, align);
  };

  const labelCellRenderer = (
    value: string,
    cellType: TableCellTypeEnum,
    onChange: (id: number, checked: boolean) => void,
    align?: 'start' | 'center'
  ) => {
    return manager.getCell(cellType, value, onChange, align);
  };

  const checkBoxCellRenderer = (
    id: number,
    value: boolean,
    cellType: TableCellTypeEnum,
    onChange: (id: number, checked: boolean) => void,
    align?: 'start' | 'center'
  ) => {
    return manager.getCell(cellType, value, onChange, align, id);
  };

  console.log(tableItems);
  return {
    tableRows: tableItems,
    rowCount: tableItems?.length,
    headerRenderer,
    labelCellRenderer,
    checkBoxCellRenderer,
    rowGetter,
  };
};
