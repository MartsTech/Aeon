declare namespace NodeJS {
  interface ProcessEnv {
    NEXT_PUBLIC_API_URL: string;
    NEXT_PUBLIC_STRIPE_PUBLISHABLE_KEY: string;
    STRIPE_TAX_RATE: string;
    STRIPE_SHIPPING_RATE: string;
    STRIPE_SECRET_KEY: string;
    NEXTAUTH_URL: string;
    NEXTAUTH_SECRET: string;
    AZURE_AD_B2C_TENANT_NAME: string;
    AZURE_AD_B2C_CLIENT_ID: string;
    AZURE_AD_B2C_CLIENT_SECRET: string;
    AZURE_AD_B2C_PRIMARY_USER_FLOW: string;
  }
}
