import {authSignedSelector} from '@features/auth/auth-state';
import Footer from '@lib/components/footer/Footer';
import Header from '@lib/components/header/Header';
import Sidebar from '@lib/components/sidebar/Sidebar';
import {useStoreSelector} from '@lib/store/store-hooks';
import {LayoutGroup} from 'framer-motion';
import {FC, ReactNode, useCallback, useState} from 'react';

interface Props {
  children: ReactNode;
}

const DefaultLayout: FC<Props> = ({children}) => {
  const signed = useStoreSelector(authSignedSelector);

  const [sidebarActive, setSidebarActive] = useState(false);

  const toggleSidebar = useCallback(() => {
    setSidebarActive(prev => !prev);
  }, []);

  return (
    <div
      className="flex min-h-screen w-screen flex-col 
      bg-background">
      <Sidebar
        authenticated={signed}
        active={sidebarActive}
        toggleSidebar={toggleSidebar}
      />
      <div className="sticky top-0 z-40 sm:pl-24">
        <Header />
      </div>
      <main
        className="mx-auto flex w-full max-w-screen-1xl flex-1
        flex-grow flex-col sm:pl-24">
        <LayoutGroup>{children}</LayoutGroup>
      </main>
      <Footer />
    </div>
  );
};

export default DefaultLayout;
