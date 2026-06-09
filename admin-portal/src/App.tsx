import React, { useEffect } from 'react';
import { BrowserRouter, Routes, Route, Navigate } from 'react-router';
import { useTranslation } from 'react-i18next';
import { useThemeStore } from './store/themeStore';
import AdminLayout from './components/layout/AdminLayout';
import LoginPage from './pages/auth/LoginPage';
import DashboardPage from './pages/dashboard/DashboardPage';
import VendorsPage from './pages/vendors/VendorsPage';
import VendorDetailPage from './pages/vendors/VendorDetailPage';
import OffersPage from './pages/offers/OffersPage';
import CategoriesPage from './pages/categories/CategoriesPage';
import BannersPage from './pages/banners/BannersPage';
import NotificationsPage from './pages/notifications/NotificationsPage';
import CmsPage from './pages/cms/CmsPage';
import SubscriptionPlansPage from './pages/subscriptions/SubscriptionPlansPage';
import AnalyticsPage from './pages/analytics/AnalyticsPage';
import AuditLogsPage from './pages/audit/AuditLogsPage';
import UsersPage from './pages/users/UsersPage';

function App() {
  const { i18n } = useTranslation();
  const { isDarkMode } = useThemeStore();

  useEffect(() => {
    document.documentElement.dir = i18n.language === 'ar' ? 'rtl' : 'ltr';
    document.documentElement.lang = i18n.language;
  }, [i18n.language]);

  useEffect(() => {
    if (isDarkMode) {
      document.documentElement.classList.add('dark');
    } else {
      document.documentElement.classList.remove('dark');
    }
  }, [isDarkMode]);

  return (
    <BrowserRouter>
      <Routes>
        <Route path="/login" element={<LoginPage />} />
        
        <Route path="/" element={<AdminLayout />}>
          <Route index element={<Navigate to="/dashboard" replace />} />
          <Route path="dashboard" element={<DashboardPage />} />
          
          <Route path="vendors" element={<VendorsPage />} />
          <Route path="vendors/:id" element={<VendorDetailPage />} />
          
          <Route path="offers" element={<OffersPage />} />
          <Route path="categories" element={<CategoriesPage />} />
          <Route path="banners" element={<BannersPage />} />
          <Route path="notifications" element={<NotificationsPage />} />
          <Route path="cms" element={<CmsPage />} />
          <Route path="subscriptions" element={<SubscriptionPlansPage />} />
          <Route path="analytics" element={<AnalyticsPage />} />
          <Route path="audit" element={<AuditLogsPage />} />
          <Route path="users" element={<UsersPage />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
