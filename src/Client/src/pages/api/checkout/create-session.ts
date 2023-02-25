import type {CheckoutProduct} from '@features/checkout/checkout-types';
import type {NextApiRequest, NextApiResponse} from 'next';
import {getSession} from 'next-auth/react';
import {Stripe} from 'stripe';

interface ExtendedNextApiRequest extends NextApiRequest {
  body: {
    items: CheckoutProduct[];
  };
}

type Data =
  | {
      sessionId: string;
    }
  | {
      error: string;
    };

const stripe: Stripe = require('stripe')(process.env.STRIPE_SECRET_KEY);

const handler = async (
  req: ExtendedNextApiRequest,
  res: NextApiResponse<Data>,
) => {
  const session = await getSession({req});

  if (!session) {
    res.status(401).json({error: 'Unauthorized'});
    return;
  }

  const {items} = req.body;

  if (!items || items.length === 0) {
    res.status(400).json({error: 'No items in cart'});
    return;
  }

  const response = await stripe.checkout.sessions.create({
    payment_method_types: ['card'],
    shipping_options: [
      {
        shipping_rate: process.env.STRIPE_SHIPPING_RATE,
      },
    ],
    payment_intent_data: {
      shipping: {
        address: {
          country: session.profile.country,
          postal_code: session.profile.postalCode,
          state: session.profile.state,
          line1: session.profile.streetAddress,
        },
        name: session.profile.name,
      },
    },
    line_items: items.map(item => ({
      ...item,
      tax_rates: [process.env.STRIPE_TAX_RATE],
    })),
    mode: 'payment',
    success_url: `${process.env.NEXTAUTH_URL}/checkout`,
    cancel_url: `${process.env.NEXTAUTH_URL}`,
    customer_email: session.user.email,
    metadata: {
      email: session.user.email,
    },
  });

  res.status(200).json({sessionId: response.id});
};

export default handler;
