import { create } from 'zustand';

interface VendorState {
  profile: any | null;
  setProfile: (profile: any) => void;
}

export const useVendorStore = create<VendorState>((set) => ({
  profile: null,
  setProfile: (profile) => set({ profile }),
}));
