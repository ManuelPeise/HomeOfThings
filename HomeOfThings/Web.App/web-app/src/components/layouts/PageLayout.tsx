import React, { useContext } from 'react';
import { Outlet } from 'react-router-dom';
import AppToolBar from '../appBars/AppToolBar';
import {
  StyledPageBody,
  StyledPageContainer,
} from '../styledComponents/StyledLayout';
import { AuthContext } from '../../hooks/auth/useAuth';
import { userIsInRole } from '../../lib/accessRights';
import { UserRoleEnum } from '../../lib/enums/UserRoleEnum';

interface IProps {
  requiredUserRole: UserRoleEnum;
}

const PageLayout: React.FC<IProps> = (props) => {
  const { requiredUserRole } = props;

  const [userHasAccess, setUserHasAccess] = React.useState<boolean>(false);
  const [userRoles, setUserRoles] = React.useState<UserRoleEnum[]>([]);

  const { userData } = useContext(AuthContext);

  React.useEffect(() => {
    setUserRoles(userData?.userRoles ?? []);
  }, [userData]);

  React.useEffect(() => {
    setUserHasAccess(userIsInRole(requiredUserRole, userRoles));
  }, [requiredUserRole, userRoles]);

  console.log('Has Access: ', userHasAccess);

  return (
    <StyledPageContainer>
      <AppToolBar userRoles={userRoles} />
      <StyledPageBody>
        <Outlet />
      </StyledPageBody>
    </StyledPageContainer>
  );
};

export default PageLayout;
