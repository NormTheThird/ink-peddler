import React from 'react';
import { createAppContainer, createSwitchNavigator } from 'react-navigation';
import { createStackNavigator } from 'react-navigation-stack';
import { createBottomTabNavigator } from 'react-navigation-tabs';
import { Provider as SecurityProvider } from './src/context/SecurityContext';
import { Provider as TattooProvider } from './src/context/TattooContext';
import { setNavigator } from './src/navigationRef';
import ForgotPasswordScreen from './src/screens/ForgotPasswordScreen';
import HomeScreen from './src/screens/HomeScreen';
import MapScreen from './src/screens/MapScreen';
import ProfileScreen from './src/screens/ProfileScreen';
import ResolveAuthScreen from './src/screens/ResolveAuthScreen';
import SigninScreen from './src/screens/SigninScreen';
import SignupScreen from './src/screens/SignupScreen';
import TattooScreen from './src/screens/TattooScreen';
import AppStyles from './src/styles/AppStyles';

const signInFlow = createStackNavigator({
  Signin: SigninScreen,
  Forgot: ForgotPasswordScreen
}, {
  initialRouteName: 'Signin',
  defaultNavigationOptions: {
    header: null
  }
});

const loginFlow = createStackNavigator({
  signInFlow: signInFlow,
  Signup: SignupScreen,
}, {
  initialRouteName: 'signInFlow',
  defaultNavigationOptions: {
    header: null
  }
});

const homeFlow = createStackNavigator({
  Home: HomeScreen,
  Tattoo: TattooScreen
});

const tabBarOptions = {
  style: {
    backgroundColor: AppStyles.colors.background,
    color: AppStyles.colors.textPrimary
  }
};

const mainNonAuthenticatedFlow = createBottomTabNavigator({
  homeFlow: homeFlow,
  Map: MapScreen
}, {
  tabBarOptions: tabBarOptions
});

const mainAuthenticatedFlow = createBottomTabNavigator({
  homeFlow: homeFlow,
  Map: MapScreen,
  Profile: ProfileScreen,
}, {
  tabBarOptions: tabBarOptions
});

const navigator = createSwitchNavigator({
  ResolveAuth: ResolveAuthScreen,
  loginFlow: loginFlow,
  mainNonAuthenticatedFlow: mainNonAuthenticatedFlow,
  mainAuthenticatedFlow: mainAuthenticatedFlow
});

const App = createAppContainer(navigator);

export default () => {
  return (
    <TattooProvider>
      <SecurityProvider>
        <App ref={(navigator) => { setNavigator(navigator) }} />
      </SecurityProvider>
    </TattooProvider>
  );
};