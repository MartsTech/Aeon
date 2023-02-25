import type {NextApiRequest, NextApiResponse} from 'next';
import {getSession} from 'next-auth/react';
import {Stripe} from 'stripe';

interface ExtendedNextApiRequest extends NextApiRequest {
  body: {
    total: number;
  };
}

type Data =
  | {
      clientSecret: string;
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

  const {total} = req.body;

  if (!total || total === 0) {
    res.status(400).json({error: 'No items in cart'});
  }

  const response = await stripe.paymentIntents.create({
    amount: total,
    currency: 'USD',
    description: `Aeon Order for ${total.toFixed(2)} USD`,
  });

  if (!response.client_secret) {
    res.status(500).json({error: 'Failed to create payment intent'});
    return;
  }

  res.status(200).json({clientSecret: response.client_secret});
};

export default handler;
