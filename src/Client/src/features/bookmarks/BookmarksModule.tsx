import {useStoreSelector} from '@lib/store/store-hooks';
import {pageTransition, pageZoom} from '@lib/utils/animations';
import {motion} from 'framer-motion';
import {bookmarksEmptySelector} from './bookmarks-state';
import BookmarksEmpty from './BookmarksEmpty';
import BookmarksList from './BookmarksList';

const BookmarksModule = () => {
  const bookmarksEmpty = useStoreSelector(bookmarksEmptySelector);

  return (
    <motion.div
      initial="initial"
      animate="in"
      exit="out"
      variants={pageZoom}
      transition={pageTransition}
      className="px-2 py-8">
      <h4 className="mb-12 text-2xl font-semibold">Bookmarks</h4>
      {!bookmarksEmpty ? <BookmarksList /> : <BookmarksEmpty />}
    </motion.div>
  );
};

export default BookmarksModule;
