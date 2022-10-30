/** @type {import('tailwindcss').Config} */

const defaultTheme = require("tailwindcss/defaultTheme");
module.exports = {
	content: ["./src/**/*.{html,ts}"],
	theme: {
		important: true,
		extend: {
			fontSize: {
				vw: "1vw",
				vw2: "2vw",
				vw22: "2.2vw",
				appTitle: "40px",
			},
			fontFamily: {
				OpenSan: "Open Sans', sans-serif",
				Roboto: "'Roboto Slab', serif",
			},
			letterSpacing: {
				max: "0.4em",
				medium: "0.7em",
			},
			borderRadius: {
				default: "4px",
				full: "50%",
			},
			colors: {
				primary: "#EC994B",
				highLight: "#FD841F",
				dark: "#343A40",
				"gray-cus": "#CFD2CF",
			},
			backgroundColor: {
				main: "#1e1f26",
				highLight: "#FD841F",
				gray: "#CFD2CF",
				dark:"#1B1F23",
			},
			zIndex: {
				1: 1,
				2: 2,
			},
		},
		screens: {
			mobileTiny:{
				max: "280px",
			},
			mobile: {
				min: "280px",
				max: "640px",
			},
			tablet: "640px",
			tabletLg: "768px",
			laptop: "1024px",
			desktop: "1280px",
			...defaultTheme.screens,
		},
	},
	plugins: [],
};


// #FF4A4A
