import React from 'react';
import Card from '../../components/common/Card';
import Table from '../../components/common/Table';
import Button from '../../components/common/Button';
import Badge from '../../components/common/Badge';
import { ShieldAlert, ShieldCheck } from 'lucide-react';

const mockAdmins = [
  { id: 1, name: 'Main Admin', email: 'admin@offerhub.com', role: 'Super Admin', status: 'active' },
  { id: 2, name: 'Content Mod 1', email: 'mod1@offerhub.com', role: 'Moderator', status: 'active' },
  { id: 3, name: 'Sales Rep', email: 'sales@offerhub.com', role: 'Sales', status: 'inactive' },
];

const UsersPage: React.FC = () => {
  const columns = [
    { key: 'name', header: 'Name', render: (r: any) => <div className="font-medium">{r.name}</div> },
    { key: 'email', header: 'Email' },
    { key: 'role', header: 'Role', render: (r: any) => (
      <div className="flex items-center gap-2">
        {r.role === 'Super Admin' ? <ShieldAlert size={16} className="text-primary" /> : <ShieldCheck size={16} className="text-secondary" />}
        <span>{r.role}</span>
      </div>
    )},
    { key: 'status', header: 'Status', render: (r: any) => (
      <Badge variant={r.status === 'active' ? 'success' : 'danger'}>{r.status}</Badge>
    )},
    { key: 'actions', header: 'Actions', render: () => (
      <Button variant="ghost" size="sm">Manage</Button>
    )},
  ];

  return (
    <div className="page-container">
      <div className="page-header">
        <h1 className="page-title">System Users & Roles</h1>
        <Button>Add Admin User</Button>
      </div>

      <Card>
        <Table columns={columns} data={mockAdmins} />
      </Card>
    </div>
  );
};

export default UsersPage;
