import React, { PropsWithChildren } from 'react';

interface IProps extends PropsWithChildren {
  rowIndex: number;
  style: any;
}

const VirtualizedTableRow: React.FC<IProps> = (props) => {
  const { children, rowIndex, style } = props;

  return (
    <div key={rowIndex} style={style}>
      {children}
    </div>
  );
};

export default VirtualizedTableRow;
