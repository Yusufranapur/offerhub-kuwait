import { useParams } from 'react-router';

export default function OfferDetailPage() {
  const { id } = useParams();

  return (
    <div className="flex flex-col gap-6">
      <h1 className="text-2xl font-bold">Edit Offer #{id}</h1>
      <div className="card">
        <p>Offer form details go here...</p>
      </div>
    </div>
  );
}
