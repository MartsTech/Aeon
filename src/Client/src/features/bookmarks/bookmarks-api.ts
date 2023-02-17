import {api} from '@lib/api';
import {RootState} from '@lib/store/store-types';
import {
  bookmarksAdded,
  bookmarksCreated,
  bookmarksLoaded,
  bookmarksRemoved,
} from './bookmarks-state';
import {BookmarkModel, WishlistModal} from './bookmarks-types';

export const bookmarksApi = api.injectEndpoints({
  endpoints: builder => ({
    getWishlists: builder.query<WishlistModal[], string | void>({
      queryFn: async (arg, baseApi, _extraOptions, baseQuery) => {
        const result = await baseQuery({
          url: `/bookmarks/GetWishlists/true`,
          method: 'GET',
          headers: {
            Authorization: `Bearer ${arg}`,
          },
        });

        if (result.meta?.response?.status === 200) {
          baseApi.dispatch(
            bookmarksLoaded((result.data || []) as WishlistModal[]),
          );
        }

        return {
          data: (result.data || []) as WishlistModal[],
        };
      },
    }),
    createWishlist: builder.mutation<WishlistModal, string | void>({
      queryFn: async (arg, baseApi, _extraOptions, baseQuery) => {
        const result = await baseQuery({
          url: `/bookmarks/CreateList`,
          method: 'POST',
          headers: {
            Authorization: `Bearer ${arg}`,
          },
        });

        if (result.meta?.response?.status === 200) {
          baseApi.dispatch(bookmarksCreated(result.data as WishlistModal));
        }

        return {
          data: result.data as WishlistModal,
        };
      },
    }),
    addBookmark: builder.mutation<BookmarkModel, string>({
      queryFn: async (arg, baseApi, _extraOptions, baseQuery) => {
        const state = baseApi.getState() as RootState;

        const formData = new FormData();

        formData.append('ProductId', arg);
        formData.append('ListId', state.bookmarks.list?.[0].id || '');
        formData.append('Quantity', '1');

        const result = await baseQuery({
          url: `/bookmarks/AddBookmark`,
          method: 'POST',
          body: formData,
        });

        if (result.meta?.response?.status === 200) {
          baseApi.dispatch(bookmarksAdded(result.data as BookmarkModel));
        }

        return {
          data: result.data as BookmarkModel,
        };
      },
    }),
    deleteBookmark: builder.mutation<null, string>({
      queryFn: async (arg, baseApi, _extraOptions, baseQuery) => {
        const result = await baseQuery({
          url: `/bookmarks/DeleteBookmark/${arg}`,
          method: 'DELETE',
        });

        if (result.meta?.response?.status === 200) {
          baseApi.dispatch(bookmarksRemoved(arg));
        }

        return {
          data: null,
        };
      },
    }),
  }),
});
