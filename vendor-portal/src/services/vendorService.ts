import api from './api';

export interface VerificationData {
  vendorId: string;
  businessCategoryId: string | null;
  businessType: string;
  civilIdNumber: string;
  commercialRegistrationNo: string;
  licenseExpiryDate?: string;
  beneficiaryNameEn: string;
  beneficiaryNameAr: string;
  bankName: string;
  ibanNumber: string;
  // File URLs
  commercialLicenseUrl?: string;
  memorandumOfAssociationUrl?: string;
  authPersonCivilIdFrontUrl?: string;
  authPersonCivilIdBackUrl?: string;
  signedTermsAndConditionsUrl?: string;
  extractCommercialRegistryUrl?: string;
  authSignatoryCertificateUrl?: string;
  bankAccountNumberPdfUrl?: string;
}

export const vendorService = {
  uploadFile: async (file: File): Promise<string> => {
    const formData = new FormData();
    formData.append('file', file);
    
    // Using the generic /api/Files/upload endpoint we built
    const response = await api.post('/Files/upload', formData, {
      headers: {
        'Content-Type': 'multipart/form-data',
      },
      baseURL: import.meta.env.VITE_API_URL || '/api', // override default vendor base URL
    });
    
    return response.data.Url;
  },

  updateVerification: async (vendorId: string, data: VerificationData) => {
    const response = await api.put(`/Vendors/${vendorId}/verification`, data, {
      baseURL: import.meta.env.VITE_API_URL || '/api',
    });
    return response.data;
  }
};
