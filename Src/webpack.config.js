var webpack = require('webpack');
var ExtractTextPlugin = require("extract-text-webpack-plugin");
var CopyWebpackPlugin = require('copy-webpack-plugin');
var CleanWebpackPlugin = require('clean-webpack-plugin');
var path = require('path');

var settings = {
    srcDir: './Features',
    rootDir: __dirname,
    outputDir:  path.join(__dirname,'/public')
};

module.exports = {
    entry: {
        'home-page': settings.srcDir + '/home/assets/home-page',
        'details-page': settings.srcDir + '/details/assets/details-page'
    },
    output: {
        path: settings.outputDir,
        filename: "[name].js",
        chunkFilename: "[id].js",
        publicPath: './public/'
    },
    module: {
        loaders: [
           // Extract css files
            {
                test: /\.css$/,
                loader: ExtractTextPlugin.extract("style-loader", "css-loader")
            },
            //{ test: /\.jpe?g$|\.gif$|\.png$|\.svg$|\.woff$|\.ttf$|\.wav$|\.mp3$/, loader: "file" },
            
            {
                test: /\.(png|jpe?g|gif|svg|woff|woff2|ttf|eot|ico)$/,
                loader: 'file?name=assets/[name].[chunkhash].[ext]'
            },
            {test: /\.svg/, loader: 'svg-url-loader'},
            { test: /\.png$/, loader: "url-loader?limit=100000" },
            // Optionally extract less files
            // or any other compile-to-css language
            { test: /\.(jpe?g|png|gif|svg)$/i, loaders: [ 'url?limit=10000', 'img?minimize' ] },
            {
                test: /\.scss$/,
                loader: ExtractTextPlugin.extract("style-loader", "css-loader!sass-loader")
            }
        ]
    },
    imagemin: {
    gifsicle: { interlaced: false },
    jpegtran: {
      progressive: true,
      arithmetic: false
    },
    optipng: { optimizationLevel: 5 },
    pngquant: {
      floyd: 0.5,
      speed: 2
    },
    svgo: {
      plugins: [
        { removeTitle: true },
        { convertPathData: false }
      ]
    }
  },
    plugins: [
        new ExtractTextPlugin("[name].css", {
            allChunks: true
        }),
        new CopyWebpackPlugin([
            { from: './Features/**/assets/**/*.svg', to: settings.rootDir + '/public', flatten: true }
        ]),
        new CleanWebpackPlugin(['public'], {
            verbose: true, 
            dry: false
        })
    ]
};