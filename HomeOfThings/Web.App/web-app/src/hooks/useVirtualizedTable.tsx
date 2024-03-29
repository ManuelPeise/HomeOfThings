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
    hasToolTip: boolean,
    maxWidth: number,
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
    hasToolTip: boolean,
    maxWidth: number,
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

  const iconButtonRenderer = (
    id: number,
    onChange: (id: number, checked: boolean) => void,
    onClick: (id: number) => void,
    cellType: TableCellTypeEnum,
    hasToolTip: boolean,
    maxWidth: number,
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

  const checkBoxCellRenderer = (
    id: number,
    value: boolean,
    cellType: TableCellTypeEnum,
    hasToolTip: boolean,
    maxWidth: number,
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
      id,
      align
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
  };
};
