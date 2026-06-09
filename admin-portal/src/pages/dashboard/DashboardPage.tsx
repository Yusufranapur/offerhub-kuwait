import React from 'react';
import { useTranslation } from 'react-i18next';
import Card from '../../components/common/Card';
import { Users, Store, Tags, TrendingUp } from 'lucide-react';
import { AreaChart, Area, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer } from 'recharts';

const data = [
  { name: 'Mon', vendors: 400, offers: 240, amt: 2400 },
  { name: 'Tue', vendors: 300, offers: 139, amt: 2210 },
  { name: 'Wed', vendors: 200, offers: 980, amt: 2290 },
  { name: 'Thu', vendors: 278, offers: 390, amt: 2000 },
  { name: 'Fri', vendors: 189, offers: 480, amt: 2181 },
  { name: 'Sat', vendors: 239, offers: 380, amt: 2500 },
  { name: 'Sun', vendors: 349, offers: 430, amt: 2100 },
];

const StatCard: React.FC<{ title: string, value: string, icon: React.ReactNode, trend?: string }> = ({ title, value, icon, trend }) => (
  <Card>
    <div className="flex justify-between items-center">
      <div>
        <p className="text-secondary text-sm font-medium">{title}</p>
        <h3 className="text-xl font-bold" style={{ marginTop: '0.25rem' }}>{value}</h3>
        {trend && (
          <p className="text-xs" style={{ color: 'var(--color-success)', marginTop: '0.25rem' }}>
            ↑ {trend} from last month
          </p>
        )}
      </div>
      <div style={{ padding: '0.75rem', background: 'var(--color-bg-surface-hover)', borderRadius: 'var(--radius-lg)', color: 'var(--color-primary)' }}>
        {icon}
      </div>
    </div>
  </Card>
);

const DashboardPage: React.FC = () => {
  const { t } = useTranslation();

  return (
    <div className="page-container">
      <div className="page-header">
        <h1 className="page-title">{t('common.dashboard')}</h1>
      </div>

      <div style={{ display: 'grid', gridTemplateColumns: 'repeat(auto-fit, minmax(240px, 1fr))', gap: '1.5rem' }}>
        <StatCard title={t('dashboard.total_vendors')} value="1,248" icon={<Store size={24} />} trend="12%" />
        <StatCard title={t('dashboard.pending_offers')} value="45" icon={<Tags size={24} />} trend="5%" />
        <StatCard title={t('dashboard.active_users')} value="12,400" icon={<Users size={24} />} trend="8%" />
        <StatCard title={t('dashboard.revenue')} value="24,500 KWD" icon={<TrendingUp size={24} />} trend="15%" />
      </div>

      <div style={{ display: 'grid', gridTemplateColumns: '2fr 1fr', gap: '1.5rem' }}>
        <Card title="Activity Overview">
          <div style={{ height: '300px' }}>
            <ResponsiveContainer width="100%" height="100%">
              <AreaChart data={data}>
                <defs>
                  <linearGradient id="colorVendors" x1="0" y1="0" x2="0" y2="1">
                    <stop offset="5%" stopColor="#6366F1" stopOpacity={0.3}/>
                    <stop offset="95%" stopColor="#6366F1" stopOpacity={0}/>
                  </linearGradient>
                  <linearGradient id="colorOffers" x1="0" y1="0" x2="0" y2="1">
                    <stop offset="5%" stopColor="#2DD4BF" stopOpacity={0.3}/>
                    <stop offset="95%" stopColor="#2DD4BF" stopOpacity={0}/>
                  </linearGradient>
                </defs>
                <CartesianGrid strokeDasharray="3 3" stroke="var(--color-border)" vertical={false} />
                <XAxis dataKey="name" stroke="var(--color-text-muted)" />
                <YAxis stroke="var(--color-text-muted)" />
                <Tooltip contentStyle={{ background: 'var(--color-bg-surface)', border: '1px solid var(--color-border)' }} />
                <Area type="monotone" dataKey="vendors" stroke="#6366F1" fillOpacity={1} fill="url(#colorVendors)" />
                <Area type="monotone" dataKey="offers" stroke="#2DD4BF" fillOpacity={1} fill="url(#colorOffers)" />
              </AreaChart>
            </ResponsiveContainer>
          </div>
        </Card>
        
        <Card title="Recent Registrations">
          <div className="flex-col gap-4">
            {[1,2,3,4].map(i => (
              <div key={i} className="flex justify-between items-center" style={{ paddingBottom: '1rem', borderBottom: i !== 4 ? '1px solid var(--color-border)' : 'none' }}>
                <div className="flex items-center gap-3">
                  <div style={{ width: 40, height: 40, borderRadius: '50%', background: 'var(--color-bg-surface-hover)', display: 'flex', alignItems: 'center', justifyContent: 'center' }}>
                    <Store size={20} className="text-primary" />
                  </div>
                  <div>
                    <p className="font-medium text-sm">Vendor #{1000 + i}</p>
                    <p className="text-xs text-muted">2 hours ago</p>
                  </div>
                </div>
                <span className="text-xs" style={{ color: 'var(--color-success)' }}>Approved</span>
              </div>
            ))}
          </div>
        </Card>
      </div>
    </div>
  );
};

export default DashboardPage;
