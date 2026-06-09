import React from 'react';
import { NavLink } from 'react-router';
import { useTranslation } from 'react-i18next';
import { 
  LayoutDashboard, 
  Store, 
  Tags, 
  FolderTree, 
  Image as ImageIcon, 
  Bell, 
  FileText, 
  CreditCard, 
  BarChart3, 
  History, 
  Users 
} from 'lucide-react';

const AdminSidebar: React.FC = () => {
  const { t } = useTranslation();

  const navItems = [
    { to: '/dashboard', icon: LayoutDashboard, label: t('common.dashboard') },
    { to: '/vendors', icon: Store, label: t('common.vendors') },
    { to: '/vendors/pending', icon: Store, label: 'Pending KYC' },
    { to: '/offers', icon: Tags, label: t('common.offers') },
    { to: '/categories', icon: FolderTree, label: t('common.categories') },
    { to: '/banners', icon: ImageIcon, label: t('common.banners') },
    { to: '/notifications', icon: Bell, label: t('common.notifications') },
    { to: '/cms', icon: FileText, label: t('common.cms') },
    { to: '/subscriptions', icon: CreditCard, label: t('common.subscriptions') },
    { to: '/analytics', icon: BarChart3, label: t('common.analytics') },
    { to: '/audit', icon: History, label: t('common.audit_logs') },
    { to: '/users', icon: Users, label: t('common.users') },
  ];

  return (
    <aside style={{
      width: '260px',
      background: 'var(--color-bg-surface)',
      borderRight: '1px solid var(--color-border)',
      display: 'flex',
      flexDirection: 'column',
      height: '100%',
      transition: 'all 0.3s'
    }}>
      <div style={{
        padding: '1.5rem',
        borderBottom: '1px solid var(--color-border)',
        display: 'flex',
        alignItems: 'center',
        gap: '0.75rem'
      }}>
        <div style={{
          width: '32px',
          height: '32px',
          background: 'var(--color-primary)',
          borderRadius: '8px',
          display: 'flex',
          alignItems: 'center',
          justifyContent: 'center',
          color: 'white',
          fontWeight: 'bold'
        }}>
          OH
        </div>
        <h1 style={{ fontSize: '1.25rem', fontWeight: 700, color: 'var(--color-primary)' }}>
          OfferHub <span style={{ color: 'var(--color-text-primary)' }}>Admin</span>
        </h1>
      </div>

      <nav style={{ flex: 1, overflowY: 'auto', padding: '1rem 0.5rem', display: 'flex', flexDirection: 'column', gap: '0.25rem' }}>
        {navItems.map((item) => (
          <NavLink
            key={item.to}
            to={item.to}
            style={({ isActive }) => ({
              display: 'flex',
              alignItems: 'center',
              gap: '0.75rem',
              padding: '0.75rem 1rem',
              borderRadius: 'var(--radius-md)',
              color: isActive ? 'white' : 'var(--color-text-secondary)',
              background: isActive ? 'var(--color-primary)' : 'transparent',
              fontWeight: isActive ? 500 : 400,
              textDecoration: 'none',
              transition: 'all 0.2s'
            })}
          >
            <item.icon size={20} />
            <span>{item.label}</span>
          </NavLink>
        ))}
      </nav>
    </aside>
  );
};

export default AdminSidebar;
