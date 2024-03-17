import React, { PropsWithChildren } from 'react';
import 'react-virtualized/styles.css';
import {
  StyledPageWrapper,
  StyledGridContainer,
  StyledGridItem,
  StyledPaperWrapper,
} from '../styledComponents/StyledWrappers';
import PageTitleLabel from '../labels/PageTitleLabel';

interface IProps extends PropsWithChildren {
  pageTitle: string;
  toolBar: JSX.Element;
}

const TableLayout: React.FC<IProps> = (props) => {
  const { children, pageTitle, toolBar } = props;
  return (
    <StyledPageWrapper height="100vh" paddingTop="5rem">
      <PageTitleLabel id="table-page-title" title={pageTitle} />
      <StyledGridContainer
        container
        marginTop="0rem"
        spacing={1}
        justifyContent="center"
      >
        <StyledGridItem item xs={11} marginTop="0rem" padding={0}>
          <StyledPaperWrapper elevation={3} height="75px">
            {toolBar}
          </StyledPaperWrapper>
        </StyledGridItem>
        <StyledGridItem marginTop="2rem" item xs={11}>
          <StyledPaperWrapper elevation={3} height="700px">
            {children}
          </StyledPaperWrapper>
        </StyledGridItem>
      </StyledGridContainer>
    </StyledPageWrapper>
  );
};

export default TableLayout;
