import { AsyncStorage } from 'react-native';

const StorageService = {
  setAccessToken: function (token) { AsyncStorage.setItem('access-token', token); },
  getAccessToken: function () { return AsyncStorage.getItem('access-token'); },
  setRefreshToken: function (token) { AsyncStorage.setItem('refresh-token', token); },
  getRefreshToken: function () { return AsyncStorage.getItem('access-token'); },
};

export default StorageService;