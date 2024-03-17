import React, { CSSProperties } from 'react';
import { Column, Table } from 'react-virtualized';
import { useVirtualizedTable } from '../../../hooks/useVirtualizedTable';
import { IVirtualizedTableConfiguration } from '../../../lib/interfaces/table/IVirtualizedTableConfiguration';
import 'react-virtualized/styles.css';
import { useI18n } from '../../../hooks/useI18n';
import { TableCellTypeEnum } from '../../../lib/enums/TableCellTypeEnum';

interface IVirtualizedTableDataBase {
  rowHeight: number;
  headerHeight: number;
  tableWidth: number;
  tableHeight: number;
  tableConfiguration: IVirtualizedTableConfiguration[];
  onChange?: (id: number, checked: boolean) => void;
}

interface IProps extends IVirtualizedTableDataBase {
  tableStyle?: CSSProperties;
  headerStyle?: CSSProperties;
  rowStyle?: any;
  tableRowModels: any[];
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
    onChange,
  } = props;

  const { getResource } = useI18n();

  const {
    rowCount,
    labelCellRenderer,
    checkBoxCellRenderer,
    headerRenderer,
    rowGetter,
  } = useVirtualizedTable(tableRowModels);

  const handleCheckedChanged = React.useCallback(
    (id: number, checked: boolean) => {
      onChange && onChange(id, checked);
    },
    [onChange]
  );

  return (
    <Table
      style={tableStyle}
      rowHeight={50}
      rowGetter={(x) => rowGetter(x.index)}
      rowStyle={rowStyle}
      headerStyle={{ ...headerStyle, margin: 0, padding: 0 }}
      noRowsRenderer={() => {
        return <div>No Rows Available</div>;
      }}
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
              handleCheckedChanged,
              col.align
            )
          }
          cellRenderer={(props) =>
            col.cellType === TableCellTypeEnum.Label
              ? labelCellRenderer(
                  props.cellData as string,
                  col.cellType,
                  handleCheckedChanged,
                  col.align
                )
              : checkBoxCellRenderer(
                  props.rowIndex,
                  props.cellData as boolean,
                  col.cellType,
                  handleCheckedChanged,
                  col.align
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
