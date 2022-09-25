/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}",
  ],
  theme: {
    extend: {
      fontSize:{
        vw:"1vw",
        vw2: "2vw",
        vw22: "2.2vw",
        appTitle: "40px"
      },
      fontFamily:{
        OpenSan: "Open Sans', sans-serif",
        Roboto: "'Roboto Slab', serif"
      },
      letterSpacing:{
        max: "0.4em",
        medium: "0.7em"
      },
      borderRadius:{
        default: "4px",
        full: "50%"
      },
      colors:{
        primary: "#FFB562"
      },
      backgroundColor:{
        main: "#1e1f26"
      }

    },
  },
  plugins: [],
}
