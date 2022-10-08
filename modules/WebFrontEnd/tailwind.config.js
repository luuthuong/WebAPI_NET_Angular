/** @type {import('tailwindcss').Config} */

const defaultTheme = require('tailwindcss/defaultTheme')
module.exports = {
	content: ["./src/**/*.{html,ts}"],
	theme: {
		extend: {
			fontSize: {
				'vw': "1vw",
				'vw2': "2vw",
				'vw22': "2.2vw",
				'appTitle': "40px",
			},
			fontFamily: {
				'OpenSan': "Open Sans', sans-serif",
				'Roboto': "'Roboto Slab', serif",
			},
			letterSpacing: {
				'max': "0.4em",
				'medium': "0.7em",
			},
			borderRadius: {
				'default': "4px",
				'full': "50%",
			},
			colors: {
				'primary': "#EC994B",
				'highLight': "#FF4A4A",
				'dark': "#343A40",
			},
			backgroundColor: {
				'main': "#1e1f26",
				'highLight': "#FF4A4A",
				'gray': "#CFD2CF",
			},
			zIndex: {
				'1': 1,
				'2': 2,
			},
		},
		screens: {
			'mobile': {
				'min':"270px",
				'max':'640px'
			},
			'tablet': "640px",
			'tabletLg': '768px',
			'laptop': "1024px",
			'desktop': "1280px",
			...defaultTheme.screens,
		},
	},
	plugins: [],
};
