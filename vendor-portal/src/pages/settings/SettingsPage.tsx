import { useTranslation } from 'react-i18next';

export default function SettingsPage() {
  const { t } = useTranslation();

  return (
    <div className="flex flex-col gap-6">
      <h1 className="text-2xl font-bold">{t('common.settings')}</h1>
      <div className="card">
        <h3 className="text-lg font-bold mb-4">Notification Settings</h3>
        <label className="flex items-center gap-2 mb-2 cursor-pointer">
          <input type="checkbox" defaultChecked />
          <span>Email on new redemption</span>
        </label>
        <label className="flex items-center gap-2 cursor-pointer">
          <input type="checkbox" defaultChecked />
          <span>Weekly performance report</span>
        </label>
      </div>
    </div>
  );
}
