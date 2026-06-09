import React from 'react';
import Card from '../../components/common/Card';
import Table from '../../components/common/Table';
import Badge from '../../components/common/Badge';

const mockLogs = [
  { id: 1, admin: 'Admin User', action: 'Approved Vendor', target: 'X-Cite (ID: 2)', date: '2024-06-08 09:30:00' },
  { id: 2, admin: 'Admin User', action: 'Deleted Offer', target: 'Offer ID: 154', date: '2024-06-08 08:15:22' },
  { id: 3, admin: 'System', action: 'Automated Backup', target: 'Database', date: '2024-06-08 00:00:00' },
];

const AuditLogsPage: React.FC = () => {
  const columns = [
    { key: 'admin', header: 'Admin / System' },
    { key: 'action', header: 'Action Taken', render: (r: any) => <span className="font-medium">{r.action}</span> },
    { key: 'target', header: 'Target Entity' },
    { key: 'date', header: 'Timestamp' },
  ];

  return (
    <div className="page-container">
      <div className="page-header">
        <h1 className="page-title">Audit Logs</h1>
      </div>

      <Card>
        <p className="text-sm text-secondary mb-4">View a complete trail of administrative actions performed in the system.</p>
        <Table columns={columns} data={mockLogs} />
      </Card>
    </div>
  );
};

export default AuditLogsPage;
