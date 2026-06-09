import React from 'react';
import Card from '../../components/common/Card';
import Button from '../../components/common/Button';
import Badge from '../../components/common/Badge';

const SubscriptionPlansPage: React.FC = () => {
  return (
    <div className="page-container">
      <div className="page-header">
        <h1 className="page-title">Vendor Subscription Plans</h1>
        <Button>Create New Plan</Button>
      </div>

      <div style={{ display: 'grid', gridTemplateColumns: 'repeat(auto-fit, minmax(300px, 1fr))', gap: '1.5rem' }}>
        <Card title="Basic Plan">
          <div className="flex justify-between items-center mb-4">
            <h2 className="text-2xl font-bold">Free</h2>
            <Badge variant="info">Default</Badge>
          </div>
          <ul className="flex-col gap-2 mb-6 text-sm">
            <li>✓ Up to 5 active offers</li>
            <li>✓ Standard listing</li>
            <li>✗ Analytics access</li>
            <li>✗ Priority support</li>
          </ul>
          <Button variant="outline" fullWidth>Edit Plan</Button>
        </Card>

        <Card title="Premium Plan" style={{ border: '2px solid var(--color-primary)' }}>
          <div className="flex justify-between items-center mb-4">
            <h2 className="text-2xl font-bold">49 KWD<span className="text-sm text-secondary font-normal">/mo</span></h2>
            <Badge variant="success">Popular</Badge>
          </div>
          <ul className="flex-col gap-2 mb-6 text-sm">
            <li>✓ Unlimited active offers</li>
            <li>✓ Featured listing</li>
            <li>✓ Full analytics access</li>
            <li>✓ Priority support</li>
          </ul>
          <Button variant="primary" fullWidth>Edit Plan</Button>
        </Card>
      </div>
    </div>
  );
};

export default SubscriptionPlansPage;
