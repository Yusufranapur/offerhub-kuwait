import { useTranslation } from 'react-i18next';
import { useNavigate } from 'react-router';
import { useState } from 'react';
import { offerService } from '../../services/offerService';

export default function CreateOfferPage() {
  const { t } = useTranslation();
  const navigate = useNavigate();
  
  const [formData, setFormData] = useState({
    title: '',
    titleAr: '',
    description: '',
    descriptionAr: '',
    discountType: 'Percentage',
    discountValue: 0,
    startDate: '',
    endDate: '',
    maxClaims: 100,
    vendorId: '00000000-0000-0000-0000-000000000000', // Mock VendorId for now, update with real auth context later
    categoryId: '00000000-0000-0000-0000-000000000000'
  });

  const [loading, setLoading] = useState(false);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    const { name, value } = e.target;
    setFormData(prev => ({
      ...prev,
      [name]: name === 'discountValue' || name === 'maxClaims' ? Number(value) : value
    }));
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);
    try {
      await offerService.createOffer({
          ...formData,
          discountType: formData.discountType === 'Percentage' ? 0 : formData.discountType === 'FixedAmount' ? 1 : 2
      });
      navigate('/offers');
    } catch (error) {
      console.error('Failed to create offer', error);
      alert('Failed to create offer');
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="flex flex-col gap-6 max-w-3xl">
      <div className="flex justify-between items-center">
        <h1 className="text-2xl font-bold">{t('offers.create')}</h1>
      </div>

      <div className="card">
        <form className="flex flex-col gap-6" onSubmit={handleSubmit}>
          <div className="form-group">
            <label>{t('offers.name')} (EN)</label>
            <input type="text" name="title" value={formData.title} onChange={handleChange} required placeholder="e.g. 50% Off All Coffee" />
          </div>
          
          <div className="grid grid-cols-2 gap-6">
            <div className="form-group">
              <label>{t('offers.type')}</label>
              <select name="discountType" value={formData.discountType} onChange={handleChange}>
                <option value="Percentage">Percentage Discount</option>
                <option value="FixedAmount">Fixed Amount Off</option>
                <option value="BuyOneGetOne">Buy 1 Get 1 Free</option>
              </select>
            </div>
            <div className="form-group">
              <label>{t('offers.discount')}</label>
              <input type="number" name="discountValue" value={formData.discountValue} onChange={handleChange} required placeholder="e.g. 50" />
            </div>
          </div>

          <div className="grid grid-cols-2 gap-6">
            <div className="form-group">
              <label>Valid From</label>
              <input type="datetime-local" name="startDate" value={formData.startDate} onChange={handleChange} required />
            </div>
            <div className="form-group">
              <label>{t('offers.valid_until')}</label>
              <input type="datetime-local" name="endDate" value={formData.endDate} onChange={handleChange} required />
            </div>
          </div>

          <div className="flex justify-end gap-4 mt-4">
            <button type="button" className="btn btn-secondary" onClick={() => navigate('/offers')}>
              {t('common.cancel')}
            </button>
            <button type="submit" className="btn btn-primary" disabled={loading}>
              {loading ? 'Saving...' : t('common.save')}
            </button>
          </div>
        </form>
      </div>
    </div>
  );
}
