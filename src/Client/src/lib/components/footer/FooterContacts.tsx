import appConstants from '@features/app/app-constants';
import Image from 'next/image';
import type {FC} from 'react';

const FooterContacts: FC = () => {
  return (
    <div className="flex items-center bg-accent py-8 px-12">
      <Image
        height={40}
        width={40}
        src="/icons/icon-512x512.png"
        alt="logo"
        className="object-contain"
      />
      <span className="ml-4 whitespace-nowrap text-sm opacity-75">
        &copy; 2023 | Developed by{' '}
        <a
          href={appConstants.APP_SOURCE_CODE_URL}
          className="border-b border-dotted border-primary
          text-primary transition-all duration-200
          hover:border-red-600 hover:text-red-600">
          {appConstants.APP_TEAM_NAME}
        </a>
      </span>
    </div>
  );
};

export default FooterContacts;
