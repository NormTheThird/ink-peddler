import React, { useContext } from 'react';
import { StyleSheet, Text, TouchableOpacity, View } from 'react-native';
import AuthForm from '../components/AuthForm';
import { Context } from '../context/SecurityContext';
import AppStyles from '../styles/AppStyles';

const SigninScreen = ({ navigation }) => {
  const { state, signIn } = useContext(Context);

  return (
    <View style={AppStyles.mainView}>
      <AuthForm
        headerText="Sign In to your account"
        submitButtonText="Sign In"
        linkText="Need an account? Sign up here!"
        errorMessage={state.errorMessage}
        onSubmit={signIn}
        routeName="Signup"
        hidePassword={false}
      />
      <TouchableOpacity
        onPress={() => navigation.navigate('Forgot')}>
        <Text style={styles.linkTextStyle}>Forgot Password?</Text>
      </TouchableOpacity>
    </View>
  );
};

const styles = StyleSheet.create({
  linkTextStyle: {
    fontSize: 16,
    color: AppStyles.colors.textSecondary,
    textAlign: 'center',
    marginTop: 5
  },
});

export default SigninScreen;