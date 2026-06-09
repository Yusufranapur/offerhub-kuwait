import { useTranslation } from 'react-i18next';

export default function RedemptionPage() {
  const { t } = useTranslation();

  return (
    <div className="flex flex-col gap-6">
      <h1 className="text-2xl font-bold">{t('common.redemption')}</h1>
      <div className="card">
        <p>View real-time redemption logs and analytics.</p>
      </div>
    </div>
  );
}
