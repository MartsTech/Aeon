import Button from '@lib/components/button/Button';
import Image from 'next/image';
import Link from 'next/link';

const OrdersEmpty = () => {
  return (
    <div
      className="flex flex-col space-y-10 md:flex-row 
      md:space-x-10 md:space-y-0">
      <div className="relative flex-[60%] p-32">
        <Image
          fill
          src="/images/orders.svg"
          alt="No orders"
          className="absolute object-contain py-4 px-8"
        />
      </div>
      <div className="items-start rounded-lg bg-white p-6 shadow-sm md:p-8">
        <h4 className="mb-2 text-2xl font-semibold">
          Your order history is empty.
        </h4>
        <p className="mb-12">
          No past purchases? No problem. Start filling it up with the things you
          love and make it a history worth remembering.
        </p>
        <div className="mt-4">
          <Link href="/">
            <Button variant="primary">Continue Shopping</Button>
          </Link>
        </div>
      </div>
    </div>
  );
};

export default OrdersEmpty;
