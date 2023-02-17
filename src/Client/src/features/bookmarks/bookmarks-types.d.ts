export interface WishlistModal {
  id: string;
  userId: string;
  dateCreated: string;
  bookmarks: BookmarkModel[];
}

export interface BookmarkModel {
  id: string;
  productId: string;
  productQuantity: number;
  dateAdded: string;
  listId: string;
  userId: string;
}

export interface BookmarkAddArgs {
  productId: string;
}
