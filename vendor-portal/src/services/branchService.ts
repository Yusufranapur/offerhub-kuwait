import api from './api';

export const branchService = {
  getBranches: async () => {
    return new Promise((resolve) => {
      setTimeout(() => {
        resolve({
          data: [
            { id: 1, name: 'Salmiya Branch', address: 'Salem Al Mubarak St', status: 'Active' },
            { id: 2, name: 'Kuwait City', address: 'Fahad Al Salem St', status: 'Active' },
          ]
        });
      }, 500);
    });
  },
};
