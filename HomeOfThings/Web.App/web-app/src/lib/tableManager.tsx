import React from 'react';
import { TableCellTypeEnum } from './enums/TableCellTypeEnum';
import TableLabelCell from '../components/virtualized/table/TableLabelCell';
import TableCheckBoxCell from '../components/virtualized/table/TableCheckboxCell';

export class TableManager {
  private rowHeight;
  constructor(rowHeight: number) {
    this.rowHeight = rowHeight;
  }

  public getCell = (
    cellType: TableCellTypeEnum,
    cellData: string | boolean,
    onChange: (id: number, checked: boolean) => void,
    align?: 'center' | 'start',
    id?: number
  ): React.ReactNode => {
    switch (cellType) {
      case TableCellTypeEnum.Label:
        return this.getLabelCell(cellData as string, align);
      case TableCellTypeEnum.CheckBox:
        return this.getCheckBoxCell(
          id ?? 0,
          cellData as boolean,
          align,
          onChange
        );
      default:
        return null;
    }
  };

  private getLabelCell = (
    value: string,
    align: 'center' | 'start' | undefined
  ) => {
    return (
      <TableLabelCell
        label={value}
        rowHeight={this.rowHeight}
        textAlign={align}
      />
    );
  };

  private getCheckBoxCell = (
    id: number,
    value: boolean,
    align: 'center' | 'start' | undefined,
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
}
