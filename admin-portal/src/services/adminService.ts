import api from './api';

export interface Vendor {
  id: string;
  name: string;
  nameAr: string;
  contactEmail: string;
  contactPhone: string;
  status: number; // 0 = Pending, 1 = Active, 2 = Suspended, etc.
  createdAt: string;
  
  // Verification Data
  businessCategoryId?: string;
  businessType?: string;
  civilIdNumber?: string;
  commercialRegistrationNo?: string;
  beneficiaryNameEn?: string;
  beneficiaryNameAr?: string;
  bankName?: string;
  ibanNumber?: string;

  // Documents
  commercialLicenseUrl?: string;
  memorandumOfAssociationUrl?: string;
  authPersonCivilIdFrontUrl?: string;
  authPersonCivilIdBackUrl?: string;
  signedTermsAndConditionsUrl?: string;
  extractCommercialRegistryUrl?: string;
  authSignatoryCertificateUrl?: string;
  bankAccountNumberPdfUrl?: string;
}

export const adminService = {
  getPendingVendors: async (): Promise<Vendor[]> => {
    // In a real app we would pass filters `?status=Pending`
    // Mocking an array here temporarily to support UI testing
    return [
      {
        id: "v1-pending",
        name: "Test Vendor LLC",
        nameAr: "اختبار شركة",
        contactEmail: "pending@vendor.com",
        contactPhone: "+96512345678",
        status: 0,
        createdAt: new Date().toISOString(),
        businessType: "LLC",
        civilIdNumber: "290123456789",
        commercialRegistrationNo: "CR-998877",
        beneficiaryNameEn: "Test Vendor",
        beneficiaryNameAr: "اختبار بائع",
        bankName: "National Bank of Kuwait",
        ibanNumber: "KW12NBOK12345678901234567890",
        commercialLicenseUrl: "https://example.com/license.pdf",
        signedTermsAndConditionsUrl: "https://example.com/terms.pdf",
        authPersonCivilIdFrontUrl: "https://example.com/front.png",
      }
    ];
    // return api.get('/Vendors?status=Pending').then(res => res.data);
  },

  getVendorById: async (id: string): Promise<Vendor> => {
    const list = await adminService.getPendingVendors();
    return list.find(v => v.id === id) || list[0];
    // return api.get(`/Vendors/${id}`).then(res => res.data);
  },

  approveVendor: async (id: string) => {
    return api.put(`/Vendors/${id}/approve`, null, {
      baseURL: import.meta.env.VITE_API_URL || '/api'
    });
  },

  rejectVendor: async (id: string, reason: string) => {
    return api.put(`/Vendors/${id}/reject`, { reason }, {
      baseURL: import.meta.env.VITE_API_URL || '/api'
    });
  }
};
