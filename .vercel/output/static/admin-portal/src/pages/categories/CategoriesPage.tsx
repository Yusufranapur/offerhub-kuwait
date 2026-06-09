import React from 'react';
import Card from '../../components/common/Card';
import Button from '../../components/common/Button';
import { FolderTree, Edit, Trash2, GripVertical } from 'lucide-react';

const mockCategories = [
  { id: 1, name: 'Electronics', count: 120, icon: '💻' },
  { id: 2, name: 'Food & Dining', count: 350, icon: '🍔' },
  { id: 3, name: 'Fashion', count: 85, icon: '👕' },
  { id: 4, name: 'Health & Beauty', count: 64, icon: '✨' },
];

const CategoriesPage: React.FC = () => {
  return (
    <div className="page-container">
      <div className="page-header">
        <h1 className="page-title">Categories Management</h1>
        <Button>Add Category</Button>
      </div>

      <Card>
        <div className="flex-col gap-4">
          {mockCategories.map((cat) => (
            <div key={cat.id} className="flex justify-between items-center" style={{ padding: '1rem', border: '1px solid var(--color-border)', borderRadius: 'var(--radius-md)', background: 'var(--color-bg-base)' }}>
              <div className="flex items-center gap-4">
                <GripVertical size={20} className="text-muted" style={{ cursor: 'grab' }} />
                <div style={{ fontSize: '1.5rem' }}>{cat.icon}</div>
                <div>
                  <h4 className="font-medium">{cat.name}</h4>
                  <p className="text-xs text-secondary">{cat.count} items</p>
                </div>
              </div>
              <div className="flex gap-2">
                <Button variant="ghost" size="sm">
                  <Edit size={16} />
                </Button>
                <Button variant="ghost" size="sm" style={{ color: 'var(--color-danger)' }}>
                  <Trash2 size={16} />
                </Button>
              </div>
            </div>
          ))}
        </div>
      </Card>
    </div>
  );
};

export default CategoriesPage;
