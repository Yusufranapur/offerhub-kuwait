import { useTranslation } from 'react-i18next';

export default function SubscriptionPage() {
  const { t } = useTranslation();

  return (
    <div className="flex flex-col gap-6">
      <h1 className="text-2xl font-bold">{t('common.subscription')}</h1>
      <div className="card border-gold border-2">
        <h2 className="text-xl text-gold font-bold mb-2">Premium Partner Plan</h2>
        <p>Your subscription is active until Dec 31, 2026.</p>
        <button className="btn btn-primary mt-4">Renew Subscription</button>
      </div>
    </div>
  );
}
