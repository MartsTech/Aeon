import Button from '@lib/components/button/Button';
import Image from 'next/image';
import Link from 'next/link';

const BookmarksEmpty = () => {
  return (
    <div
      className="flex flex-col space-y-10 p-6 sm:p-12 md:flex-row
      md:space-x-10 md:space-y-0">
      <div className="relative flex-[60%] p-32">
        <Image
          fill
          src="/images/bookmarks.svg"
          alt="Empty bookmarks"
          className="absolute object-contain py-4 px-8"
        />
      </div>
      <div className="items-start rounded-lg bg-white p-6 shadow-sm md:p-8">
        <h4 className="mb-2 text-2xl font-semibold">Its empty here.</h4>
        <p className="mb-12">
          Somethings catching your eye? Add your favorite items to Bookmarks,
          and check them out anytime you wish.
        </p>
        <div className="mt-4">
          <Link href="/">
            <Button variant="primary">Go Shopping</Button>
          </Link>
        </div>
      </div>
    </div>
  );
};

export default BookmarksEmpty;
