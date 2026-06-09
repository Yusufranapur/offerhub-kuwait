import { create } from 'zustand';

interface AuthState {
  isAuthenticated: boolean;
  user: any | null;
  token: string | null;
  login: (token: string, user: any) => void;
  logout: () => void;
}

export const useAuthStore = create<AuthState>((set) => ({
  isAuthenticated: !!localStorage.getItem('vendor_token'),
  user: JSON.parse(localStorage.getItem('vendor_user') || 'null'),
  token: localStorage.getItem('vendor_token'),
  login: (token, user) => {
    localStorage.setItem('vendor_token', token);
    localStorage.setItem('vendor_user', JSON.stringify(user));
    set({ isAuthenticated: true, user, token });
  },
  logout: () => {
    localStorage.removeItem('vendor_token');
    localStorage.removeItem('vendor_user');
    set({ isAuthenticated: false, user: null, token: null });
  },
}));
