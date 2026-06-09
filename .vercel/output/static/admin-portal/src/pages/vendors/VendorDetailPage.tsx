import React from 'react';
import { useParams, useNavigate } from 'react-router';
import Card from '../../components/common/Card';
import Button from '../../components/common/Button';
import Badge from '../../components/common/Badge';
import { ArrowLeft, CheckCircle, XCircle } from 'lucide-react';

const VendorDetailPage: React.FC = () => {
  const { id } = useParams();
  const navigate = useNavigate();

  return (
    <div className="page-container">
      <div className="flex items-center gap-4 mb-2">
        <Button variant="ghost" onClick={() => navigate(-1)} style={{ padding: '0.5rem' }}>
          <ArrowLeft size={20} />
        </Button>
        <h1 className="page-title">Vendor Details</h1>
      </div>

      <div style={{ display: 'grid', gridTemplateColumns: '1fr 2fr', gap: '1.5rem' }}>
        <Card title="Vendor Profile">
          <div className="flex-col gap-4">
            <div className="flex items-center gap-4">
              <div style={{ width: 80, height: 80, borderRadius: 'var(--radius-lg)', background: 'var(--color-bg-surface-hover)' }}></div>
              <div>
                <h3 className="text-lg font-bold">X-Cite</h3>
                <p className="text-sm text-secondary">ID: {id}</p>
                <Badge variant="success">Active</Badge>
              </div>
            </div>
            <div style={{ marginTop: '1.5rem' }}>
              <p className="text-sm text-muted">Email</p>
              <p className="font-medium">info@xcite.com</p>
            </div>
            <div style={{ marginTop: '1rem' }}>
              <p className="text-sm text-muted">Phone</p>
              <p className="font-medium">+965 1803535</p>
            </div>
            <div style={{ marginTop: '1rem' }}>
              <p className="text-sm text-muted">Category</p>
              <p className="font-medium">Electronics</p>
            </div>
          </div>
        </Card>

        <Card title="Management Actions">
          <div className="flex-col gap-4">
            <p className="text-sm text-secondary">Review vendor application and manage their account status.</p>
            
            <div className="flex gap-4" style={{ marginTop: '1rem' }}>
              <Button variant="primary" className="flex items-center gap-2">
                <CheckCircle size={18} /> Approve Vendor
              </Button>
              <Button variant="danger" className="flex items-center gap-2">
                <XCircle size={18} /> Suspend Vendor
              </Button>
            </div>

            <hr style={{ margin: '2rem 0', borderColor: 'var(--color-border)' }} />

            <h4 className="font-medium mb-2">Subscription Plan</h4>
            <div style={{ padding: '1rem', border: '1px solid var(--color-border)', borderRadius: 'var(--radius-md)' }}>
              <div className="flex justify-between items-center">
                <div>
                  <p className="font-bold">Premium Plan</p>
                  <p className="text-sm text-secondary">Renews on Oct 12, 2024</p>
                </div>
                <Button variant="outline" size="sm">Change Plan</Button>
              </div>
            </div>
          </div>
        </Card>
      </div>
    </div>
  );
};

export default VendorDetailPage;
