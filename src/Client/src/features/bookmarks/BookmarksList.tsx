import {useStoreSelector} from '@lib/store/store-hooks';
import {bookmarksItemsSelector} from './bookmarks-state';
import BookmarksItem from './BookmarksItem';

const BookmarksList = () => {
  const bookmarks = useStoreSelector(bookmarksItemsSelector);

  if (!bookmarks) {
    return null;
  }

  return (
    <div className="m-8 flex flex-col items-center md:grid md:grid-cols-2 lg:grid-cols-3">
      {bookmarks.map(item => (
        <BookmarksItem key={item.id} item={item} />
      ))}
    </div>
  );
};

export default BookmarksList;
