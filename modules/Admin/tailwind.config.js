/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}"
  ],
  theme: {
    extend: {
      colors:{
        transparent:'transparent',
        current: 'currentColor',
      },
      backgroundColor:{
        'blue':{
          'woodDark':'#303956'
        }
      }
    },
  },
  plugins: [],
}
