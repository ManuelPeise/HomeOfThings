import { Checkbox } from '@mui/material';
import React from 'react';

interface IProps {
  id: number;
  value: boolean;
  rowHeight: number;
  textAlign?: 'start' | 'center';
  onChange: (id: number, checked: boolean) => void;
}

const TableCheckBoxCell: React.FC<IProps> = (props) => {
  const { id, value, rowHeight, textAlign, onChange } = props;

  const handleCheckedChange = React.useCallback(
    (e: React.ChangeEvent<HTMLInputElement>, checked: boolean) => {
      onChange(id, checked);
    },
    [id, onChange]
  );

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
      <Checkbox checked={value} onChange={handleCheckedChange} />
    </div>
  );
};

export default TableCheckBoxCell;
