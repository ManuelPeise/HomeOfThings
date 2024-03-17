import { TableCellTypeEnum } from '../../../lib/enums/TableCellTypeEnum';
import { IVirtualizedTableConfiguration } from '../../../lib/interfaces/table/IVirtualizedTableConfiguration';

// tr:nth-child(even) {
//     background-color: #dddddd;
// }

export const logTableConfiguration: IVirtualizedTableConfiguration[] = [
  {
    key: 'common.labelId',
    dataKey: 'id',
    label: 'labelId',
    percentageWidth: 0.08,
    cellType: TableCellTypeEnum.Label,
  },
  {
    key: 'common.labelTimeStamp',
    dataKey: 'timeStamp',
    label: 'labelTimeStamp',
    percentageWidth: 0.15,
    align: 'center',
    cellType: TableCellTypeEnum.Label,
  },
  {
    key: 'common.labelTrigger',
    dataKey: 'trigger',
    label: 'labelTrigger',
    percentageWidth: 0.2,
    align: 'start',
    cellType: TableCellTypeEnum.Label,
  },
  {
    key: 'common.labelMessage',
    dataKey: 'message',
    label: 'labelMessage',
    percentageWidth: 0.5,
    align: 'start',
    cellType: TableCellTypeEnum.Label,
  },
  {
    key: 'common.labelDelete',
    dataKey: 'delete',
    label: 'labelDelete',
    percentageWidth: 0.08,
    align: 'start',
    cellType: TableCellTypeEnum.CheckBox,
  },
];
