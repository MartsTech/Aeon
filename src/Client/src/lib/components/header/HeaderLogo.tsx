import appConstants from '@features/app/app-constants';
import Image from 'next/image';
import {FC} from 'react';

const HeaderLogo: FC = () => {
  return (
    <div className="hidden cursor-default space-x-2 sm:flex">
      <Image
        loading="lazy"
        src="/icons/icon-512x512.png"
        alt="icon"
        className="rounded-full object-contain"
        height={32}
        width={32}
      />
      <h1 className="font-mono text-2xl font-medium">
        {appConstants.APP_NAME}
      </h1>
    </div>
  );
};

export default HeaderLogo;
