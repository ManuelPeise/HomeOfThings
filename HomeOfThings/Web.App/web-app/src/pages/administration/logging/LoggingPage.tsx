import React, { CSSProperties } from 'react';
import TableLayout from '../../../components/layouts/TableLayout';
import { useI18n } from '../../../hooks/useI18n';
import VirtualizedTable from '../../../components/virtualized/table/VirtualizedTable';
import { logTableConfiguration } from '../../../components/virtualized/configurations/logTableConfiguration';
import { useContainerDimensions } from '../../../hooks/useWindowDimensions';
import { ColorTypeEnum } from '../../../lib/enums/ColorTypeEnum';
import '../../../../src/virtualizeTable.css';
import { ILogMessage } from './interfaces/ILogMessage';
import { ApiEndpointEnum } from '../../../lib/enums/ApiEndpointEnum';
import LogTableFilterBar from './components/LogTableFilterBar';
import { useVirtualizedTableWithFetch } from '../../../hooks/useVirtualizedTableWithFetch';
import { getPreviousDate } from '../../../lib/utils';
import dayjs from 'dayjs';
import { ILogMessageFilterOptions } from './interfaces/ILogMessageFilterOptions';
import { IDropdownItem } from '../../../lib/interfaces/IDropdownItem';
import { useStatelessApi } from '../../../hooks/api/useStatelessApi';

interface IProps {}

const LoggingPage: React.FC<IProps> = (props) => {
  const { getResource } = useI18n();
  const tableContainerRef = React.useRef<HTMLDivElement | null>(null);

  const deleteLogRowApi = useStatelessApi<boolean>().create({
    serviceUrl: ApiEndpointEnum.PostDeleteLogMessage,
    requestOptions: {},
    parameters: '',
  });

  const { width, height } = useContainerDimensions(
    tableContainerRef,
    window.screen.width * 0.9,
    400
  );

  const { tableRows, rebind } = useVirtualizedTableWithFetch<ILogMessage>(
    ApiEndpointEnum.GetLogMessages,
    60
  );

  const [filterOptions, setFilterOptions] =
    React.useState<ILogMessageFilterOptions>({
      from: getPreviousDate(new Date(), 7).toString(),
      to: new Date().toString(),
      selectedItem: 0,
      triggerItems: [],
    });

  React.useEffect(() => {
    const items: IDropdownItem[] = [];

    items.push({
      id: 0,
      value: getResource('common.labelAll'),
      disabled: false,
    });

    tableRows.forEach((row, index) => {
      if (items.findIndex((x) => x.value === row.trigger) === -1) {
        items.push({
          id: index + 1,
          value: row.trigger,
          disabled: false,
        });
      }
    });
    setFilterOptions({ ...filterOptions, triggerItems: items });
  }, [tableRows, filterOptions, getResource]);

  const tableConfig = React.useMemo(() => {
    return logTableConfiguration;
  }, []);

  const { tableHeight, tableWidth } = React.useMemo(() => {
    let tableWidth = 0;
    let tableHeight = 0;

    if (width !== undefined && height !== undefined) {
      tableHeight = height - 100;

      tableConfig.forEach((item) => {
        tableWidth += item.percentageWidth * width - 50;
      });
    }

    return { tableHeight, tableWidth };
  }, [tableConfig, width, height]);

  const filteredTableRows = React.useMemo((): ILogMessage[] => {
    let items: ILogMessage[] = [];

    if (tableRows.length < 1) {
      return items;
    }

    if (filterOptions != null && tableRows?.length > 0) {
      const fromDate = dayjs(filterOptions.from).subtract(1, 'day');
      const toDate = dayjs(filterOptions.to).add(1, 'day');
      items = tableRows.filter(
        (row) =>
          dayjs(row.timeStamp).isAfter(fromDate) &&
          dayjs(row.timeStamp).isBefore(toDate)
      );
    }

    if (filterOptions.selectedItem !== 0) {
      items = items.filter(
        (item) =>
          item.trigger ===
          filterOptions.triggerItems[filterOptions.selectedItem].value
      );
    }

    return items;
  }, [filterOptions, tableRows]);

  const handleFromDateChanged = React.useCallback(
    (date: string, key: any) => {
      console.log(date);
      setFilterOptions({ ...filterOptions, from: date });
    },
    [filterOptions]
  );

  const handleToDateChanged = React.useCallback(
    (date: string, key: any) => {
      setFilterOptions({
        ...filterOptions,
        to: date,
      });
    },
    [filterOptions]
  );

  const handleTriggerChanged = React.useCallback(
    (id: number, key: any) => {
      setFilterOptions({
        ...filterOptions,
        selectedItem: id,
      });
    },
    [filterOptions]
  );

  const handleDeleteRow = React.useCallback(
    async (id: number) => {
      if (
        await deleteLogRowApi.postWithContent({
          serviceUrl: ApiEndpointEnum.PostDeleteLogMessage,
          requestOptions: {
            method: 'POST',
            mode: 'cors',
          },
          parameters: `${id}`,
        })
      ) {
        await rebind();
      }
    },
    [deleteLogRowApi, rebind]
  );

  const tableStyle: CSSProperties = {
    border: `2px solid ${ColorTypeEnum.LightBlue}`,
    overflow: 'scroll',
  };

  const tableHeaderStyle: CSSProperties = {
    backgroundColor: ColorTypeEnum.LightBlue,
    color: ColorTypeEnum.White,
  };

  return (
    <TableLayout
      pageTitle={getResource('common.labelPageTitleLog')}
      toolBar={
        <LogTableFilterBar
          filterOptions={filterOptions}
          handleFromDateChanged={handleFromDateChanged}
          handleToDateChanged={handleToDateChanged}
          handleTriggerChanged={handleTriggerChanged}
        />
      }
    >
      <div
        ref={tableContainerRef}
        style={{
          display: 'flex',
          justifyContent: 'center',
          alignContent: 'center',
          height: '100%',
          padding: '2rem',
        }}
      >
        <VirtualizedTable
          key="log-table"
          tableWidth={tableWidth}
          tableHeight={tableHeight}
          tableStyle={tableStyle}
          headerStyle={tableHeaderStyle}
          rowHeight={30}
          headerHeight={60}
          tableRowModels={filteredTableRows}
          tableConfiguration={tableConfig}
          noContentLabel={getResource('administration.labelNoLogMessages')}
          onIconClick={handleDeleteRow}
        />
      </div>
    </TableLayout>
  );
};

export default LoggingPage;
