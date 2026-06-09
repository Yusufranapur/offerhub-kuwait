import { NavLink } from 'react-router';
import { useTranslation } from 'react-i18next';
import { 
  LayoutDashboard, 
  Store, 
  MapPin, 
  Tags, 
  Users, 
  ScanLine, 
  CreditCard, 
  Settings 
} from 'lucide-react';
import './Sidebar.css';

const navItems = [
  { path: '/dashboard', icon: LayoutDashboard, label: 'dashboard' },
  { path: '/profile', icon: Store, label: 'profile' },
  { path: '/branches', icon: MapPin, label: 'branches' },
  { path: '/offers', icon: Tags, label: 'offers' },
  { path: '/staff', icon: Users, label: 'staff' },
  { path: '/redemption', icon: ScanLine, label: 'redemption' },
  { path: '/subscription', icon: CreditCard, label: 'subscription' },
  { path: '/settings', icon: Settings, label: 'settings' },
];

export default function Sidebar() {
  const { t } = useTranslation();

  return (
    <aside className="sidebar">
      <div className="sidebar-header">
        <div className="logo">
          <span className="logo-accent">Offer</span>Hub
        </div>
        <div className="vendor-badge">Vendor Portal</div>
      </div>

      <nav className="sidebar-nav">
        {navItems.map((item) => (
          <NavLink 
            key={item.path} 
            to={item.path}
            className={({ isActive }) => `nav-link ${isActive ? 'active' : ''}`}
          >
            <item.icon className="nav-icon" size={20} />
            <span>{t(`common.${item.label}`)}</span>
          </NavLink>
        ))}
      </nav>
    </aside>
  );
}
