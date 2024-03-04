import React from "react";
import {
  StyledAppBar,
  StyledDrawer,
  StyledDrawerContainer,
  StyledDrawerList,
  StyledGrid,
  StyledIconButton,
  StyledToolBar,
} from "../styledComponents";
import { Box, CssBaseline, Divider, Grid } from "@mui/material";
import { Menu, ArrowBackOutlined } from "@mui/icons-material";
import Title from "../labels/Title";
import TextButton from "../buttons/TextButton";
import CollapsibleSideMenuItem from "../list/listItems/CollapsibleSideMenuItem";
import { useSideMenu } from "../../hooks/useSideMenu";
import { AuthContext } from "../../hooks/auth/useAuth";
import { ColorTypeEnum } from "../../lib/enums/ColorTypeEnum";
import { FontSizeEnum } from "../../lib/enums/FontSizeEnum";
import { useNavigate } from "react-router-dom";
import { RouteTypeEnum } from "../../lib/enums/RouteTypeEnum";

const AppToolBar: React.FC = () => {
  const { userData } = React.useContext(AuthContext);

  const [drawerOpen, setDrawerOpen] = React.useState<boolean>(false);
  const [selectedItem, setSelectedItem] = React.useState<number | null>(null);
  const { menuItems } = useSideMenu(userData);
  const navigate = useNavigate();

  const navigateToAuth = React.useCallback(() => {
    navigate(RouteTypeEnum.Auth);
  }, [navigate]);

  const navigateToAccount = React.useCallback(() => {
    navigate(RouteTypeEnum.Account);
  }, [navigate]);
  const toggleDrawer = React.useCallback((state?: boolean) => {
    if (state !== undefined) {
      setDrawerOpen(state);

      return;
    }

    setDrawerOpen((prev) => !prev);
  }, []);

  const handleSelectItem = React.useCallback((key: number) => {
    setSelectedItem(key);
  }, []);

  return (
    <Grid item xs={12}>
      <Box sx={{ display: "flex" }}>
        <CssBaseline />
        <StyledAppBar>
          <StyledToolBar>
            <StyledIconButton
              style={{ color: "#ffffff" }}
              onClick={toggleDrawer.bind(null, !drawerOpen)}
            >
              <Menu />
            </StyledIconButton>
            <Title
              title="My App"
              fontSize={FontSizeEnum.MD}
              padding="1"
              justify="flex-start"
            />
            {userData?.email !== undefined ? (
              <TextButton
                title={userData.email}
                color={ColorTypeEnum.LightGray}
                onClick={navigateToAccount}
              />
            ) : (
              <TextButton
                title="Anmelden"
                color={ColorTypeEnum.White}
                onClick={navigateToAuth}
              />
            )}
          </StyledToolBar>
        </StyledAppBar>
        <StyledDrawer keepMounted open={drawerOpen}>
          <StyledDrawerContainer
            style={{ backgroundColor: "#000000" }}
            role="presentation"
          >
            <StyledGrid container>
              <StyledGrid container justifyContent="flex-end">
                <StyledIconButton
                  style={{ padding: "1rem", color: "#ffffff" }}
                  onClick={toggleDrawer.bind(null, false)}
                >
                  <ArrowBackOutlined style={{ color: ColorTypeEnum.White }} />
                </StyledIconButton>
              </StyledGrid>
              <StyledGrid container style={{ paddingLeft: "16px" }}>
                <Title
                  title={process.env.REACT_APP_TITLE ?? ""}
                  textColor={ColorTypeEnum.White}
                  justify="flex-start"
                  fontSize={FontSizeEnum.MD}
                  padding="0"
                />
              </StyledGrid>
              <StyledGrid container style={{ paddingLeft: "16px" }}>
                <Title
                  title={process.env.REACT_APP_SUB_TITLE ?? ""}
                  textColor={ColorTypeEnum.LightGray}
                  justify="flex-start"
                  fontSize={FontSizeEnum.SM}
                  padding="0"
                />
              </StyledGrid>
            </StyledGrid>
            <Divider
              style={{
                marginTop: FontSizeEnum.SM,
                marginBottom: FontSizeEnum.SM,
                backgroundColor: ColorTypeEnum.White,
              }}
              variant="middle"
            />
            <StyledDrawerList disablePadding>
              {menuItems.map((item, index) => {
                return (
                  <CollapsibleSideMenuItem
                    id={item.key}
                    key={index}
                    title={item.title}
                    textSize={item.textSize}
                    textColor={item.textColor}
                    icon={item.icon}
                    iconColor={item.iconColor}
                    isExpanded={selectedItem === item.key}
                    subItems={item.sumItems}
                    onClose={toggleDrawer}
                    onClick={handleSelectItem}
                  />
                );
              })}
            </StyledDrawerList>
          </StyledDrawerContainer>
        </StyledDrawer>
      </Box>
    </Grid>
  );
};

export default AppToolBar;
