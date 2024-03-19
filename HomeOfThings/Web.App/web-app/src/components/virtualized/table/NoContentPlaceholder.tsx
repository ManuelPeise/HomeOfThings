import React from 'react';
import {
  StyledGridContainer,
  StyledGridItem,
} from '../../../components/styledComponents/StyledWrappers';
import { FormLabel } from '@mui/material';

interface IProps {
  label: string;
}

const NoContentPlaceholder: React.FC<IProps> = (props) => {
  const { label } = props;
  return (
    <StyledGridContainer
      style={{
        display: 'flex',
        justifyContent: 'center',
        width: '100%',
        height: '100%',
      }}
    >
      <StyledGridItem
        xs={12}
        style={{
          display: 'flex',
          justifyContent: 'center',
          alignItems: 'center',
          width: '100%',
          height: '100%',
        }}
      >
        <FormLabel style={{ fontSize: '1.5rem', fontWeight: '500' }}>
          {label}
        </FormLabel>
      </StyledGridItem>
    </StyledGridContainer>
  );
};

export default NoContentPlaceholder;
