import { TableCellTypeEnum } from '../../../lib/enums/TableCellTypeEnum';
import { IVirtualizedTableConfiguration } from '../../../lib/interfaces/table/IVirtualizedTableConfiguration';

export const logTableConfiguration: IVirtualizedTableConfiguration[] = [
  {
    key: 'common.labelId',
    dataKey: 'id',
    label: 'labelId',
    percentageWidth: 0.05,
    cellType: TableCellTypeEnum.Label,
    maxWidth: 30,
    hasToolTip: false,
  },
  {
    key: 'common.labelTimeStamp',
    dataKey: 'timeStamp',
    label: 'labelTimeStamp',
    percentageWidth: 0.11,
    align: 'start',
    cellType: TableCellTypeEnum.Label,
    maxWidth: 170,
    hasToolTip: false,
  },
  {
    key: 'common.labelTrigger',
    dataKey: 'trigger',
    label: 'labelTrigger',
    percentageWidth: 0.11,
    align: 'start',
    cellType: TableCellTypeEnum.Label,
    maxWidth: 200,
    hasToolTip: false,
  },
  {
    key: 'common.labelMessage',
    dataKey: 'message',
    label: 'labelMessage',
    percentageWidth: 0.31,
    align: 'start',
    cellType: TableCellTypeEnum.Label,
    maxWidth: 500,
    hasToolTip: true,
  },
  {
    key: 'common.labelExceptionMessage',
    dataKey: 'exceptionMessage',
    label: 'labelExceptionMessage',
    percentageWidth: 0.4,
    align: 'start',
    cellType: TableCellTypeEnum.Label,
    maxWidth: 500,
    hasToolTip: true,
  },
  {
    key: 'common.labelDelete',
    dataKey: 'delete',
    label: 'labelDelete',
    percentageWidth: 0.04,
    align: 'center',
    cellType: TableCellTypeEnum.Icon,
    maxWidth: 100,
    hasToolTip: false,
  },
];
