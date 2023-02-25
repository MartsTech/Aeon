import CheckoutSummaryItems from './CheckoutSummaryItems';
import CheckoutSummaryPayments from './CheckoutSummaryPayments';

const CheckoutSummary = () => {
  return (
    <div className="w-full flex-1 self-start rounded-lg bg-white p-8 shadow-lg lg:max-w-[40%] lg:flex-[40%]">
      <h5 className="text-xl font-semibold">Order Summary</h5>
      <CheckoutSummaryItems />
      <CheckoutSummaryPayments />
    </div>
  );
};

export default CheckoutSummary;
