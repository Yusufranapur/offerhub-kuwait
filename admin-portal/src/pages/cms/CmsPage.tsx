import React from 'react';
import Card from '../../components/common/Card';
import Button from '../../components/common/Button';

const CmsPage: React.FC = () => {
  return (
    <div className="page-container">
      <div className="page-header">
        <h1 className="page-title">Content Management</h1>
      </div>

      <div style={{ display: 'grid', gridTemplateColumns: 'repeat(auto-fill, minmax(300px, 1fr))', gap: '1.5rem' }}>
        <Card title="Terms & Conditions">
          <p className="text-sm text-secondary mb-4">Manage the legal terms presented to users and vendors.</p>
          <Button variant="outline" fullWidth>Edit Terms</Button>
        </Card>
        
        <Card title="Privacy Policy">
          <p className="text-sm text-secondary mb-4">Update the privacy policy regarding user data handling.</p>
          <Button variant="outline" fullWidth>Edit Policy</Button>
        </Card>
        
        <Card title="FAQ">
          <p className="text-sm text-secondary mb-4">Manage frequently asked questions for help center.</p>
          <Button variant="outline" fullWidth>Manage FAQs</Button>
        </Card>

        <Card title="Onboarding Screens">
          <p className="text-sm text-secondary mb-4">Update the introductory screens shown to new app users.</p>
          <Button variant="outline" fullWidth>Edit Screens</Button>
        </Card>
      </div>
    </div>
  );
};

export default CmsPage;
