import type {FC} from 'react';
import HeaderBackButton from './HeaderBackButton';
import HeaderLogo from './HeaderLogo';
import HeaderSearch from './HeaderSearch';

const Header: FC = () => {
  return (
    <header
      className="relative flex items-center justify-end p-6
      sm:p-12 sm:pb-0">
      <HeaderBackButton />
      <HeaderSearch />
      <HeaderLogo />
    </header>
  );
};

export default Header;
