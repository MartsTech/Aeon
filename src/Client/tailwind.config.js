const defaultTheme = require('tailwindcss/defaultTheme');

/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['./src/**/*.{js,ts,jsx,tsx}'],
  theme: {
    extend: {
      colors: {
        background: '#fafafa',
        text: '#1a1a2c',
        primary: '#f90',
        secondary: '#1a1a2c',
        accent: '##eaeaea',
      },
      width: {
        almost: 'calc(100% - 4rem)',
      },
      fontFamily: {
        body: ['Nunito Sans', 'sans-serif'],
      },
    },
    screens: {
      xs: '550px',
      semi: '880px',
      '1xl': '1440px',
      ...defaultTheme.screens,
    },
  },
  plugins: [
    require('tailwind-scrollbar-hide'),
    require('@tailwindcss/line-clamp'),
  ],
};
