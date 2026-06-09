import api from './api';

export const authService = {
  login: async (credentials: any) => {
    // Temporary mock for UI testing so user can log in with any password
    return {
      data: {
        token: "mock-jwt-token-12345",
        user: {