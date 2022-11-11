/** @type {import('tailwindcss').Config} */
module.exports = {
    content: ['./**/*.{razor,html}'],
    daisyui: {
        themes: [
            {
                mainDarkTheme: {

                    "primary": "#f7f2de",

                    "secondary": "#716C64",

                    "accent": "#F8E794",

                    "neutral": "#363330",

                    "base-100": "#141414",

                    "info": "#345C9B",

                    "success": "#337B46",

                    "warning": "#D6853E",

                    "error": "#A21F1F",
                },
            }]
    },
    theme: {
        extend: {},
    },
    plugins: [require("daisyui")],
}
