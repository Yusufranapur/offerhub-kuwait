import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router';
import { adminService, Vendor } from '../../services/adminService';
import './VerificationReviewPage.css';

export default function VerificationReviewPage() {
  const { id } = useParams();
  const navigate = useNavigate();
  const [vendor, setVendor] = useState<Vendor | null>(null);
  const [loading, setLoading] = useState(true);
  const [rejectReason, setRejectReason] = useState('');
  const [showRejectModal, setShowRejectModal] = useState(false);
  const [isSubmitting, setIsSubmitting] = useState(false);

  useEffect(() => {
    if (id) {
      adminService.getVendorById(id).then(data => {
        setVendor(data);
        setLoading(false);
      });
    }
  }, [id]);

  const handleApprove = async () => {
    if (!id || !window.confirm("Are you sure you want to approve this vendor?")) return;
    setIsSubmitting(true);
    try {
      await adminService.approveVendor(id);
      alert("Vendor approved successfully.");
      navigate('/vendors/pending');
    } catch (error) {
      alert("Failed to approve vendor.");
    } finally {
      setIsSubmitting(false);
    }
  };

  const handleReject = async () => {
    if (!id || !rejectReason.trim()) return;
    setIsSubmitting(true);
    try {
      await adminService.rejectVendor(id, rejectReason);
      alert("Vendor rejected.");
      navigate('/vendors/pending');
    } catch (error) {
      alert("Failed to reject vendor.");
    } finally {
      setIsSubmitting(false);
      setShowRejectModal(false);
    }
  };

  if (loading) return <div className="p-8">Loading verification data...</div>;
  if (!vendor) return <div className="p-8">Vendor not found.</div>;

  const DocumentLink = ({ label, url }: { label: string, url?: string }) => {
    if (!url) return null;
    return (
      <div className="doc-link-item">
        <span className="doc-label">{label}</span>
        <a href={url} target="_blank" rel="noopener noreferrer" className="btn btn-outline btn-sm">
          View Document
        </a>
      </div>
    );
  };

  return (
    <div className="flex flex-col gap-6 max-w-5xl mx-auto w-full pb-10">
      <div className="flex justify-between items-center">
        <div>
          <button className="btn btn-ghost mb-2" onClick={() => navigate(-1)}>← Back</button>
          <h1 className="text-2xl font-bold">Review Verification: {vendor.name}</h1>
        </div>
        <div className="flex gap-4">
          <button 
            className="btn btn-outline text-red-500 border-red-500 hover:bg-red-500 hover:text-white"
            onClick={() => setShowRejectModal(true)}
            disabled={isSubmitting}
          >
            Reject
          </button>
          <button 
            className="btn btn-primary"
            onClick={handleApprove}
            disabled={isSubmitting}
          >
            {isSubmitting ? 'Processing...' : 'Approve Vendor'}
          </button>
        </div>
      </div>

      <div className="grid grid-cols-1 lg:grid-cols-2 gap-6">
        
        {/* Merchant Info */}
        <div className="card">
          <h3 className="section-title">Merchant Details</h3>
          <div className="data-grid">
            <div className="data-item">
              <label>Business Name (EN)</label>
              <p>{vendor.name}</p>
            </div>
            <div className="data-item">
              <label>Business Name (AR)</label>
              <p>{vendor.nameAr}</p>
            </div>
            <div className="data-item">
              <label>Business Type</label>
              <p>{vendor.businessType || 'N/A'}</p>
            </div>
            <div className="data-item">
              <label>Civil ID Number</label>
              <p>{vendor.civilIdNumber || 'N/A'}</p>
            </div>
            <div className="data-item">
              <label>Commercial Registration No.</label>
              <p>{vendor.commercialRegistrationNo || 'N/A'}</p>
            </div>
          </div>
        </div>

        {/* Banking Info */}
        <div className="card">
          <h3 className="section-title">Banking Details</h3>
          <div className="data-grid">
            <div className="data-item">
              <label>Beneficiary Name (EN)</label>
              <p>{vendor.beneficiaryNameEn || 'N/A'}</p>
            </div>
            <div className="data-item">
              <label>Bank Name</label>
              <p>{vendor.bankName || 'N/A'}</p>
            </div>
            <div className="data-item col-span-2">
              <label>IBAN Number</label>
              <p className="font-mono bg-black/20 p-2 rounded">{vendor.ibanNumber || 'N/A'}</p>
            </div>
          </div>
        </div>

        {/* Documents */}
        <div className="card lg:col-span-2">
          <h3 className="section-title">Uploaded Documents</h3>
          <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
            <DocumentLink label="Commercial License" url={vendor.commercialLicenseUrl} />
            <DocumentLink label="Memorandum of Association" url={vendor.memorandumOfAssociationUrl} />
            <DocumentLink label="Civil ID (Front)" url={vendor.authPersonCivilIdFrontUrl} />
            <DocumentLink label="Civil ID (Back)" url={vendor.authPersonCivilIdBackUrl} />
            <DocumentLink label="Signed Terms & Conditions" url={vendor.signedTermsAndConditionsUrl} />
            <DocumentLink label="Bank Account Document" url={vendor.bankAccountNumberPdfUrl} />
          </div>
        </div>
      </div>

      {showRejectModal && (
        <div className="modal-backdrop">
          <div className="modal-content card">
            <h3 className="text-xl font-bold mb-4">Reject Verification</h3>
            <p className="text-gray-400 mb-4">Please provide a reason for rejection. This will be sent to the vendor.</p>
            <textarea 
              className="w-full p-3 bg-gray-800 border border-gray-700 rounded text-white mb-4"
              rows={4}
              value={rejectReason}
              onChange={e => setRejectReason(e.target.value)}
              placeholder="e.g., Commercial license is expired..."
            />
            <div className="flex justify-end gap-3">
              <button className="btn btn-ghost" onClick={() => setShowRejectModal(false)}>Cancel</button>
              <button className="btn btn-primary bg-red-600 border-red-600" onClick={handleReject} disabled={!rejectReason.trim()}>
                Confirm Rejection
              </button>
            </div>
          </div>
        </div>
      )}
    </div>
  );
}
