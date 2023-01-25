import BookmarksModule from '@features/bookmarks/BookmarksModule';
import DefaultLayout from '@lib/layouts/DefaultLayout';
import type {NextPageWithLayout} from '@lib/types/page';
import type {ReactElement} from 'react';

const Bookmarks: NextPageWithLayout = () => {
  return <BookmarksModule />;
};

export default Bookmarks;

Bookmarks.getLayout = (page: ReactElement) => {
  return <DefaultLayout>{page}</DefaultLayout>;
};
