import React from 'react';

interface BadgeProps {
  children: React.ReactNode;
  variant?: 'success' | 'warning' | 'danger' | 'info' | 'default';
}

const Badge: React.FC<BadgeProps> = ({ children, variant = 'default' }) => {
  const colors = {
    success: { bg: 'rgba(16, 185, 129, 0.15)', color: 'var(--color-success)' },
    warning: { bg: 'rgba(245, 158, 11, 0.15)', color: 'var(--color-warning)' },
    danger: { bg: 'rgba(239, 68, 68, 0.15)', color: 'var(--color-danger)' },
    info: { bg: 'rgba(59, 130, 246, 0.15)', color: 'var(--color-info)' },
    default: { bg: 'var(--color-bg-surface-hover)', color: 'var(--color-text-secondary)' }
  };

  return (
    <span style={{
      display: 'inline-flex',
      alignItems: 'center',
      padding: '0.125rem 0.5rem',
      borderRadius: '9999px',
      fontSize: '0.75rem',
      fontWeight: 600,
      backgroundColor: colors[variant].bg,
      color: colors[variant].color,
    }}>
      {children}
    </span>
  );
};

export default Badge;
