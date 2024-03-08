import React from "react";
import { StyledPageContent, StyledPageWrapper, StyledPaper } from "../styledComponents/StyledLayout";
import PageTitleLabel from "../labels/PageTitleLabel";
import { Grid } from "@mui/material";
import { IListItem } from "../../lib/interfaces/list/IListItem";
import { StyledList } from "../styledComponents/StyledLists";
import MenuListItem from "../list/listItems/MenuListItem";

interface IProps{
    pageTitle: string
    listItems: IListItem[]
    children: JSX.Element,
    selectedItem: number,
    handleItemClicked: (id: number) => void
}

const SettingsPageLayout: React.FC<IProps> = (props) =>{
    const {pageTitle, listItems, children, selectedItem, handleItemClicked} = props

    return(
        <StyledPageWrapper id="settings-page-wrapper">
            <PageTitleLabel id="settings-page-title" title={pageTitle} />
            <StyledPageContent container gap={2} justifyContent="center">
                <Grid item xs={2}>
                    <StyledPaper elevation={3} style={{padding:0}}>
                        <StyledList disablePadding>
                            {listItems.map((item, index) =>(
                                <MenuListItem 
                                    key={index} 
                                    selectedItemId={selectedItem} 
                                    item={item} 
                                    onClick={handleItemClicked}/>
                            ))}
                        </StyledList>
                    </StyledPaper>
                </Grid>
                <Grid item xs={9}>
                    {children}
                </Grid>
            </StyledPageContent>
        </StyledPageWrapper>
    )
}

export default SettingsPageLayout
 

 
