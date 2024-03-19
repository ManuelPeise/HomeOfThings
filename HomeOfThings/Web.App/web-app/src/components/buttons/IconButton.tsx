import { IconButton as Button } from '@mui/material';
import React from 'react';

interface IProps {
  id: number;
  icon?: JSX.Element;
  onClick: (id: number) => void;
}

const IconButton: React.FC<IProps> = (props) => {
  const { id, icon, onClick } = props;

  return <Button onClick={onClick.bind(null, id)}>{icon}</Button>;
};

export default IconButton;
