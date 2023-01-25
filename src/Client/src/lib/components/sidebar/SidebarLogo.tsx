import Image from 'next/image';
import type {FC} from 'react';

interface Props {
  active?: boolean;
  toggleSidebar: () => void;
}

const SidebarLogo: FC<Props> = ({active, toggleSidebar}) => {
  return (
    <div
      className={`relative z-20 h-8 w-8 translate-x-20 transform
      rounded-full bg-white p-2 shadow-md transition-all 
      duration-200 sm:h-10 sm:w-10 sm:translate-x-0 sm:p-0 sm:shadow-none
      ${active && '!translate-x-0 !shadow-none'}`}>
      <Image
        loading="lazy"
        src="/icons/icon-512x512.png"
        alt="icon"
        onClick={toggleSidebar}
        className="absolute rounded-full object-contain"
        fill={true}
      />
    </div>
  );
};

export default SidebarLogo;
