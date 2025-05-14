import React, { useContext } from 'react';
import { View } from 'react-native';
import AuthForm from '../components/AuthForm';
import { Context as SecurityContext } from '../context/SecurityContext';
import AppStyles from '../styles/AppStyles';

const ForgotPasswordScreen = ({ navigation }) => {
  const { state, resetPassword } = useContext(SecurityContext);

  return (
    <View style={AppStyles.mainView}>
      <AuthForm
        headerText="Reset your password"
        submitButtonText="Reset"
        linkText="Back to sign in"
        errorMessage={state.errorMessage}
        onSubmit={resetPassword}
        routeName="Signin"
        hidePassword={true}
      />
    </View>
  );
};

export default ForgotPasswordScreen;