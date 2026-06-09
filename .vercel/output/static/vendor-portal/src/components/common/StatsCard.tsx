import { ReactNode } from 'react';
import './StatsCard.css';

interface StatsCardProps {
  title: string;
  value: string | number;
  icon: ReactNode;
  trend?: {
    value: number;
    isPositive: boolean;
  };
}

export default function StatsCard({ title, value, icon, trend }: StatsCardProps) {
  return (
    <div className="card stats-card">
      <div className="stats-header">
        <h3 className="stats-title">{title}</h3>
        <div className="stats-icon">{icon}</div>
      </div>
      <div className="stats-body">
        <div className="stats-value">{value}</div>
        {trend && (
          <div className={`stats-trend ${trend.isPositive ? 'positive' : 'negative'}`}>
            {trend.isPositive ? '+' : '-'}{Math.abs(trend.value)}%
            <span className="trend-label">vs last month</span>
          </div>
        )}
      </div>
    </div>
  );
}
