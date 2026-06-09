import React from 'react';
import Card from '../../components/common/Card';
import Button from '../../components/common/Button';
import Input from '../../components/common/Input';
import { Send, Bell } from 'lucide-react';

const NotificationsPage: React.FC = () => {
  return (
    <div className="page-container">
      <div className="page-header">
        <h1 className="page-title">Push Notifications</h1>
      </div>

      <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr', gap: '1.5rem' }}>
        <Card title="Send New Broadcast">
          <form className="flex-col gap-4">
            <Input label="Notification Title" placeholder="e.g. Flash Sale Alert!" />
            <div className="flex-col gap-1">
              <label className="text-sm font-medium text-secondary">Message Body</label>
              <textarea 
                rows={4}
                style={{
                  width: '100%',
                  padding: '0.75rem',
                  borderRadius: 'var(--radius-md)',
                  border: '1px solid var(--color-border)',
                  background: 'var(--color-bg-base)',
                  color: 'var(--color-text-primary)',
                  resize: 'vertical'
                }}
                placeholder="Enter your message here..."
              ></textarea>
            </div>
            <div className="flex-col gap-1">
              <label className="text-sm font-medium text-secondary">Target Audience</label>
              <select style={{ width: '100%', padding: '0.75rem', borderRadius: 'var(--radius-md)', border: '1px solid var(--color-border)', background: 'var(--color-bg-base)', color: 'var(--color-text-primary)' }}>
                <option>All Users</option>
                <option>Active Users (last 30 days)</option>
                <option>Inactive Users</option>
              </select>
            </div>
            <Button className="mt-4 flex items-center justify-center gap-2">
              <Send size={18} /> Send Broadcast
            </Button>
          </form>
        </Card>

        <Card title="Recent History">
          <div className="flex-col gap-4">
            {[1, 2, 3].map((i) => (
              <div key={i} className="flex gap-4 items-start pb-4 border-b border-border last:border-0 last:pb-0" style={{ borderBottom: i !== 3 ? '1px solid var(--color-border)' : 'none', paddingBottom: i !== 3 ? '1rem' : 0 }}>
                <div style={{ padding: '0.75rem', background: 'var(--color-bg-surface-hover)', borderRadius: '50%', color: 'var(--color-primary)' }}>
                  <Bell size={20} />
                </div>
                <div>
                  <h4 className="font-medium">Weekend Special Delivered</h4>
                  <p className="text-sm text-secondary">Sent to 12,450 users</p>
                  <p className="text-xs text-muted mt-1">2 days ago</p>
                </div>
              </div>
            ))}
          </div>
        </Card>
      </div>
    </div>
  );
};

export default NotificationsPage;
