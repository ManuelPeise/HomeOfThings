import { Grid, Paper } from "@mui/material";
import React from "react";
import Title from "../../../components/labels/Title";
import TextInput from "../../../components/inputs/TextInput";
import useFormModel from "../../../hooks/useFormModel";
import { IRegisterData } from "../../../lib/interfaces/auth/IRegisterData";
import TextButton from "../../../components/buttons/TextButton";
import { useStatelessApi } from "../../../hooks/api/useStatelessApi";
import { ApiEndpointEnum } from "../../../lib/enums/ApiEndpointEnum";
import { useNavigate } from "react-router-dom";
import { isValidEmail } from "../../../lib/validation";
import { RouteTypeEnum } from "../../../lib/enums/RouteTypeEnum";
import { useI18n } from "../../../hooks/useI18n";

const registerModel: IRegisterData = {
  firstName: "",
  lastName: "",
  email: "",
  password: "",
  passwordConfirmation: "",
};

const validationCallback = (model: IRegisterData) => {
  return (
    model.firstName.length > 0 &&
    model.lastName.length > 0 &&
    isValidEmail(model.email) &&
    model.password.length >= 8 &&
    model.password === model.passwordConfirmation
  );
};

interface IProps {
  onComponentChange: (component: "login" | "register") => void;
}

const RegisterComponent: React.FC<IProps> = (props) => {
  const { onComponentChange } = props;
  const { getResource } = useI18n();
  const navigate = useNavigate();

  const apiService = useStatelessApi<boolean>().create({
    serviceUrl: ApiEndpointEnum.PostRegistration,
    parameters: "",
    requestOptions: {
      method: "POST",
      body: "",
    },
  });

  const { model, isValidModel, handleReset, handleTextChange } =
    useFormModel<IRegisterData>(registerModel, validationCallback);

  const onNavigateToLogin = React.useCallback(() => {
    onComponentChange("login");
  }, [onComponentChange]);

  const onRegister = React.useCallback(async () => {
    const response = await apiService.postWithContent({
      requestOptions: {
        method: "POST",
        mode: "cors",
        body: JSON.stringify(model),
      },
    });

    if (response) {
      handleReset();

      navigate(RouteTypeEnum.Auth);
    }
  }, [apiService, model, handleReset, navigate]);

  return (
    <Paper
      elevation={4}
      component="div"
      style={{ padding: "1rem", maxHeight: "60%" }}
    >
      <Title
        title={getResource("common.labelRegister")}
        variant="h5"
        padding="2"
      />
      <Grid container style={{ padding: "1rem 1rem" }}>
        <Grid container style={{ marginTop: ".5rem" }}>
          <TextInput
            fullWidth
            title={getResource("common.labelFirstName")}
            type="text"
            value={model.firstName}
            onChange={(e) => handleTextChange(e, "firstName")}
          />
        </Grid>
        <Grid container style={{ marginTop: ".5rem" }}>
          <TextInput
            fullWidth
            title={getResource("common.labelLastName")}
            type="text"
            value={model.lastName}
            onChange={(e) => handleTextChange(e, "lastName")}
          />
        </Grid>
        <Grid container style={{ marginTop: ".5rem" }}>
          <TextInput
            fullWidth
            title={getResource("common.labelEmail")}
            type="text"
            value={model.email}
            onChange={(e) => handleTextChange(e, "email")}
          />
        </Grid>
        <Grid container style={{ marginTop: ".5rem" }}>
          <TextInput
            fullWidth
            title={getResource("common.labelPassword")}
            type="password"
            value={model.password}
            onChange={(e) => handleTextChange(e, "password")}
          />
        </Grid>
        <Grid container style={{ marginTop: ".5rem" }}>
          <TextInput
            fullWidth
            title={getResource("common.labelConfirmPassword")}
            type="password"
            value={model.passwordConfirmation}
            onChange={(e) => handleTextChange(e, "passwordConfirmation")}
          />
        </Grid>
        <Grid
          style={{ marginTop: "1.5rem" }}
          justifyContent="space-around"
          container
        >
          <TextButton
            title={getResource("common.labelLogin")}
            disabled={false}
            onClick={onNavigateToLogin}
          />
          <TextButton
            title={getResource("common.labelRegister")}
            disabled={!isValidModel}
            onClick={onRegister}
          />
        </Grid>
        <Grid container></Grid>
      </Grid>
    </Paper>
  );
};

export default RegisterComponent;
