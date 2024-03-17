import React, { PropsWithChildren } from 'react';
import {
  StyledPageWrapper,
  StyledGridContainer,
  StyledGridItem,
  StyledPaperWrapper,
} from '../styledComponents/StyledWrappers';
import { IListItem } from '../../lib/interfaces/list/IListItem';
import PageTitleLabel from '../labels/PageTitleLabel';
import { List } from '@mui/material';
import MenuListItem from '../list/listItems/MenuListItem';

interface IProps extends PropsWithChildren {
  pageTitle: string;
  listItems: IListItem[];
  selectedItem: number;
  handleItemClicked: (id: number) => void;
}

const SettingsLayout: React.FC<IProps> = (props) => {
  const { children, pageTitle, listItems, selectedItem, handleItemClicked } =
    props;
  return (
    <StyledPageWrapper height="100vh" width="100%" paddingTop="5rem">
      <PageTitleLabel id="settings-page-title" title={pageTitle} />
      <StyledGridContainer
        container
        spacing={1}
        columnGap={6}
        marginTop="1rem"
        height="100%"
        justifyContent="center"
      >
        <StyledGridItem item xs={2}>
          <StyledPaperWrapper elevation={3} height="800px">
            <List disablePadding>
              {listItems.map((item, index) => (
                <MenuListItem
                  key={index}
                  selectedItemId={selectedItem}
                  item={item}
                  onClick={handleItemClicked}
                />
              ))}
            </List>
          </StyledPaperWrapper>
        </StyledGridItem>
        <StyledGridItem item xs={9}>
          <StyledPaperWrapper elevation={3} height="800px">
            {children}
          </StyledPaperWrapper>
        </StyledGridItem>
      </StyledGridContainer>
    </StyledPageWrapper>
  );
};

export default SettingsLayout;
