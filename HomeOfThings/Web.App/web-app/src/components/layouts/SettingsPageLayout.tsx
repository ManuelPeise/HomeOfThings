import React from 'react';
import {
  StyledPageContent,
  StyledPageWrapper,
  StyledPaper,
} from '../styledComponents/StyledLayout';
import PageTitleLabel from '../labels/PageTitleLabel';
import { Grid, List, Paper } from '@mui/material';
import { IListItem } from '../../lib/interfaces/list/IListItem';
import { StyledList } from '../styledComponents/StyledLists';
import MenuListItem from '../list/listItems/MenuListItem';

interface IProps {
  pageTitle: string;
  listItems: IListItem[];
  children: JSX.Element;
  selectedItem: number;
  handleItemClicked: (id: number) => void;
}

const SettingsPageLayout: React.FC<IProps> = (props) => {
  const { pageTitle, listItems, children, selectedItem, handleItemClicked } =
    props;

  return (
    <StyledPageWrapper id="settings-page-wrapper">
      <PageTitleLabel id="settings-page-title" title={pageTitle} />
      <StyledPageContent container spacing={3} justifyContent="space-around">
        <Grid item xs={12} md={2}>
          <Paper
            elevation={3}
            style={{
              width: '100%',
              height: '100%',
              padding: 0,
            }}
          >
            <List
              disablePadding
              style={{ minWidth: '250px', maxWidth: '100%' }}
            >
              {listItems.map((item, index) => (
                <MenuListItem
                  key={index}
                  selectedItemId={selectedItem}
                  item={item}
                  onClick={handleItemClicked}
                />
              ))}
            </List>
          </Paper>
        </Grid>
        <Grid item xs={12} md={9}>
          <Paper
            elevation={3}
            style={{ width: '100%', height: '100%', padding: 0 }}
          >
            {children}
          </Paper>
        </Grid>
      </StyledPageContent>
    </StyledPageWrapper>
  );
};

export default SettingsPageLayout;
