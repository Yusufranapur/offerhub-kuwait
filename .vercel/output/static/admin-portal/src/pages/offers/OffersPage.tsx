import React from 'react';
import { useTranslation } from 'react-i18next';
import Card from '../../components/common/Card';
import Table from '../../components/common/Table';
import Badge from '../../components/common/Badge';
import Button from '../../components/common/Button';
import { Check, X, Eye } from 'lucide-react';

const mockOffers = [
  { id: '1', title: '50% Off Laptops', vendor: 'X-Cite', type: 'Discount', status: 'pending', submitted: '2 hours ago' },
  { id: '2', title: 'Buy 1 Get 1 Free', vendor: 'Starbucks', type: 'BOGO', status: 'pending', submitted: '5 hours ago' },
  { id: '3', title: 'Summer Sale 2024', vendor: 'H&M', type: 'Campaign', status: 'approved', submitted: '1 day ago' },
];

const OffersPage: React.FC = () => {
  const { t } = useTranslation();

  const columns = [
    { key: 'title', header: 'Offer Title', render: (r: any) => <div className="font-medium">{r.title}</div> },
    { key: 'vendor', header: 'Vendor' },
    { key: 'type', header: 'Type' },
    { key: 'status', header: 'Status', render: (r: any) => (
      <Badge variant={r.status === 'approved' ? 'success' : r.status === 'pending' ? 'warning' : 'danger'}>
        {r.status}
      </Badge>
    )},
    { key: 'submitted', header: 'Submitted' },
    { key: 'actions', header: 'Actions', render: (r: any) => (
      <div className="flex gap-2">
        <Button variant="ghost" size="sm">
          <Eye size={16} />
        </Button>
        {r.status === 'pending' && (
          <>
            <Button variant="ghost" size="sm" style={{ color: 'var(--color-success)' }}>
              <Check size={16} />
            </Button>
            <Button variant="ghost" size="sm" style={{ color: 'var(--color-danger)' }}>
              <X size={16} />
            </Button>
          </>
        )}
      </div>
    )},
  ];

  return (
    <div className="page-container">
      <div className="page-header">
        <h1 className="page-title">Offer Moderation</h1>
      </div>

      <Card>
        <div style={{ marginBottom: '1.5rem' }}>
          <p className="text-secondary text-sm">Review and approve offers submitted by vendors before they go live on the platform.</p>
        </div>
        <Table columns={columns} data={mockOffers} />
      </Card>
    </div>
  );
};

export default OffersPage;
