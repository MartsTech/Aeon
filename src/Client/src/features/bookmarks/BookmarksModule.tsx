import {pageTransition, pageZoom} from '@lib/utils/animations';
import {motion} from 'framer-motion';
import BookmarksEmpty from './BookmarksEmpty';

const BookmarksModule = () => {
  return (
    <motion.div
      initial="initial"
      animate="in"
      exit="out"
      variants={pageZoom}
      transition={pageTransition}
      className="px-2 py-8">
      <h4 className="mb-12 text-2xl font-semibold">Bookmarks</h4>
      <BookmarksEmpty />
    </motion.div>
  );
};

export default BookmarksModule;
