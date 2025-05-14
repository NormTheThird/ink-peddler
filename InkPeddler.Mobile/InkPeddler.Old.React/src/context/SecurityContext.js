import { AsyncStorage } from 'react-native';
import { navigate } from '../navigationRef';
import createDataContext from './createDataContext';

const securityReducer = (state, action) => {
  switch (action.type) {
    case 'addError':
      return { ...state, errorMessage: "An error has occured" }
    case 'authenticated':
      return { token: action.payload, errorMessage: "" }
    case 'clearErrorMessage':
      return { ...state, errorMessage: "" }
    case 'signout':
      return { token: null, errorMessage: "" }
    default:
      return state;
  }
};

const resolveAuthentication = (dispatch) => async () => {
  const token = await AsyncStorage.getItem('token');
  if (token) {
    dispatch({ type: 'authenticated', payload: token });
    navigate('Home');
  }
  else {
    //navigate('mainNonAuthenticatedFlow');
    navigate('loginFlow');
  }
};

const signUp = (dispatch) => async ({ email, password }) => {
  try {
    //const response = await trackerApi.post('/signup', { email, password });
    //await AsyncStorage.setItem('token', response.data.token);
    //dispatch({ type: 'addError', payload: response.data.token });
    navigate('Home');
  } catch (error) {
    dispatch({ type: 'addError', payload: error.response.status });
  }
};

const signIn = (dispatch) => async ({ email, password }) => {
  try {
    // Try to signin
    // Handle success but updating state
    // Handle failure by shwoing error message (somehow)
    navigate('Home');
  } catch (error) {

  }
};

const signOut = (dispatch) => () => {
  // Handle signout
};

const resetPassword = (dispatch) => () => {
  // Handle signout
};

const actions = { resolveAuthentication, signUp, signIn, signOut, resetPassword };
export const { Context, Provider } = createDataContext(securityReducer, actions, { token: null, errorMessage: '' });