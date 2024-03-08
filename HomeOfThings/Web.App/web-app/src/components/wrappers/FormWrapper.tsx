import { Grid } from '@mui/material';
import React, { PropsWithChildren } from 'react';
import SaveOrCancelButton from '../buttons/SaveOrCancelButton';
import { ColorTypeEnum } from '../../lib/enums/ColorTypeEnum';

interface IProps extends PropsWithChildren {
  hasCancelButton: boolean;
  canSave: boolean;
  canCancel?: boolean;
  padding?: number;
  handleCancelClick?: () => void;
  handleSaveClick: () => void | Promise<void>;
}

const FormWrapper: React.FC<IProps> = (props) => {
  const {
    children,
    hasCancelButton,
    padding,
    canSave,
    canCancel,
    handleCancelClick,
    handleSaveClick,
  } = props;

  return (
    <Grid
      container
      style={{
        padding: `${padding}rem`,
        height: '100%',
      }}
    >
      <Grid item xs={12}>
        {children}
      </Grid>
      <Grid container justifyContent="flex-end" alignItems="flex-end">
        {hasCancelButton && handleCancelClick && (
          <SaveOrCancelButton
            title="Cancel"
            disabled={!canCancel}
            backgroundColor={ColorTypeEnum.Transparent}
            handleClick={handleCancelClick}
          />
        )}
        <SaveOrCancelButton
          title="Save"
          backgroundColor={ColorTypeEnum.Transparent}
          disabled={!canSave}
          handleClick={handleSaveClick}
        />
      </Grid>
    </Grid>
  );
};

export default FormWrapper;
