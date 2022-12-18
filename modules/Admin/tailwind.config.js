/** @type {import('tailwindcss').Config} */
module.exports = {
	content: ["./src/**/*.{html,ts}"],
	theme: {
		extend: {
      textColor:{
        baseColor:"#2C3639",
        lightColor:"#FEFBF6"
      },
			colors: {
				transparent: "transparent",
				current: "currentColor",
        hoverColor: "#E4DCCF",
        white:"#FCF8E8"
			},
			backgroundColor: {
				blue: {
					woodDark: "#383838",
				},
        card:{
          light:"#EFEAD8"
        }
			},
			gridTemplateColumns: {
				autoColumnCustom: "repeat(auto-fill, minmax(275px, 1fr))",
			},
      boxShadow:{
        baseShadow: "0px 3px 3px rgba(0, 0, 0, 0.30) "
      }
		},
	},
	plugins: [],
};