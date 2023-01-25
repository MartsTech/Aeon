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
      screens: {
        '1xl': '1440px',
      },
    },
  },
  plugins: [],
};
