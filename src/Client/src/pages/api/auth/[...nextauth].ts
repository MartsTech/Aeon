import NextAuth, {AuthOptions} from 'next-auth';
import AzureADB2CProvider from 'next-auth/providers/azure-ad-b2c';

export const authOptions: AuthOptions = {
  providers: [
    AzureADB2CProvider({
      tenantId: process.env.AZURE_AD_B2C_TENANT_NAME,
      clientId: process.env.AZURE_AD_B2C_CLIENT_ID,
      clientSecret: process.env.AZURE_AD_B2C_CLIENT_SECRET,
      primaryUserFlow: process.env.AZURE_AD_B2C_PRIMARY_USER_FLOW,
      checks: ['pkce'],
      client: {
        token_endpoint_auth_method: 'none',
        client_secret: process.env.AZURE_AD_B2C_CLIENT_SECRET,
      },
      authorization: {
        params: {
          scope: `https://${process.env.AZURE_AD_B2C_TENANT_NAME}.onmicrosoft.com/${process.env.AZURE_AD_B2C_CLIENT_ID}/User.Scope offline_access openid`,
        },
      },
    }),
  ],
  callbacks: {
    jwt: ({token, account, user}) => {
      if (account && user) {
        return {
          ...token,
          accessToken: account.access_token,
        };
      }
      return token;
    },
    session: ({session, token}) => {
      session.accessToken = token.accessToken;
      session.user.id = token.id;
      return session;
    },
  },
};

export default NextAuth(authOptions);
