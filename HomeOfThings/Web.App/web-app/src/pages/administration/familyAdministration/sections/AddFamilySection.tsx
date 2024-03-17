import { Grid, ListItem } from '@mui/material';
import React from 'react';
import { StyledList } from '../../../../components/styledComponents/StyledLists';
import { IFamilyRegistration } from '../interfaces/IFamily';
import useFormModel from '../../../../hooks/useFormModel';
import UnderlinedTextInput from '../../../../components/inputs/textBoxes/UnderlinedTextInput';
import { useI18n } from '../../../../hooks/useI18n';
import Title from '../../../../components/labels/Title';
import { ColorTypeEnum } from '../../../../lib/enums/ColorTypeEnum';
import { IUserRegistration } from '../../../../lib/interfaces/auth/IUserData';
import DateInput from '../../../../components/inputs/datePickers/DateInput';
import FormWrapper from '../../../../components/wrappers/FormWrapper';
import { isValidEmail } from '../../../../lib/validation';
import { useStatelessApi } from '../../../../hooks/api/useStatelessApi';
import { ApiEndpointEnum } from '../../../../lib/enums/ApiEndpointEnum';
import { UserRoleEnum } from '../../../../lib/enums/UserRoleEnum';

interface IProps {
  selectedSection: number;
  sectionId: number;
}

const familyModel: IFamilyRegistration = {
  familyId: -1,
  familyGuid: '',
  name: '',
  userRegistrationModel: {} as IUserRegistration,
  createdAt: '',
  createdBy: '',
  isActive: false,
};

const userModel: IUserRegistration = {
  userId: -1,
  firstName: '',
  lastName: '',
  email: '',
  dateOfBirth: null,
  userRole: UserRoleEnum.Admin,
  isActive: true,
};

const familyValidationCallback = (family: IFamilyRegistration) => {
  return family.name.length > 0;
};

const userValidationCallback = (user: IUserRegistration) => {
  return (
    user.firstName !== '' &&
    user.lastName !== '' &&
    isValidEmail(user.email) &&
    user.dateOfBirth !== null
  );
};
const AddFamilySection: React.FC<IProps> = (props) => {
  const { sectionId, selectedSection } = props;
  const { getResource } = useI18n();

  const saveApi = useStatelessApi<boolean>().create({
    serviceUrl: ApiEndpointEnum.SaveFamily,
    requestOptions: {
      method: 'POST',
      mode: 'cors',
    },
    parameters: '',
  });

  const familyForm = useFormModel<IFamilyRegistration>(
    familyModel,
    familyValidationCallback
  );
  const userForm = useFormModel<IUserRegistration>(
    userModel,
    userValidationCallback
  );

  const handleCancel = React.useCallback(() => {
    familyForm.handleReset();
    userForm.handleReset();
  }, [familyForm, userForm]);

  React.useEffect(() => {
    if (sectionId === selectedSection) {
      handleCancel();
    }
    // eslint-disable-next-line
  }, [sectionId, selectedSection]);

  const handleSave = React.useCallback(async () => {
    if (familyForm.isValidModel === true && userForm.isValidModel === true) {
      const model = familyForm.model;
      model.userRegistrationModel = userForm.model;

      var result = await saveApi.postWithContent({
        serviceUrl: ApiEndpointEnum.SaveFamily,
        requestOptions: {
          method: 'POST',
          mode: 'cors',
          body: JSON.stringify(model),
        },
        parameters: '',
      });

      if (result === true) {
        handleCancel();
      }
    }
  }, [familyForm, userForm, saveApi, handleCancel]);

  const canSave = React.useMemo(() => {
    return familyForm.isValidModel === true && userForm.isValidModel === true;
  }, [familyForm, userForm]);

  const canCancel = React.useMemo(() => {
    return (
      JSON.stringify(userForm.model) !== JSON.stringify(userModel) ||
      JSON.stringify(familyForm.model) !== JSON.stringify(familyModel)
    );
  }, [familyForm, userForm]);

  if (sectionId !== selectedSection) {
    return null;
  }

  return (
    <FormWrapper
      padding={2}
      canSave={canSave}
      canCancel={canCancel}
      hasCancelButton={true}
      handleSaveClick={handleSave}
      handleCancelClick={handleCancel}
    >
      <StyledList disablePadding>
        <ListItem divider>
          <Grid container columnGap={3}>
            <Grid item xs={12}>
              <Title
                title={getResource('administration.labelAddNewFamily')}
                justify="flex-start"
                variant="h4"
                padding="1rem"
                fontStyle="italic"
                fontFamily="cursive"
                textColor={ColorTypeEnum.LightBlue}
              />
            </Grid>
          </Grid>
        </ListItem>
        <ListItem divider>
          <Grid container columnGap={3}>
            <Grid item xs={12} style={{ marginTop: '1.5rem' }}>
              <Title
                title={getResource('administration.labelFamily')}
                justify="flex-start"
                variant="h5"
                padding=".5rem"
                fontStyle="italic"
                fontFamily="sans-serif"
                textColor={ColorTypeEnum.LightBlue}
              />
            </Grid>
            <Grid item xs={12} style={{ marginTop: '1.5rem' }}>
              <UnderlinedTextInput
                property="name"
                required={true}
                title={getResource('administration.labelFamilyName')}
                padding={8}
                fullWidth
                alignValue="start"
                value={familyForm.model.name}
                handleChange={familyForm.handleTextChanged}
              />
            </Grid>
          </Grid>
        </ListItem>
        <ListItem divider>
          <Grid container rowGap={3} justifyContent="center">
            <Grid item xs={12} style={{ marginTop: '1.5rem' }}>
              <Title
                title={getResource('administration.labelFamilyAdmin')}
                justify="flex-start"
                variant="h5"
                padding=".5rem"
                fontStyle="italic"
                fontFamily="sans-serif"
                textColor={ColorTypeEnum.LightBlue}
              />
            </Grid>
            <Grid item xs={6}>
              <UnderlinedTextInput
                property="firstName"
                required={true}
                type="text"
                title={getResource('administration.labelFirstName')}
                fullWidth
                padding={8}
                alignValue="start"
                value={userForm.model.firstName}
                handleChange={userForm.handleTextChanged}
              />
            </Grid>
            <Grid item xs={6}>
              <UnderlinedTextInput
                property="lastName"
                required={true}
                type="text"
                title={getResource('administration.labelLastName')}
                fullWidth
                padding={8}
                alignValue="start"
                value={userForm.model.lastName}
                handleChange={userForm.handleTextChanged}
              />
            </Grid>
            <Grid item xs={6}>
              <UnderlinedTextInput
                property="email"
                required={true}
                type="text"
                title={getResource('administration.labelEmail')}
                fullWidth
                padding={8}
                alignValue="start"
                value={userForm.model.email}
                handleChange={userForm.handleTextChanged}
              />
            </Grid>
            <Grid item xs={6}>
              <DateInput
                property="dateOfBirth"
                title={getResource('administration.labelDateOfBirth')}
                fullWidth
                disableFuture
                paddingRight={20}
                date={null}
                handleDateChanged={userForm.handleDateChanged}
              />
            </Grid>
          </Grid>
        </ListItem>
      </StyledList>
    </FormWrapper>
  );
};

export default AddFamilySection;
