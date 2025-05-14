import React, { useContext } from 'react';
import { View } from 'react-native';
import AuthForm from '../components/AuthForm';
import { Context } from '../context/SecurityContext';
import AppStyles from '../styles/AppStyles';

const SignupScreen = ({ navigation }) => {
  const { state, signUp } = useContext(Context);

  return (
    <View style={AppStyles.mainView}>
      <AuthForm
        headerText="Create an Account"
        submitButtonText="Sign Up"
        linkText="Already have an account? Sign in here!"
        errorMessage={state.errorMessage}
        onSubmit={signUp}
        routeName="Signin"
        hidePassword={false} />
    </View>
  );
};

export default SignupScreen;