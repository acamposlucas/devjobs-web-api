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
            700: "#5964E0",
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
      },
      backgroundImage: {
        'bg-header-mobile': "url('../src/assets/mobile/bg-pattern-header.svg')",
        'bg-header-tablet': "url('../src/assets/tablet/bg-pattern-header.svg')",
        'bg-header-desktop': "url('../src/assets/desktop/bg-pattern-header.svg')"
      }
    },
    gridTemplateColumns: {
      'fit-sm': 'repeat(auto-fit, minmax(328px, 1fr))',
    }
  },
  plugins: [],
}
