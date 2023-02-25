import Button from '@lib/components/button/Button';
import {errorAnimation} from '@lib/utils/animations';
import {motion} from 'framer-motion';
import Image from 'next/image';
import Link from 'next/link';

const CheckoutSuccessSummary = () => {
  return (
    <motion.div
      initial="initial"
      animate="in"
      exit="out"
      variants={errorAnimation}
      className="self-start rounded-lg bg-white 
      p-8 shadow-lg lg:max-w-[40%] lg:flex-[40%]">
      <div className="relative h-52 w-52">
        <Image
          fill
          className="absolute h-full w-full object-contain"
          src="/images/success.svg"
          alt="success"
        />
      </div>

      <h5 className="text-xl font-semibold">Yay, it is done!</h5>
      <p>
        Your payment has been successfully processed and we have received your
        order. Check your email for further details.
      </p>
      <Link href="/orders">
        <Button variant="primary" className={`mt-8 w-full uppercase`}>
          My Orders
        </Button>
      </Link>
    </motion.div>
  );
};

export default CheckoutSuccessSummary;
