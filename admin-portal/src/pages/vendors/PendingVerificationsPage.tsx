import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router';
import { useTranslation } from 'react-i18next';
import { adminService, Vendor } from '../../services/adminService';
import './PendingVerificationsPage.css';

export default function PendingVerificationsPage() {
  const { t } = useTranslation();
  const navigate = useNavigate();
  const [vendors, setVendors] = useState<Vendor[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchPending = async () => {
      try {
        const data = await adminService.getPendingVendors();
        setVendors(data);
      } catch (error) {
        console.error("Failed to load pending vendors", error);
      } finally {
        setLoading(false);
      }
    };
    fetchPending();
  }, []);

  if (loading) {
    return <div className="p-8">Loading pending verifications...</div>;
  }

  return (
    <div className="flex flex-col gap-6">
      <div className="flex justify-between items-center">
        <div>
          <h1 className="text-2xl font-bold">Pending Verifications</h1>
          <p className="text-sm text-gray-400">Review vendor KYC documents and approve them.</p>
        </div>
      </div>

      <div className="card">
        {vendors.length === 0 ? (
          <div className="text-center p-8 text-gray-500">
            No pending verifications at this time.
          </div>
        ) : (
          <div className="table-responsive">
            <table className="table w-full text-left">
              <thead>
                <tr>
                  <th>Vendor Name</th>
                  <th>Contact Email</th>
                  <th>Date Registered</th>
                  <th>Actions</th>
                </tr>
              </thead>
              <tbody>
                {vendors.map(vendor => (
                  <tr key={vendor.id} className="border-b border-gray-800">
                    <td className="py-4">
                      <div className="font-medium text-white">{vendor.name}</div>
                      <div className="text-xs text-gray-400">{vendor.nameAr}</div>
                    </td>
                    <td className="py-4 text-gray-300">{vendor.contactEmail}</td>
                    <td className="py-4 text-gray-300">{new Date(vendor.createdAt).toLocaleDateString()}</td>
                    <td className="py-4">
                      <button 
                        className="btn btn-primary btn-sm"
                        onClick={() => navigate(`/vendors/verify/${vendor.id}`)}
                      >
                        Review Documents
                      </button>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        )}
      </div>
    </div>
  );
}
