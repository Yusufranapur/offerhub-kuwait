import { useTranslation } from 'react-i18next';
import { Plus, Edit, Trash2 } from 'lucide-react';
import { Link } from 'react-router';
import DataTable from '../../components/common/DataTable';
import { useApi } from '../../hooks/useApi';
import { offerService } from '../../services/offerService';

export default function OffersPage() {
  const { t } = useTranslation();
  const { data: offers, loading } = useApi(offerService.getOffers);

  const columns = [
    { key: 'title', header: t('offers.name') },
    { 
      key: 'discountValue', 
      header: t('offers.discount'),
      render: (item: any) => `${item.discountValue} (${item.offerType})` 
    },
    { 
      key: 'endDate', 
      header: t('offers.valid_until'),
      render: (item: any) => new Date(item.endDate).toLocaleDateString()
    },
    { 
      key: 'status', 
      header: t('common.status'),
      render: (item: any) => (
        <span className="text-emerald-400">{item.status}</span>
      )
    },
    {
      key: 'actions',
      header: t('common.actions'),
      render: (item: any) => (
        <div className="flex gap-3">
          <Link to={`/offers/${item.id}`} className="text-teal-400 hover:text-teal-300 transition-colors" title={t('common.edit')}>
            <Edit size={18} />
          </Link>
          <button className="text-red-400 hover:text-red-300 transition-colors" title={t('common.delete')} onClick={() => alert('Delete clicked!')}>
            <Trash2 size={18} />
          </button>
        </div>
      )
    }
  ];

  return (
    <div className="flex flex-col gap-6">
      <div className="flex justify-between items-center">
        <h1 className="text-2xl font-bold">{t('offers.title')}</h1>
        <Link to="/offers/create" className="btn btn-primary">
          <Plus size={20} />
          {t('offers.create')}
        </Link>
      </div>

      <DataTable 
        columns={columns} 
        data={offers?.items || []} 
        loading={loading}
      />
    </div>
  );
}
