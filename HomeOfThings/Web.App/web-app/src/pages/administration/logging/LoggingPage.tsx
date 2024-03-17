import React, { CSSProperties } from 'react';
import TableLayout from '../../../components/layouts/TableLayout';
import { useI18n } from '../../../hooks/useI18n';
import VirtualizedTable from '../../../components/virtualized/table/VirtualizedTable';
import { logTableConfiguration } from '../../../components/virtualized/configurations/logTableConfiguration';
import { useContainerDimensions } from '../../../hooks/useWindowDimensions';
import { ColorTypeEnum } from '../../../lib/enums/ColorTypeEnum';
import '../../../../src/virtualizeTable.css';
import { useStatelessApi } from '../../../hooks/api/useStatelessApi';
import { ILogMessage } from './interfaces/ILogMessage';
import { ApiEndpointEnum } from '../../../lib/enums/ApiEndpointEnum';
interface IProps {}

const LoggingPage: React.FC<IProps> = (props) => {
  const { getResource } = useI18n();
  const tableContainerRef = React.useRef<HTMLDivElement | null>(null);
  const { width, height } = useContainerDimensions(
    tableContainerRef,
    window.screen.width * 0.9,
    400
  );
  const [logMessages, setLogMessages] = React.useState<ILogMessage[]>([]);

  const logApi = useStatelessApi<ILogMessage[]>().create({
    serviceUrl: ApiEndpointEnum.GetLogMessages,
    requestOptions: {
      method: 'GET',
      mode: 'cors',
    },
    parameters: '',
  });

  const sendRequest = React.useCallback(async () => {
    const response = await logApi.get({
      serviceUrl: ApiEndpointEnum.GetLogMessages,
      requestOptions: {
        method: 'GET',
        mode: 'cors',
      },
      parameters: '',
    });
    if (response != null) {
      setLogMessages(response);
    }
  }, [logApi]);

  React.useEffect(() => {
    sendRequest();
    // eslint-disable-next-line
  }, []);
  // add filter bar
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
      toolBar={<div key="test">ToolBar</div>}
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
          tableRowModels={logMessages}
          tableConfiguration={tableConfig}
        />
      </div>
    </TableLayout>
  );
};

export default LoggingPage;
