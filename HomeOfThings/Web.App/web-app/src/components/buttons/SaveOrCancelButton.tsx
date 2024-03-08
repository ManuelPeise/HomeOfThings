import React from 'react';
import { RoundedButton } from '../styledComponents/StyledButtons';
import { ColorTypeEnum } from '../../lib/enums/ColorTypeEnum';

interface IProps {
  title: string;
  backgroundColor: ColorTypeEnum;
  fontColor?: ColorTypeEnum;
  disabled?: boolean;
  handleClick: () => Promise<void> | void;
}

const SaveOrCancelButton: React.FC<IProps> = (props) => {
  const { title, backgroundColor, fontColor, disabled, handleClick } =
    props;

  return (
    <RoundedButton
      style={{ backgroundColor: backgroundColor, color: fontColor }}
      disabled={disabled}
      onClick={handleClick}
    >
      {title}
    </RoundedButton>
  );
};

export default SaveOrCancelButton;
