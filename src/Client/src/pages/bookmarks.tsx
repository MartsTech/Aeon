import {bookmarksApi} from '@features/bookmarks/bookmarks-api';
import BookmarksModule from '@features/bookmarks/BookmarksModule';
import {api} from '@lib/api';
import DefaultLayout from '@lib/layouts/DefaultLayout';
import {storeWrapper} from '@lib/store';
import type {NextPageWithLayout} from '@lib/types/page';
import type {GetServerSideProps} from 'next';
import {getSession} from 'next-auth/react';
import type {ReactElement} from 'react';

const Bookmarks: NextPageWithLayout = () => {
  return <BookmarksModule />;
};

export default Bookmarks;

Bookmarks.getLayout = (page: ReactElement) => {
  return <DefaultLayout>{page}</DefaultLayout>;
};

export const getServerSideProps: GetServerSideProps =
  storeWrapper.getServerSideProps(store => async ({req, res}) => {
    const session = await getSession({req});

    if (!session || !session.accessToken) {
      return {
        redirect: {
          destination: '/login',
          permanent: false,
        },
      };
    }

    const bookmarks = await store
      .dispatch(
        bookmarksApi.endpoints.getWishlists.initiate(session.accessToken),
      )
      .unwrap();

    if (bookmarks.length === 0) {
      store.dispatch(
        bookmarksApi.endpoints.createWishlist.initiate(session.accessToken),
      );
    }

    await Promise.all(store.dispatch(api.util.getRunningQueriesThunk()));

    res.setHeader(
      'Cache-Control',
      'public, s-maxage=10, stale-while-revalidate=59',
    );

    return {
      props: {},
    };
  });
