import axios from 'axios';
import StorageService from '../services/StorageService';

const customAxios = axios.create({
  baseURL: 'https://ink-peddler-api.azurewebsites.net/api',
  headers: {
    Authorization: `Bearer ${await StorageService.getAccessToken()}`
  }
});

customAxios.interceptors.response.use(
  function (response) {
    console.log('success: ' + response)
    return response
  },
  function (error) {
    const errorResponse = error.response
    console.log('error: ' + error)
    if (isTokenExpiredError(errorResponse)) {
      return resetTokenAndReattemptRequest(error)
    }
    // If the error is due to other reasons, we just throw it back to axios
    return Promise.reject(error)
  }
)

function isTokenExpiredError(errorResponse) {
  // Your own logic to determine if the error is due to JWT token expired returns a boolean value
};

let isAlreadyFetchingAccessToken = false;
let subscribers = [];

function resetTokenAndReattemptRequest(error) {
  try {
    const { response: errorResponse } = error;
    const resetToken = await StorageService.getRefreshToken(); // Your own mechanism to get the refresh token to refresh the JWT token
    if (!resetToken) {
      // We can't refresh, throw the error anyway
      return Promise.reject(error);
    }
    /* Proceed to the token refresh procedure
    We create a new Promise that will retry the request,
    clone all the request configuration from the failed
    request in the error object. */
    const retryOriginalRequest = new Promise(resolve => {
      /* We need to add the request retry to the queue
      since there another request that already attempt to
      refresh the token */
      addSubscriber(access_token => {
        errorResponse.config.headers.Authorization = 'Bearer ' + access_token;
        resolve(axios(errorResponse.config));
      });
    });
    if (!isAlreadyFetchingAccessToken) {
      isAlreadyFetchingAccessToken = true;
      const response = await axios({
        method: 'post',
        url: 'Security/Token',
        data: {
          token: resetToken // Just an example, your case may vary
        }
      });
      console.log('Fetch Access Totken: ' + response)
      if (!response.data) {
        return Promise.reject(error);
      }
      const newToken = response.data.token;
      TStorageService.getRefreshToken(newToken); // save the newly refreshed token for other requests to use
      isAlreadyFetchingAccessToken = false;
      onAccessTokenFetched(newToken);
    }
    return retryOriginalRequest;
  } catch (err) {
    return Promise.reject(err);
  }
}

function onAccessTokenFetched(access_token) {
  // When the refresh is successful, we start retrying the requests one by one and empty the queue
  subscribers.forEach(callback => callback(access_token));
  subscribers = [];
}

function addSubscriber(callback) {
  subscribers.push(callback);
}

export default customAxios;