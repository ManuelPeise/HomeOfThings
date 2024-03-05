import { Grid, Paper } from "@mui/material";
import React from "react";
import Title from "../../../components/labels/Title";
import TextInput from "../../../components/inputs/TextInput";
import useFormModel from "../../../hooks/useFormModel";
import { ILoginData } from "../../../lib/interfaces/auth/ILoginData";
import TextButton from "../../../components/buttons/TextButton";
import { isValidEmail } from "../../../lib/validation";
import { AuthContext } from "../../../hooks/auth/useAuth";
import { useI18n } from "../../../hooks/useI18n";
import { withTranslation } from "react-i18next";

const logInModel: ILoginData = {
  email: "",
  password: "",
};

const validationCallback = (model: ILoginData): boolean => {
  return isValidEmail(model.email) && model.password.length >= 8;
};

interface IProps {
  onComponentChange: (component: "login" | "register") => void;
}

const LoginContainer: React.FC<IProps> = (props) => {
  const { onComponentChange } = props;
  const { onLogin } = React.useContext(AuthContext);
  const { getResource } = useI18n();

  const { model, isValidModel, handleTextChange } = useFormModel<ILoginData>(
    logInModel,
    validationCallback
  );

  const handleLogin = React.useCallback(async () => {
    await onLogin(model);
  }, [model, onLogin]);

  const onNavigateToRegister = React.useCallback(() => {
    onComponentChange("register");
  }, [onComponentChange]);

  return (
    <Paper
      elevation={4}
      component="div"
      style={{ padding: "1rem", maxHeight: "60%" }}
    >
      <Title
        title={getResource("common.labelLogin")}
        variant="h5"
        padding="2"
      />
      <Grid container style={{ padding: "1rem 1rem" }}>
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
        <Grid
          style={{ marginTop: "1.5rem" }}
          justifyContent="space-around"
          container
        >
          <TextButton
            title={getResource("common.labelRegister")}
            disabled={false}
            onClick={onNavigateToRegister}
          />
          <TextButton
            title={getResource("common.labelOk")}
            disabled={!isValidModel}
            onClick={handleLogin}
          />
        </Grid>
      </Grid>
    </Paper>
  );
};

export default withTranslation("common")(LoginContainer);
