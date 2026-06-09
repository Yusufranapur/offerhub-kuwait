import React from 'react';

interface ButtonProps extends React.ButtonHTMLAttributes<HTMLButtonElement> {
  variant?: 'primary' | 'secondary' | 'danger' | 'outline' | 'ghost';
  size?: 'sm' | 'md' | 'lg';
  fullWidth?: boolean;
}

const Button: React.FC<ButtonProps> = ({ 
  children, 
  variant = 'primary', 
  size = 'md', 
  fullWidth = false,
  style,
  ...props 
}) => {
  const baseStyle: React.CSSProperties = {
    display: 'inline-flex',
    alignItems: 'center',
    justifyContent: 'center',
    fontWeight: 500,
    borderRadius: 'var(--radius-md)',
    transition: 'all 0.2s',
    width: fullWidth ? '100%' : 'auto',
    cursor: props.disabled ? 'not-allowed' : 'pointer',
    opacity: props.disabled ? 0.6 : 1,
  };

  const variants = {
    primary: {
      background: 'var(--color-primary)',
      color: 'white',
      border: '1px solid var(--color-primary)',
    },
    secondary: {
      background: 'var(--color-secondary)',
      color: '#fff',
      border: '1px solid var(--color-secondary)',
    },
    danger: {
      background: 'var(--color-danger)',
      color: 'white',
      border: '1px solid var(--color-danger)',
    },
    outline: {
      background: 'transparent',
      color: 'var(--color-text-primary)',
      border: '1px solid var(--color-border)',
    },
    ghost: {
      background: 'transparent',
      color: 'var(--color-text-primary)',
      border: '1px solid transparent',
    }
  };

  const sizes = {
    sm: { padding: '0.375rem 0.75rem', fontSize: '0.875rem' },
    md: { padding: '0.5rem 1rem', fontSize: '0.875rem' },
    lg: { padding: '0.75rem 1.5rem', fontSize: '1rem' },
  };

  return (
    <button 
      style={{ ...baseStyle, ...variants[variant], ...sizes[size], ...style }} 
      {...props}
    >
      {children}
    </button>
  );
};

export default Button;
