import React from 'react';
import {
  StyledGridContainer,
  StyledGridItem,
} from '../../../../components/styledComponents/StyledWrappers';
import UnderlinedDropDown from '../../../../components/inputs/dropdowns/UnderlinedDropDown';
import { ILogMessageFilterOptions } from '../interfaces/ILogMessageFilterOptions';
import { useI18n } from '../../../../hooks/useI18n';
import DateRangeInput from '../../../../components/inputs/datePickers/DateRangePicker';

interface IProps {
  filterOptions: ILogMessageFilterOptions;
  handleFromDateChanged: (date: string, key: any) => void;
  handleToDateChanged: (date: string, key: any) => void;
  handleTriggerChanged: (id: number, key: any) => void;
}

const LogTableFilterBar: React.FC<IProps> = (props) => {
  const {
    filterOptions,
    handleFromDateChanged,
    handleToDateChanged,
    handleTriggerChanged,
  } = props;

  const { getResource } = useI18n();

  return (
    <StyledGridContainer
      style={{
        height: '100%',
        width: '100%',
        display: 'flex',
        flexDirection: 'row',
        alignItems: 'center',
        justifyContent: 'space-around',
      }}
    >
      <StyledGridItem
        style={{ width: '50%', display: 'flex', justifyContent: 'center' }}
      >
        <UnderlinedDropDown
          title={getResource('administration.labelTrigger')}
          items={filterOptions.triggerItems}
          selectedItem={filterOptions.selectedItem}
          onItemChanged={handleTriggerChanged}
        />
      </StyledGridItem>
      <StyledGridContainer
        style={{
          height: '100%',
          width: '50%',
          display: 'flex',
          flexDirection: 'row',
          alignItems: 'center',
          justifyContent: 'space-around',
        }}
      >
        <StyledGridItem>
          <DateRangeInput
            from={{
              property: 'from',
              date: filterOptions.from,
              disableFuture: true,
              title: getResource('common.labelFromDate'),
              handleDateChanged: handleFromDateChanged,
            }}
            to={{
              property: 'from',
              date: filterOptions.to,
              disableFuture: true,
              title: getResource('common.labelToDate'),
              handleDateChanged: handleToDateChanged,
            }}
            hasMinDate={true}
          />
        </StyledGridItem>
      </StyledGridContainer>
    </StyledGridContainer>
  );
};

export default LogTableFilterBar;
