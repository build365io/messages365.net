/** @type {import('next').NextConfig} */
const nextConfig = {
    images: {
        remotePatterns: [
            {
                protocol: 'https',
                hostname: 'unsplash.com',
                pathname: '**',
            },
            {
                protocol: 'https',
                hostname: 'images.unsplash.com',
                pathname: '**',
            },
            {
                protocol: 'https',
                hostname: 'plus.unsplash.com',
                pathname: '**',
            },
            {
                protocol: 'https',
                hostname: 'img.freepik.com',
                pathname: '**',
            },
            {
                protocol: 'http',
                hostname: "localhost",
                pathname: '**',
            }
        ],
    }
}

module.exports = nextConfig






