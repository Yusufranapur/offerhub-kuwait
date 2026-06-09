import React, { useState } from 'react';
import { useTranslation } from 'react-i18next';
import FileUpload from '../../components/common/FileUpload';
import { vendorService, VerificationData } from '../../services/vendorService';
import { useAuthStore } from '../../store/authStore';
import { useNavigate } from 'react-router';
import './VerificationPage.css';

export default function VerificationPage() {
  const { t } = useTranslation();
  const navigate = useNavigate();
  const { user } = useAuthStore();
  const [step, setStep] = useState(1);
  const [isSubmitting, setIsSubmitting] = useState(false);
  const totalSteps = 3;

  // Form State
  const [formData, setFormData] = useState({
    businessCategory: '',
    businessType: '',
    civilIdNumber: '',
    commercialRegNo: '',
    bankName: '',
    iban: '',
    beneficiaryNameEn: '',
    beneficiaryNameAr: ''
  });

  // Files State
  const [files, setFiles] = useState<{ [key: string]: File | null }>({
    commercialLicense: null,
    memorandumOfAssociation: null,
    authPersonCivilIdFront: null,
    authPersonCivilIdBack: null,
    signedTermsAndConditions: null,
    extractCommercialRegistry: null,
    authSignatoryCertificate: null,
    bankAccountNumberPdf: null
  });

  const handleNext = () => setStep(prev => Math.min(prev + 1, totalSteps));
  const handlePrev = () => setStep(prev => Math.max(prev - 1, 1));
  
  const handleFileChange = (key: string, file: File) => {
    setFiles(prev => ({ ...prev, [key]: file }));
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!user?.id) return alert("User not logged in");

    setIsSubmitting(true);
    try {
      // 1. Upload all selected files concurrently
      const uploadPromises = Object.entries(files).map(async ([key, file]) => {
        if (!file) return { key, url: undefined };
        const url = await vendorService.uploadFile(file);
        return { key, url };
      });

      const uploadedFiles = await Promise.all(uploadPromises);
      
      // Map file keys to the required VerificationData URL fields
      const urls: Partial<VerificationData> = {};
      uploadedFiles.forEach(({ key, url }) => {
        if (url) {
          urls[`${key}Url` as keyof VerificationData] = url;
        }
      });

      // 2. Submit Verification Data
      const verificationData: VerificationData = {
        vendorId: user.id,
        businessCategoryId: null, // Hardcoded for now until categories are fetched
        businessType: formData.businessType,
        civilIdNumber: formData.civilIdNumber,
        commercialRegistrationNo: formData.commercialRegNo,
        beneficiaryNameEn: formData.beneficiaryNameEn,
        beneficiaryNameAr: formData.beneficiaryNameAr,
        bankName: formData.bankName,
        ibanNumber: formData.iban,
        ...urls
      };

      await vendorService.updateVerification(user.id, verificationData);
      
      alert("Verification submitted successfully! Pending Admin Approval.");
      navigate('/dashboard');

    } catch (error) {
      console.error("Verification failed:", error);
      alert("Failed to submit verification. Please try again.");
    } finally {
      setIsSubmitting(false);
    }
  };

  return (
    <div className="verification-container">
      <div className="verification-card glass-panel">
        <div className="verification-header">
          <h1>{t('Complete Verification')}</h1>
          <p>{t('Please provide your business details to activate your account.')}</p>
        </div>

        <div className="steps-indicator">
          {[1, 2, 3].map(s => (
            <div key={s} className={`step ${step >= s ? 'active' : ''}`}>
              <div className="step-circle">{s}</div>
              <span>{s === 1 ? 'Merchant' : s === 2 ? 'Documents' : 'Banking'}</span>
            </div>
          ))}
        </div>

        <form onSubmit={step === totalSteps ? handleSubmit : (e) => { e.preventDefault(); handleNext(); }}>
          
          {step === 1 && (
            <div className="step-content animate-fade-in">
              <h3>Merchant Details</h3>
              <div className="form-grid">
                <div className="form-group">
                  <label>Business Category</label>
                  <select 
                    required 
                    value={formData.businessCategory} 
                    onChange={e => setFormData({...formData, businessCategory: e.target.value})}
                  >
                    <option value="">Select Category</option>
                    <option value="Food & Beverage">Food & Beverage</option>
                    <option value="Retail">Retail</option>
                    <option value="Services">Services</option>
                  </select>
                </div>
                <div className="form-group">
                  <label>Business Type</label>
                  <select 
                    required 
                    value={formData.businessType} 
                    onChange={e => setFormData({...formData, businessType: e.target.value})}
                  >
                    <option value="">Select Type</option>
                    <option value="LLC">LLC</option>
                    <option value="Sole Proprietorship">Sole Proprietorship</option>
                  </select>
                </div>
                <div className="form-group md:col-span-2">
                  <label>Authorized Person Civil ID Number</label>
                  <input 
                    type="text" 
                    required 
                    value={formData.civilIdNumber} 
                    onChange={e => setFormData({...formData, civilIdNumber: e.target.value})}
                  />
                </div>
              </div>
            </div>
          )}

          {step === 2 && (
            <div className="step-content animate-fade-in">
              <h3>Legal Documents</h3>
              <div className="form-group mb-4">
                <label>Commercial License Number</label>
                <input 
                  type="text" 
                  required 
                  value={formData.commercialRegNo} 
                  onChange={e => setFormData({...formData, commercialRegNo: e.target.value})}
                />
              </div>
              <div className="upload-grid">
                <FileUpload label="Commercial License (PDF)" onFileSelect={f => handleFileChange('commercialLicense', f)} />
                <FileUpload label="Memorandum of Association (PDF)" onFileSelect={f => handleFileChange('memorandumOfAssociation', f)} />
                <FileUpload label="Authorized Person Civil ID (Front)" onFileSelect={f => handleFileChange('authPersonCivilIdFront', f)} />
                <FileUpload label="Authorized Person Civil ID (Back)" onFileSelect={f => handleFileChange('authPersonCivilIdBack', f)} />
                <FileUpload label="Signed Terms & Conditions (PDF)" onFileSelect={f => handleFileChange('signedTermsAndConditions', f)} />
                <FileUpload label="Extract Commercial Registry (PDF)" onFileSelect={f => handleFileChange('extractCommercialRegistry', f)} />
                <FileUpload label="Authorized Signatory Certificate (PDF)" onFileSelect={f => handleFileChange('authSignatoryCertificate', f)} />
              </div>
            </div>
          )}

          {step === 3 && (
            <div className="step-content animate-fade-in">
              <h3>Bank Details</h3>
              <div className="form-grid">
                <div className="form-group">
                  <label>Beneficiary Name (EN)</label>
                  <input 
                    type="text" 
                    required 
                    value={formData.beneficiaryNameEn} 
                    onChange={e => setFormData({...formData, beneficiaryNameEn: e.target.value})}
                  />
                </div>
                <div className="form-group">
                  <label>Beneficiary Name (AR)</label>
                  <input 
                    type="text" 
                    required 
                    value={formData.beneficiaryNameAr} 
                    onChange={e => setFormData({...formData, beneficiaryNameAr: e.target.value})}
                  />
                </div>
                <div className="form-group">
                  <label>Bank Name</label>
                  <input 
                    type="text" 
                    required 
                    value={formData.bankName} 
                    onChange={e => setFormData({...formData, bankName: e.target.value})}
                  />
                </div>
                <div className="form-group">
                  <label>IBAN Number</label>
                  <input 
                    type="text" 
                    required 
                    value={formData.iban} 
                    onChange={e => setFormData({...formData, iban: e.target.value})}
                  />
                </div>
              </div>
              <div className="mt-6">
                <FileUpload label="Bank Account Number Document (PDF)" onFileSelect={f => handleFileChange('bankAccountNumberPdf', f)} />
              </div>
            </div>
          )}

          <div className="verification-actions">
            {step > 1 && (
              <button type="button" className="btn btn-outline" onClick={handlePrev} disabled={isSubmitting}>
                Back
              </button>
            )}
            <button type="submit" className="btn btn-primary" disabled={isSubmitting}>
              {isSubmitting ? 'Submitting...' : step === totalSteps ? 'Submit Verification' : 'Continue'}
            </button>
          </div>
        </form>
      </div>
    </div>
  );
}
