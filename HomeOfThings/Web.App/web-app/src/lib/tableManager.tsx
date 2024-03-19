import React from 'react';
import { TableCellTypeEnum } from './enums/TableCellTypeEnum';
import TableLabelCell from '../components/virtualized/table/TableLabelCell';
import TableCheckBoxCell from '../components/virtualized/table/TableCheckboxCell';
import TableIconCell from '../components/virtualized/table/TableIconCell';

export class TableManager {
  private rowHeight;
  constructor(rowHeight: number) {
    this.rowHeight = rowHeight;
  }

  public getCell = (
    cellType: TableCellTypeEnum,
    cellData: string | boolean,
    maxWidth: number,
    hasToolTip: boolean,
    onChange: (id: number, checked: boolean) => void,
    onClick: (id: number) => void,
    id: number,
    align?: 'center' | 'start',
    icon?: JSX.Element
  ): React.ReactNode => {
    switch (cellType) {
      case TableCellTypeEnum.Label:
        return this.getLabelCell(
          cellData as string,
          align,
          maxWidth,
          hasToolTip
        );
      case TableCellTypeEnum.CheckBox:
        return this.getCheckBoxCell(
          id ?? 0,
          cellData as boolean,
          align,
          maxWidth,
          hasToolTip,
          onChange
        );
      case TableCellTypeEnum.Icon:
        return this.getIconBoxCell(id, maxWidth, hasToolTip, onClick, icon);
      default:
        return null;
    }
  };

  private getLabelCell = (
    value: string,
    align: 'center' | 'start' | undefined,
    maxWidth: number,
    hasToolTip: boolean
  ) => {
    return (
      <TableLabelCell
        label={value}
        rowHeight={this.rowHeight}
        textAlign={align}
        maxWidth={maxWidth}
        hasToolTip={hasToolTip}
      />
    );
  };

  private getCheckBoxCell = (
    id: number,
    value: boolean,
    align: 'center' | 'start' | undefined,
    maxWidth: number,
    hasToolTip: boolean,
    onChange: (id: number, checked: boolean) => void
  ) => {
    return (
      <TableCheckBoxCell
        id={id}
        value={value}
        rowHeight={this.rowHeight}
        textAlign={align}
        onChange={onChange}
      />
    );
  };

  private getIconBoxCell = (
    id: number,
    maxWidth: number,
    hasToolTip: boolean,
    onClick: (id: number) => void,
    icon?: JSX.Element
  ) => {
    return (
      <TableIconCell
        id={id}
        rowHeight={this.rowHeight}
        icon={icon}
        onClick={onClick}
      />
    );
  };
}
