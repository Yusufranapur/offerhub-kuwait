import React from 'react';
import Card from '../../components/common/Card';
import Button from '../../components/common/Button';
import Badge from '../../components/common/Badge';

const BannersPage: React.FC = () => {
  return (
    <div className="page-container">
      <div className="page-header">
        <h1 className="page-title">Banners & Promotions</h1>
        <Button>Upload Banner</Button>
      </div>

      <div style={{ display: 'grid', gridTemplateColumns: 'repeat(auto-fit, minmax(300px, 1fr))', gap: '1.5rem' }}>
        {[1, 2, 3].map((i) => (
          <Card key={i} noPadding>
            <div style={{ height: '160px', background: 'var(--color-bg-surface-hover)', borderTopLeftRadius: 'var(--radius-lg)', borderTopRightRadius: 'var(--radius-lg)', display: 'flex', alignItems: 'center', justifyContent: 'center' }}>
              <span className="text-muted">Banner Image {i}</span>
            </div>
            <div style={{ padding: '1.25rem' }}>
              <div className="flex justify-between items-start mb-2">
                <h3 className="font-medium">Summer Mega Sale {i}</h3>
                <Badge variant="success">Active</Badge>
              </div>
              <p className="text-sm text-secondary mb-4">Placement: Home Screen Top</p>
              <div className="flex gap-2">
                <Button variant="outline" size="sm" fullWidth>Edit</Button>
                <Button variant="outline" size="sm" style={{ color: 'var(--color-danger)', borderColor: 'var(--color-danger)' }}>Delete</Button>
              </div>
            </div>
          </Card>
        ))}
      </div>
    </div>
  );
};

export default BannersPage;
