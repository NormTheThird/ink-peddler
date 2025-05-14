import React, { useState } from 'react';
import { StyleSheet, Text, TextInput, TouchableOpacity } from 'react-native';
import { withNavigation } from 'react-navigation';
import AppStyles from '../styles/AppStyles';

const AuthForm = ({ navigation, headerText, submitButtonText, linkText, errorMessage, onSubmit, routeName, hidePassword }) => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  return (
    <>
      <Text style={styles.headerTextStyle}>{headerText}</Text>
      <TextInput
        style={styles.inputStyle}
        placeholder="email"
        placeholderTextColor={AppStyles.colors.textPlaceHolder}
        label="Email"
        value={email}
        autoCapitalize="none"
        autoCorrect={false}
        onChangeText={setEmail} />
      {
        hidePassword ? null :
          <TextInput
            style={styles.inputStyle}
            placeholder="password"
            placeholderTextColor={AppStyles.colors.textPlaceHolder}
            label="Password"
            value={password}
            autoCapitalize="none"
            secureTextEntry
            autoCorrect={false}
            onChangeText={setPassword}
          />
      }

      {errorMessage ? <Text style={styles.errorMessage}>{errorMessage}</Text> : null}
      <TouchableOpacity
        onPress={() => onSubmit({ email, password })} >
        <Text style={styles.buttonTextStyle}>{submitButtonText}</Text>
      </TouchableOpacity>

      <TouchableOpacity
        onPress={() => navigation.navigate(routeName)}>
        <Text style={styles.linkTextStyle}>{linkText}</Text>
      </TouchableOpacity>
    </>
  );
};

const styles = StyleSheet.create({
  headerTextStyle: {
    fontSize: 18,
    color: AppStyles.colors.textPrimary,
    textAlign: 'center',
    marginBottom: 30,
    paddingTop: 200
  },
  inputStyle: {
    color: AppStyles.colors.inputPrimary,
    borderColor: AppStyles.colors.inputPrimary,
    borderBottomWidth: 1,
    marginHorizontal: 80,
    marginVertical: 10,
    padding: 10
  },
  buttonTextStyle: {
    fontSize: 22,
    color: "#ffffff",
    textAlign: 'center',
    marginTop: 15
  },
  linkTextStyle: {
    fontSize: 16,
    color: AppStyles.colors.textSecondary,
    textAlign: 'center',
    marginTop: 30
  },
  errorMessage: {
    fontSize: 16,
    color: 'red',
    marginLeft: 15,
    marginTop: 15
  },
});

export default withNavigation(AuthForm);