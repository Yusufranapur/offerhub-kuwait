import api from './api';

export const authService = {
  login: async (credentials: any) => {
    return api.post('/auth/login', credentials);
  },
  register: async (credentials: any) => {
    return api.post('/auth/register', credentials);
  }
};
