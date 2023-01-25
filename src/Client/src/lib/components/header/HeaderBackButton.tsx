import {useRouter} from 'next/router';
import type {FC} from 'react';

const HeaderBackButton: FC = () => {
  const router = useRouter();

  if (router.pathname === '/') {
    return null;
  }

  return (
    <button
      className="relative z-50 mr-4 hidden rounded-lg bg-white
      py-[0.33rem] px-[0.66rem] text-sm shadow-md sm:mr-auto sm:inline-flex"
      onClick={() => router.back()}>
      Back
    </button>
  );
};

export default HeaderBackButton;
