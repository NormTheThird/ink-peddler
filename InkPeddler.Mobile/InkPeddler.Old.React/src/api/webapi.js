import axios from 'axios';

export default axios.create({
  baseURL: 'https://ink-peddler-api.azurewebsites.net/api',
  headers: {
    Authorization: 'Bearer '
  }
});