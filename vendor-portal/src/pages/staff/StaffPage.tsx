import { useTranslation } from 'react-i18next';

export default function StaffPage() {
  const { t } = useTranslation();

  return (
    <div className="flex flex-col gap-6">
      <h1 className="text-2xl font-bold">{t('common.staff')}</h1>
      <div className="card">
        <p>Manage branch managers and cashiers here. They can use the Staff App to scan QR codes.</p>
      </div>
    </div>
  );
}
