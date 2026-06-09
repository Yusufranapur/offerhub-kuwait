import React from 'react';
import { useTranslation } from 'react-i18next';
import { useNavigate } from 'react-router';
import Card from '../../components/common/Card';
import Table from '../../components/common/Table';
import Badge from '../../components/common/Badge';
import Button from '../../components/common/Button';
import Input from '../../components/common/Input';
import { Search, Eye, Edit, Trash2 } from 'lucide-react';

const mockVendors = [
  { id: '1', name: 'Alshaya Group', email: 'contact@alshaya.com', category: 'Retail', status: 'active', joined: '2024-01-10' },
  { id: '2', name: 'X-Cite', email: 'info@xcite.com', category: 'Electronics', status: 'active', joined: '2024-02-15' },
  { id: '3', name: 'Boutiqaat', email: 'vendor@boutiqaat.com', category: 'Beauty', status: 'pending', joined: '2024-03-01' },
];

const VendorsPage: React.FC = () => {
  const { t } = useTranslation();
  const navigate = useNavigate();

  const columns = [
    { key: 'name', header: 'Vendor Name', render: (r: any) => <div className="font-medium">{r.name}</div> },
    { key: 'email', header: 'Email' },
    { key: 'category', header: 'Category' },
    { key: 'status', header: 'Status', render: (r: any) => (
      <Badge variant={r.status === 'active' ? 'success' : 'warning'}>{r.status}</Badge>
    )},
    { key: 'joined', header: 'Joined Date' },
    { key: 'actions', header: 'Actions', render: (r: any) => (
      <div className="flex gap-2">
        <Button variant="ghost" size="sm" onClick={() => navigate(`/vendors/${r.id}`)}>
          <Eye size={16} />
        </Button>
        <Button variant="ghost" size="sm">
          <Edit size={16} />
        </Button>
        <Button variant="ghost" size="sm" style={{ color: 'var(--color-danger)' }}>
          <Trash2 size={16} />
        </Button>
      </div>
    )},
  ];

  return (
    <div className="page-container">
      <div className="page-header">
        <h1 className="page-title">{t('common.vendors')}</h1>
        <Button>Add Vendor</Button>
      </div>

      <Card>
        <div className="flex justify-between items-center mb-4" style={{ marginBottom: '1.5rem' }}>
          <div style={{ width: '300px' }}>
            <div style={{ position: 'relative' }}>
              <Input placeholder={t('common.search')} style={{ paddingLeft: '2.5rem' }} />
              <Search size={18} style={{ position: 'absolute', left: '0.75rem', top: '50%', transform: 'translateY(-50%)', color: 'var(--color-text-muted)' }} />
            </div>
          </div>
          <div className="flex gap-2">
            <select style={{ padding: '0.5rem', borderRadius: 'var(--radius-md)', background: 'var(--color-bg-base)', color: 'var(--color-text-primary)', border: '1px solid var(--color-border)' }}>
              <option value="">All Statuses</option>
              <option value="active">Active</option>
              <option value="pending">Pending</option>
            </select>
          </div>
        </div>

        <Table columns={columns} data={mockVendors} />
      </Card>
    </div>
  );
};

export default VendorsPage;
