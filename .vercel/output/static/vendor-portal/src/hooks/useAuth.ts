import { useState } from 'react';
import { useAuthStore } from '../store/authStore';
import { authService } from '../services/authService';

export const useAuth = () => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const { login, logout, isAuthenticated, user } = useAuthStore();

  const handleLogin = async (credentials: any) => {
    setLoading(true);
    setError(null);
    try {
      const response: any = await authService.login(credentials);
      login(response.data.token, response.data.user);
    } catch (err: any) {
      setError(err.response?.data?.message || 'Login failed');
    } finally {
      setLoading(false);
    }
  };

  return { login: handleLogin, logout, isAuthenticated, user, loading, error };
};
