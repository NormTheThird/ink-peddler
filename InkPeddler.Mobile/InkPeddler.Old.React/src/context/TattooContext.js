import webapi from '../api/webapi';
import createDataContext from './createDataContext';

const tattooReducer = (state, action) => {
  switch (action.type) {
    case 'getTattoos':
      return action.payload;
    default:
      return state;
  }
};

const getTattoos = dispatch => {
  return async () => {
    const data = { pageNumber: 1, searchValue: "" };
    webapi.post('/Tattoo/GetTattoosPerPageBySearchValue', data)
      .then(response => {
        if (response.data.IsSuccess) {
          dispatch({ type: 'getTattoos', payload: response.data.Tattoos })
        }
      })
  };
};

const actions = { getTattoos };
export const { Context, Provider } = createDataContext(tattooReducer, actions, []);