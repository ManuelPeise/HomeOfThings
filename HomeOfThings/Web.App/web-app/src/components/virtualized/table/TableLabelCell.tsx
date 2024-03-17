import { FormLabel } from '@mui/material';
import React from 'react';

interface IProps {
  label: string;
  rowHeight: number;
  textAlign?: 'start' | 'center';
}

const TableLabelCell: React.FC<IProps> = (props) => {
  const { label, rowHeight, textAlign } = props;
  return (
    <div
      style={{
        display: 'flex',
        justifyContent: textAlign ?? 'center',
        alignItems: 'center',
        textAlign: 'center',
        width: '100%',
        margin: 0,
        padding: '8px',
        height: `${rowHeight}px`,
        borderBottom: '2px solid black',
      }}
    >
      <FormLabel
        style={{
          fontWeight: 'bold',
        }}
      >
        {label}
      </FormLabel>
    </div>
  );
};

export default TableLabelCell;
