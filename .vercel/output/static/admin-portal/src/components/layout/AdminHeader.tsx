import React from 'react';
import { useTranslation } from 'react-i18next';
import { Moon, Sun, Globe, User, LogOut } from 'lucide-react';
import { useThemeStore } from '../../store/themeStore';
import { useAuthStore } from '../../store/authStore';
import { useNavigate } from 'react-router';

const AdminHeader: React.FC = () => {
  const { i18n, t } = useTranslation();
  const { isDarkMode, toggleTheme } = useThemeStore();
  const { logout } = useAuthStore();
  const navigate = useNavigate();

  const toggleLanguage = () => {
    i18n.changeLanguage(i18n.language === 'en' ? 'ar' : 'en');
  };

  const handleLogout = () => {
    logout();
    navigate('/login');
  };

  return (
    <header style={{
      height: '64px',
      background: 'var(--color-bg-surface)',
      borderBottom: '1px solid var(--color-border)',
      display: 'flex',
      alignItems: 'center',
      justifyContent: 'space-between',
      padding: '0 1.5rem',
      position: 'sticky',
      top: 0,
      zIndex: 10
    }}>
      <div>
        {/* Breadcrumbs or page title could go here */}
      </div>

      <div style={{ display: 'flex', alignItems: 'center', gap: '1rem' }}>
        <button 
          onClick={toggleLanguage}
          style={{ 
            display: 'flex', 
            alignItems: 'center', 
            gap: '0.5rem',
            color: 'var(--color-text-secondary)',
            padding: '0.5rem',
            borderRadius: 'var(--radius-md)'
          }}
          title={i18n.language === 'en' ? 'Switch to Arabic' : 'Switch to English'}
        >
          <Globe size={20} />
          <span style={{ fontSize: '0.875rem', fontWeight: 500, textTransform: 'uppercase' }}>
            {i18n.language}
          </span>
        </button>

        <button 
          onClick={toggleTheme}
          style={{ 
            color: 'var(--color-text-secondary)',
            padding: '0.5rem',
            borderRadius: 'var(--radius-md)',
            display: 'flex'
          }}
          title="Toggle Theme"
        >
          {isDarkMode ? <Sun size={20} /> : <Moon size={20} />}
        </button>

        <div style={{ height: '24px', width: '1px', background: 'var(--color-border)' }}></div>

        <div style={{ display: 'flex', alignItems: 'center', gap: '0.75rem' }}>
          <div style={{
            width: '36px',
            height: '36px',
            borderRadius: '50%',
            background: 'var(--color-primary)',
            color: 'white',
            display: 'flex',
            alignItems: 'center',
            justifyContent: 'center'
          }}>
            <User size={20} />
          </div>
          <div style={{ display: 'flex', flexDirection: 'column' }}>
            <span style={{ fontSize: '0.875rem', fontWeight: 500 }}>Admin User</span>
            <span style={{ fontSize: '0.75rem', color: 'var(--color-text-muted)' }}>Superadmin</span>
          </div>
          
          <button 
            onClick={handleLogout}
            style={{ 
              marginLeft: '0.5rem',
              color: 'var(--color-danger)',
              padding: '0.5rem',
              borderRadius: 'var(--radius-md)',
              display: 'flex'
            }}
            title={t('common.logout')}
          >
            <LogOut size={18} />
          </button>
        </div>
      </div>
    </header>
  );
};

export default AdminHeader;
