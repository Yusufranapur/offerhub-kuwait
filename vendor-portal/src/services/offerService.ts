import api from './api';

export const offerService = {
  getOffers: async () => {
    return api.get('/offers');
  },
  createOffer: async (data: any) => {
    return api.post('/offers', data);
  }
};
