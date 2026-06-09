import { useTranslation } from 'react-i18next';

export default function BusinessProfilePage() {
  const { t } = useTranslation();

  return (
    <div className="flex flex-col gap-6">
      <div className="flex justify-between items-center">
        <h1 className="text-2xl font-bold">{t('common.profile')}</h1>
        <button className="btn btn-primary">{t('common.save')}</button>
      </div>

      <div className="card">
        <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
          <div className="form-group">
            <label>Business Name (English)</label>
            <input type="text" defaultValue="Burger Boutique" />
          </div>
          <div className="form-group">
            <label>Business Name (Arabic)</label>
            <input type="text" defaultValue="برجر بوتيك" dir="rtl" />
          </div>
          <div className="form-group">
            <label>Category</label>
            <select>
              <option>Food & Beverage</option>
              <option>Retail</option>
              <option>Entertainment</option>
            </select>
          </div>
          <div className="form-group">
            <label>Contact Email</label>
            <input type="email" defaultValue="hello@burgerboutique.com" />
          </div>
          <div className="form-group md:col-span-2">
            <label>Description</label>
            <textarea rows={4} defaultValue="Premium craft burgers in Kuwait." />
          </div>
        </div>
      </div>
    </div>
  );
}
