import Button from '@lib/components/button/Button';
import Image from 'next/image';
import Link from 'next/link';

const CartEmpty = () => {
  return (
    <div
      className="flex flex-col space-y-10 md:flex-row 
      md:space-x-10 md:space-y-0">
      <div className="relative flex-[60%] p-32">
        <Image
          fill
          src="/images/cart.svg"
          alt="Empty cart"
          className="absolute object-contain py-4 px-8"
        />
      </div>
      <div className="items-start rounded-lg bg-white p-6 shadow-sm md:p-8">
        <h4 className="mb-2 text-2xl font-semibold">Your cart feels lonely.</h4>
        <p className="mb-12">
          Your shopping cart lives to serve. Give it purpose - fill it with
          books, electronicts, videos, etc. and make it happy.
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

export default CartEmpty;
