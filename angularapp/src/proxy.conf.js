const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
    ],
    target: "https://localhost:7215",
    //target: "https://localhost:5000",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
