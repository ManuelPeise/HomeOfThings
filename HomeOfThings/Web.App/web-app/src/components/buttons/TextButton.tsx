import React from "react";
import { ColorTypeEnum } from "../../lib/enums/ColorTypeEnum";
import { StyledButton } from "../styledComponents/StyledButtons";

interface IProps {
  disabled?: boolean;
  title: string;
  color?: ColorTypeEnum;
  onClick: () => Promise<void> | void;
}

const TextButton: React.FC<IProps> = (props) => {
  const { disabled, title, color, onClick } = props;

  return (
    <StyledButton
      style={{ color: color }}
      disabled={disabled}
      variant="text"
      onClick={onClick}
    >
      {title}
    </StyledButton>
  );
};

export default TextButton;
