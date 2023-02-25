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
    jwt: ({token, account, profile}) => {
      if (account && profile) {
        return {
          ...token,
          accessToken: account.access_token,
          givenName: profile.given_name,
          familyName: profile.family_name,
          name: profile.name,
          country: profile.country,
          postalCode: profile.postalCode,
          state: profile.state,
          streetAddress: profile.streetAddress,
          city: profile.city,
        } as any;
      }
      return token;
    },
    session: ({session, token}) => {
      session.accessToken = token.accessToken;
      session.user.id = token.id;
      session.user.name = token.name;
      session.profile = {
        givenName: token.givenName,
        familyName: token.familyName,
        name: token.name,
        country: token.country,
        postalCode: token.postalCode,
        state: token.state,
        streetAddress: token.streetAddress,
        city: token.city,
      };
      return session;
    },
  },
};

export default NextAuth(authOptions);
