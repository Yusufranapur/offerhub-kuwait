import { useTranslation } from 'react-i18next';
import { MapPin, Plus } from 'lucide-react';
import DataTable from '../../components/common/DataTable';
import { useApi } from '../../hooks/useApi';
import { branchService } from '../../services/branchService';

export default function BranchesPage() {
  const { t } = useTranslation();
  const { data: branches, loading } = useApi(branchService.getBranches);

  const columns = [
    { key: 'name', header: 'Branch Name' },
    { key: 'address', header: 'Address' },
    { 
      key: 'status', 
      header: 'Status',
      render: (item: any) => (
        <span className={`badge ${item.status === 'Active' ? 'badge-success' : 'badge-warning'}`}>
          {item.status}
        </span>
      )
    },
    {
      key: 'actions',
      header: 'Actions',
      render: () => (
        <button className="text-teal-400 hover:text-teal-300">Edit</button>
      )
    }
  ];

  return (
    <div className="flex flex-col gap-6">
      <div className="flex justify-between items-center">
        <div>
          <h1 className="text-2xl font-bold mb-1">{t('common.branches')}</h1>
          <p className="text-muted">Manage your physical locations</p>
        </div>
        <button className="btn btn-primary">
          <Plus size={20} />
          {t('common.create')}
        </button>
      </div>

      <DataTable 
        columns={columns} 
        data={branches || []} 
        loading={loading}
      />
    </div>
  );
}
