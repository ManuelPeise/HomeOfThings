import React from "react";
import { StyledTextButton } from "../styledComponents";
import { ColorTypeEnum } from "../../lib/enums/ColorTypeEnum";

interface IProps {
  disabled?: boolean;
  title: string;
  color?: ColorTypeEnum;
  onClick: () => Promise<void> | void;
}

const TextButton: React.FC<IProps> = (props) => {
  const { disabled, title, color, onClick } = props;

  return (
    <StyledTextButton
      style={{ color: color }}
      disabled={disabled}
      variant="text"
      onClick={onClick}
    >
      {title}
    </StyledTextButton>
  );
};

export default TextButton;
