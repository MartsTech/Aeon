import {api} from '@lib/api';
import {categoriesLoaded} from './categories-state';
import type {CategoriesListModal} from './categories-types';

export const categoriesApi = api.injectEndpoints({
  endpoints: builder => ({
    getCategoriesList: builder.query<CategoriesListModal[], void>({
      query: () => ({
        url: `/catalog/GetCategories/true`,
        method: 'GET',
      }),
      async onQueryStarted(_arg, {queryFulfilled, dispatch}) {
        const result = await queryFulfilled;

        if (result.meta?.response?.status === 200) {
          dispatch(categoriesLoaded({list: result.data}));
        }
      },
    }),
  }),
});
