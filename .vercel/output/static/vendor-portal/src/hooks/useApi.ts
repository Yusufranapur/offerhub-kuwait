import { useState, useEffect } from 'react';

export function useApi<T>(apiFunc: () => Promise<{data: T}>, dependencies: any[] = []) {
  const [data, setData] = useState<T | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    let mounted = true;
    const fetchData = async () => {
      setLoading(true);
      try {
        const response = await apiFunc();
        if (mounted) {
          setData(response.data);
          setError(null);
        }
      } catch (err: any) {
        if (mounted) {
          setError(err.message || 'An error occurred');
        }
      } finally {
        if (mounted) {
          setLoading(false);
        }
      }
    };

    fetchData();

    return () => {
      mounted = false;
    };
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, dependencies);

  return { data, loading, error };
}
