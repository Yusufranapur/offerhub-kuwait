import { useTranslation } from 'react-i18next';
import { Tags, ScanLine, DollarSign, MapPin } from 'lucide-react';
import StatsCard from '../../components/common/StatsCard';

export default function DashboardPage() {
  const { t } = useTranslation();

  return (
    <div className="flex flex-col gap-6">
      <div>
        <h1 className="text-2xl font-bold mb-1">{t('common.dashboard')}</h1>
        <p className="text-muted">{t('dashboard.performance')}</p>
      </div>

      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-6">
        <StatsCard 
          title={t('dashboard.total_offers')} 
          value="12" 
          icon={<Tags />} 
          trend={{ value: 15, isPositive: true }}
        />
        <StatsCard 
          title={t('dashboard.total_redemptions')} 
          value="1,284" 
          icon={<ScanLine />} 
          trend={{ value: 8, isPositive: true }}
        />
        <StatsCard 
          title={t('dashboard.revenue_impact')} 
          value="8,450 KWD" 
          icon={<DollarSign />} 
          trend={{ value: 12, isPositive: true }}
        />
        <StatsCard 
          title={t('dashboard.active_branches')} 
          value="4" 
          icon={<MapPin />} 
        />
      </div>

      <div className="grid grid-cols-1 lg:grid-cols-2 gap-6">
        <div className="card">
          <h3>Redemption Trends</h3>
          <div className="h-64 flex items-center justify-center text-muted border-dashed border-2 border-slate-700 mt-4 rounded-lg">
            [Chart Placeholder]
          </div>
        </div>
        <div className="card">
          <h3>Top Performing Offers</h3>
          <div className="h-64 flex items-center justify-center text-muted border-dashed border-2 border-slate-700 mt-4 rounded-lg">
            [List Placeholder]
          </div>
        </div>
      </div>
    </div>
  );
}
