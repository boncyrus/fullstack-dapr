/** @type {import('next').NextConfig} */
const nextConfig = {
    reactStrictMode: true,
    output: 'standalone',
    swcMinify: true,
    // except for webpack, other parts are left as generated
    webpack: (config, context) => {
        config.watchOptions = {
            poll: 1000,
            aggregateTimeout: 300,
        };
        return config;
    },
    env: {
        BOOKINGS_API_HOST: 'http://127.0.0.1:8070',
        CATALOG_API_HOST: 'http://127.0.0.1:8080',
    },
};

module.exports = nextConfig;
