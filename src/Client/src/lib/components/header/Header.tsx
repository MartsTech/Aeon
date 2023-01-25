import type {FC} from 'react';
import HeaderBackButton from './HeaderBackButton';
import HeaderLogo from './HeaderLogo';
import HeaderSearch from './HeaderSearch';

const Header: FC = () => {
  return (
    <header
      className="sticky top-0 z-40 ml-2 flex items-center
     justify-end bg-background p-6 pb-4 sm:p-12 sm:pb-3">
      <HeaderBackButton />
      <HeaderSearch />
      <HeaderLogo />
    </header>
  );
};

export default Header;
