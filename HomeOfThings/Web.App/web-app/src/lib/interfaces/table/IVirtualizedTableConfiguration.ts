import { TableCellTypeEnum } from '../../enums/TableCellTypeEnum';

export interface IVirtualizedTableConfiguration {
  dataKey: string;
  key: string;
  label: string;
  percentageWidth: number;
  align?: 'center' | 'start';
  cellType: TableCellTypeEnum;
  maxWidth: number;
  hasToolTip: boolean;
}
