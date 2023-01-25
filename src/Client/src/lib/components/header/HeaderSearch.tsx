import {MagnifyingGlassIcon} from '@heroicons/react/24/solid';
import type {FC} from 'react';

const HeaderSearch: FC = () => {
  return (
    <div
      className="relative mx-10 flex w-full items-center
      rounded-lg bg-white py-[0.33rem] pr-[0.15rem] pl-[0.66rem] 
      text-sm shadow-md sm:mr-4 sm:w-auto">
      <MagnifyingGlassIcon className="h-5 w-5 scale-95 transform fill-text opacity-75" />
      <input
        type="text"
        placeholder="Search..."
        className="flex-grow border-none bg-none px-2 placeholder-text
        placeholder-opacity-50 focus:outline-none"
      />
    </div>
  );
};

export default HeaderSearch;
