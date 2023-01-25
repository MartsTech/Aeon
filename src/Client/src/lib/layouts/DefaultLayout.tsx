import {authSignedSelector} from '@features/auth/auth-state';
import Footer from '@lib/components/footer/Footer';
import Header from '@lib/components/header/Header';
import Sidebar from '@lib/components/sidebar/Sidebar';
import {useStoreSelector} from '@lib/store/store-hooks';
import {AnimatePresence, AnimateSharedLayout} from 'framer-motion';
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
    <div className="relative flex min-h-screen w-screen flex-col bg-background">
      <Sidebar
        authenticated={signed}
        active={sidebarActive}
        toggleSidebar={toggleSidebar}
      />
      <div
        className="mx-auto flex w-full max-w-screen-1xl flex-grow
        flex-col sm:pl-24">
        <AnimatePresence mode="wait">
          <AnimateSharedLayout>
            <Header />
            {children}
          </AnimateSharedLayout>
        </AnimatePresence>
      </div>

      <Footer />
    </div>
  );
};

export default DefaultLayout;
