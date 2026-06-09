import React from 'react';
import { Outlet, Navigate } from 'react-router';
import AdminSidebar from './AdminSidebar';
import AdminHeader from './AdminHeader';
import { useAuthStore } from '../../store/authStore';

const AdminLayout: React.FC = () => {
  const { isAuthenticated } = useAuthStore();

  // If not authenticated, redirect to login page
  if (!isAuthenticated) {
    // For demo purposes, we will mock auth
    // return <Navigate to="/login" replace />;
  }

  return (
    <div style={{ display: 'flex', height: '100vh', overflow: 'hidden' }}>
      <AdminSidebar />
      <div style={{ flex: 1, display: 'flex', flexDirection: 'column', overflow: 'hidden' }}>
        <AdminHeader />
        <main style={{ flex: 1, overflowY: 'auto', padding: '1rem', background: 'var(--color-bg-base)' }}>
          <Outlet />
        </main>
      </div>
    </div>
  );
};

export default AdminLayout;
