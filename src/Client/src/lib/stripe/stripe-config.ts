import {loadStripe} from '@stripe/stripe-js';

export const stripe = loadStripe(
  process.env.NEXT_PUBLIC_STRIPE_PUBLISHABLE_KEY,
);

export const stripeFonts = [
  {
    cssSrc:
      'https://fonts.googleapis.com/css2?family=Nunito+Sans:wght@800&display=swap',
  },
];
