import {Elements} from '@stripe/react-stripe-js';
import {stripe} from './stripe-config';

interface Props {
  children: React.ReactNode;
}

const StripeProvider: React.FC<Props> = ({children}) => {
  return (
    <Elements
      options={{
        fonts: [
          {
            cssSrc:
              'https://fonts.googleapis.com/css2?family=Nunito+Sans:wght@800&display=swap',
          },
        ],
      }}
      stripe={stripe}>
      {children}
    </Elements>
  );
};

export default StripeProvider;
