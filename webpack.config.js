// Note this only includes basic configuration for development mode.
// For a more comprehensive configuration check:
// https://github.com/fable-compiler/webpack-config-template

const path = require("path")
const webpack = require("webpack");

module.exports = (env, argv) => {
    const mode = argv.mode

    return {
        mode: mode,
        entry: './out/Program.js',
        output: {
            path: path.join(__dirname, "dist"),
            filename: "main.js",
        },
        devServer: {
            contentBase: path.join(__dirname, "dist"),
            port: 3000,
            hot: true,
            inline: true,
            // NB: required so that webpack will go to index.html on not found
            historyApiFallback: true
        },
        // NB: so webpack works with docker
        watchOptions: {
            poll: true
        },
        plugins: mode === 'development' ? [new webpack.HotModuleReplacementPlugin()] : []
    }
} 
