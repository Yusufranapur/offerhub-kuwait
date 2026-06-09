import React from 'react';

interface CardProps {
  children: React.ReactNode;
  title?: string;
  className?: string;
  style?: React.CSSProperties;
  noPadding?: boolean;
}

const Card: React.FC<CardProps> = ({ children, title, className, style, noPadding = false }) => {
  return (
    <div 
      className={`glass-panel ${className || ''}`}
      style={{ 
        display: 'flex', 
        flexDirection: 'column',
        ...style 
      }}
    >
      {title && (
        <div style={{ 
          padding: '1.25rem 1.5rem', 
          borderBottom: '1px solid var(--color-border)',
          fontWeight: 600,
          fontSize: '1.125rem'
        }}>
          {title}
        </div>
      )}
      <div style={{ padding: noPadding ? '0' : '1.5rem', flex: 1 }}>
        {children}
      </div>
    </div>
  );
};

export default Card;
