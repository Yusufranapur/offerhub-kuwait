import { useEffect } from 'react';
import { BrowserRouter, Routes, Route, Navigate } from 'react-router';
import { useTranslation } from 'react-i18next';
import DashboardLayout from './components/layout/DashboardLayout';
import LoginPage from './pages/auth/LoginPage';
import DashboardPage from './pages/dashboard/DashboardPage';
import BusinessProfilePage from './pages/profile/BusinessProfilePage';
import BranchesPage from './pages/branches/BranchesPage';
import OffersPage from './pages/offers/OffersPage';
import CreateOfferPage from './pages/offers/CreateOfferPage';
import OfferDetailPage from './pages/offers/OfferDetailPage';
import StaffPage from './pages/staff/StaffPage';
import RedemptionPage from './pages/redemption/RedemptionPage';
import SubscriptionPage from './pages/subscription/SubscriptionPage';
import SettingsPage from './pages/settings/SettingsPage';
import { useAuthStore } from './store/authStore';
import VerificationPage from './pages/verification/VerificationPage';

function ProtectedRoute({ children }: { children: React.ReactNode }) {
  const { isAuthenticated } = useAuthStore();
  if (!isAuthenticated) return <Navigate to="/login" replace />;
  return <>{children}</>;
}

export default function App() {
  const { i18n } = useTranslation();

  useEffect(() => {
    document.dir = i18n.language === 'ar' ? 'rtl' : 'ltr';
    document.documentElement.lang = i18n.language;
  }, [i18n.language]);

  return (
    <BrowserRouter>
      <Routes>
        <Route path="/login" element={<LoginPage />} />
        <Route path="/verification" element={<ProtectedRoute><VerificationPage /></ProtectedRoute>} />
        
        <Route path="/" element={<ProtectedRoute><DashboardLayout /></ProtectedRoute>}>
          <Route index element={<Navigate to="/dashboard" replace />} />
          <Route path="dashboard" element={<DashboardPage />} />
          <Route path="profile" element={<BusinessProfilePage />} />
          <Route path="branches" element={<BranchesPage />} />
          <Route path="offers" element={<OffersPage />} />
          <Route path="offers/create" element={<CreateOfferPage />} />
          <Route path="offers/:id" element={<OfferDetailPage />} />
          <Route path="staff" element={<StaffPage />} />
          <Route path="redemption" element={<RedemptionPage />} />
          <Route path="subscription" element={<SubscriptionPage />} />
          <Route path="settings" element={<SettingsPage />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}
