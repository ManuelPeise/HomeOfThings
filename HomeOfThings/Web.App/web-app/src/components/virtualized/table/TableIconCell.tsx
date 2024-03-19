import React from 'react';
import IconButton from '../../buttons/IconButton';

interface IProps {
  id: number;
  icon?: JSX.Element;
  rowHeight: number;
  onClick: (id: number) => void;
}

const TableIconCell: React.FC<IProps> = (props) => {
  const { id, icon, rowHeight, onClick } = props;
  return (
    <div
      style={{
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        textAlign: 'center',
        width: '100%',
        margin: 0,
        padding: '8px',
        height: `${rowHeight}px`,
        borderBottom: '2px solid black',
      }}
    >
      <IconButton id={id} icon={icon} onClick={onClick} />
    </div>
  );
};

export default TableIconCell;
