import React from 'react';
import { IFamily } from '../interfaces/IFamily';
import SingleCheckbox from '../../../../components/inputs/checkBoxes/SingleCheckBox';
import { Grid, ListItem, ListItemButton, ListItemText } from '@mui/material';
import { useI18n } from '../../../../hooks/useI18n';

interface IProps {
  index: number;
  family: IFamily;
  isActive: boolean;
  handleCheckedChanged: (isActive: boolean, index: number) => void;
}

const FamilyListItem: React.FC<IProps> = (props) => {
  const { index, isActive, family, handleCheckedChanged } = props;

  const { getResource } = useI18n();
  const style = {
    item: {
      display: 'flex',
      justifyContent: 'space-between',
    },
    iconButton: {
      marginRight: '1rem',
    },
  };

  return (
    <ListItem key={family.familyId} style={style.item}>
      <ListItemButton role={undefined}>
        <SingleCheckbox
          property="isActive"
          checked={isActive}
          handleChange={handleCheckedChanged.bind(null, !isActive, index)}
          label="IsActive"
        />
        <Grid container>
          <Grid item xs={4}>
            <ListItemText>{family.name}</ListItemText>
          </Grid>
          <Grid item xs={4}>
            <ListItemText>{`${getResource('administration.labelCreatedAt')}\t ${
              family.createdAt
            }`}</ListItemText>
          </Grid>
          <Grid item xs={4}>
            {' '}
            <ListItemText>{`${getResource('administration.labelCreatedBy')}\t ${
              family.createdBy
            }`}</ListItemText>
          </Grid>
        </Grid>
      </ListItemButton>
    </ListItem>
  );
};

export default FamilyListItem;
