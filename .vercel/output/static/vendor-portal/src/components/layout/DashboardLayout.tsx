import { Outlet } from 'react-router';
import Sidebar from './Sidebar';
import Header from './Header';
import './DashboardLayout.css';

export default function DashboardLayout() {
  return (
    <div className="dashboard-layout">
      <Sidebar />
      <div className="main-content">
        <Header />
        <main className="content-wrapper">
          <Outlet />
        </main>
      </div>
    </div>
  );
}
