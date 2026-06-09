import { useTranslation } from 'react-i18next';
import { Bell, Globe, LogOut, Menu } from 'lucide-react';
import { useAuth } from '../../hooks/useAuth';
import { useLanguage } from '../../hooks/useLanguage';
import './Header.css';

export default function Header() {
  const { t } = useTranslation();
  const { logout, user } = useAuth();
  const { language, toggleLanguage } = useLanguage();

  return (
    <header className="header">
      <div className="header-left">
        <button className="icon-btn mobile-menu-btn">
          <Menu size={24} />
        </button>
        <h2 className="header-title">{t('common.welcome')}, {user?.name || 'Vendor'}</h2>
      </div>

      <div className="header-right">
        <button className="icon-btn lang-btn" onClick={toggleLanguage} title="Switch Language">
          <Globe size={20} />
          <span>{language === 'en' ? 'عربي' : 'EN'}</span>
        </button>
        
        <button className="icon-btn notification-btn">
          <Bell size={20} />
          <span className="badge">3</span>
        </button>

        <div className="user-profile">
          <div className="avatar">
            {user?.name?.charAt(0) || 'V'}
          </div>
          <button className="icon-btn text-danger" onClick={logout} title={t('common.logout')}>
            <LogOut size={20} />
          </button>
        </div>
      </div>
    </header>
  );
}
