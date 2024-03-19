import React, { CSSProperties } from 'react';
import { Column, Table } from 'react-virtualized';
import { useVirtualizedTable } from '../../../hooks/useVirtualizedTable';
import { IVirtualizedTableConfiguration } from '../../../lib/interfaces/table/IVirtualizedTableConfiguration';
import 'react-virtualized/styles.css';
import { useI18n } from '../../../hooks/useI18n';
import { TableCellTypeEnum } from '../../../lib/enums/TableCellTypeEnum';
import NoContentPlaceholder from './NoContentPlaceholder';
import { DeleteForever } from '@mui/icons-material';

interface IVirtualizedTableDataBase {
  rowHeight: number;
  headerHeight: number;
  tableWidth: number;
  tableHeight: number;
  tableConfiguration: IVirtualizedTableConfiguration[];
  onChange?: (id: number, checked: boolean) => void;
  onIconClick?: (id: number) => Promise<void>;
}

interface IProps extends IVirtualizedTableDataBase {
  tableStyle?: CSSProperties;
  headerStyle?: CSSProperties;
  rowStyle?: any;
  tableRowModels: any[];
  noContentLabel: string;
}

const VirtualizedTable: React.FC<IProps> = (props) => {
  const {
    tableWidth,
    tableHeight,
    headerHeight,
    tableConfiguration,
    tableStyle,
    headerStyle,
    rowStyle,
    tableRowModels,
    noContentLabel,
    onChange,
    onIconClick,
  } = props;

  const { getResource } = useI18n();

  const {
    rowCount,
    labelCellRenderer,
    checkBoxCellRenderer,
    iconButtonRenderer,
    headerRenderer,
    rowGetter,
  } = useVirtualizedTable(tableRowModels);

  const handleCheckedChanged = React.useCallback(
    (id: number, checked: boolean) => {
      onChange && onChange(id, checked);
    },
    [onChange]
  );

  const handleDeleteClick = React.useCallback(
    async (id: number) => {
      onIconClick && (await onIconClick(id));
    },
    [onIconClick]
  );

  const getCellRenderer = React.useCallback(
    (
      id: number,
      type: TableCellTypeEnum,
      maxWidth: number,
      hasToolTip: boolean,
      align?: 'start' | 'center',
      cellData?: any,
      rowIndex?: number
    ) => {
      switch (type) {
        case TableCellTypeEnum.Label:
          return labelCellRenderer(
            cellData as string,
            type,
            hasToolTip,
            maxWidth,
            handleCheckedChanged,
            handleDeleteClick,
            align
          );
        case TableCellTypeEnum.CheckBox:
          return checkBoxCellRenderer(
            rowIndex ?? -1,
            cellData as boolean,
            type,
            hasToolTip,
            maxWidth,
            handleCheckedChanged,
            handleDeleteClick,
            align
          );
        case TableCellTypeEnum.Icon:
          return iconButtonRenderer(
            tableRowModels[id].id,
            handleCheckedChanged,
            handleDeleteClick,
            type,
            hasToolTip,
            maxWidth,
            align,
            <DeleteForever />
          );
      }
    },
    [
      tableRowModels,
      labelCellRenderer,
      iconButtonRenderer,
      checkBoxCellRenderer,
      handleCheckedChanged,
      handleDeleteClick,
    ]
  );

  return (
    <Table
      style={tableStyle}
      rowHeight={50}
      rowGetter={(x) => rowGetter(x.index)}
      rowStyle={rowStyle}
      headerStyle={{ ...headerStyle, margin: 0, padding: 0 }}
      noRowsRenderer={() => <NoContentPlaceholder label={noContentLabel} />}
      height={tableHeight}
      width={tableWidth}
      headerHeight={headerHeight}
      rowCount={rowCount}
    >
      {tableConfiguration.map((col) => (
        <Column
          style={{ margin: 0, padding: 0 }}
          key={col.key}
          dataKey={col.dataKey}
          headerRenderer={(props) =>
            headerRenderer(
              getResource(`common.${props.label}`),
              true,
              col.maxWidth,
              handleCheckedChanged,
              () => {},
              col.align
            )
          }
          cellRenderer={(props) =>
            getCellRenderer(
              props.rowIndex,
              col.cellType,
              col.maxWidth,
              col.hasToolTip,
              col.align,
              props.cellData,
              props.rowIndex
            )
          }
          label={col.label}
          width={tableWidth * col.percentageWidth}
        />
      ))}
    </Table>
  );
};

export default VirtualizedTable;
