import { FormLabel, Tooltip } from '@mui/material';
import React from 'react';

interface IProps {
  label: string;
  rowHeight: number;
  textAlign?: 'start' | 'center';
  maxWidth?: number;
  hasToolTip: boolean;
}

const TableLabelCell: React.FC<IProps> = (props) => {
  const { label, rowHeight, textAlign, maxWidth, hasToolTip } = props;
  return (
    <div
      style={{
        display: 'flex',
        justifyContent: textAlign ?? 'center',
        alignItems: 'center',
        textAlign: 'center',
        width: '100%',
        maxWidth: maxWidth,
        margin: 0,
        padding: '8px',
        height: `${rowHeight}px`,
        overflow: 'hidden',
      }}
    >
      {hasToolTip === true && (
        <Tooltip title={label}>
          <FormLabel
            style={{
              fontWeight: 'bold',
            }}
          >
            {label}
          </FormLabel>
        </Tooltip>
      )}
      {hasToolTip === false && (
        <FormLabel
          style={{
            fontWeight: 'bold',
          }}
        >
          {label}
        </FormLabel>
      )}
    </div>
  );
};

export default TableLabelCell;
