import {bookmarksCountSelector} from '@features/bookmarks/bookmarks-state';
import {cartTotalCountSelector} from '@features/cart/cart-state';
import {
  BookmarkIcon,
  ClockIcon,
  HomeIcon,
  ShoppingCartIcon,
  UserCircleIcon,
} from '@heroicons/react/24/outline';
import {useStoreSelector} from '@lib/store/store-hooks';
import {FC} from 'react';
import SidebarLogo from './SidebarLogo';
import SidebarMenuItem from './SidebarMenuItem';

interface Props {
  authenticated: boolean;
  active: boolean;
  toggleSidebar: () => void;
}

const Sidebar: FC<Props> = ({authenticated, active, toggleSidebar}) => {
  const bookmarksCount = useStoreSelector(bookmarksCountSelector);
  const cartTotalCount = useStoreSelector(cartTotalCountSelector);

  return (
    <section
      className={`fixed top-0 left-0 z-50 flex h-screen max-h-screen
      w-20 -translate-x-20 transform flex-col items-center
      justify-between bg-white py-6 shadow-lg transition-all duration-200
      sm:w-24 sm:translate-x-0 sm:py-12 ${active && 'translate-x-0'}`}>
      <SidebarLogo active={active} toggleSidebar={toggleSidebar} />
      <div className="flex flex-col">
        <SidebarMenuItem
          Icon={HomeIcon}
          paths={['/']}
          sidebarActive={active}
          toggleSidebar={toggleSidebar}
        />
        <SidebarMenuItem
          Icon={ShoppingCartIcon}
          paths={['/cart']}
          count={cartTotalCount}
          sidebarActive={active}
          toggleSidebar={toggleSidebar}
        />
        <SidebarMenuItem
          Icon={BookmarkIcon}
          paths={['/bookmarks']}
          count={bookmarksCount}
          sidebarActive={active}
          toggleSidebar={toggleSidebar}
        />
        <SidebarMenuItem
          Icon={ClockIcon}
          paths={['/orders']}
          sidebarActive={active}
          toggleSidebar={toggleSidebar}
        />
      </div>
      <SidebarMenuItem
        Icon={UserCircleIcon}
        paths={!authenticated ? ['/login'] : ['/account']}
        sidebarActive={active}
        toggleSidebar={toggleSidebar}
      />
    </section>
  );
};

export default Sidebar;
