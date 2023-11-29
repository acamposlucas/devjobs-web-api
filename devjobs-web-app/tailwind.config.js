/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}",
  ],
  theme: {
    extend: {
      colors: {
        primary: {
          violet: {
            700: "#9e7f66",
            400: "#939BF4"
          },
          blue: {
            900: "#19202D",
            800: "#121721"
          }
        },
        secondary: {
          grey: {
            700: "#6E8098",
            400: "#9DAEC2",
            200: "#F4F6F8"
          },
        }
      },
      fontFamily: {
        sans: ["Kumbh Sans"]
      }
    },
  },
  plugins: [],
}
