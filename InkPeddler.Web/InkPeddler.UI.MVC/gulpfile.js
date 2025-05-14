const { src, dest, watch, series, parallel } = require('gulp');
const sourcemaps = require('gulp-sourcemaps');
const sass = require('gulp-sass');
const concat = require('gulp-concat');
const uglify = require('gulp-uglify');
var replace = require('gulp-replace');
const fileinclude = require('gulp-file-include');
const strip = require('gulp-strip-comments');

const files = {
    scssLandingPath: 'Content/landing/scss/*.scss',
    jsPath: 'Content/landing/js/**/*.js',
    imagePath: 'Content/landing/images/**',
    viewModelsPath: 'ViewModels/*.js',
    nodeModulesPath: 'node_modules/**/*.js'
}

//function viewModelsTask() {
//    return src([files.viewModelsPath])
//        .pipe(concat('viewModels.js'))
//        //.pipe(uglify())
//        .pipe(dest('wwwroot/dist'));
//}


function scssTask() {
    return src(files.scssLandingPath)
        .pipe(sass())
        .pipe(dest('wwwroot/dist/landing/css'));
}

function jsTask() {
    return src(files.jsPath)
        .pipe(fileinclude({
            prefix: '@@',
            basepath: '@file',
            context: { build: 'dist', nodeRoot: '../../..' }
        }))
        .pipe(strip())
        .pipe(concat('main.js')).pipe(uglify()).pipe(dest('wwwroot/dist/landing/js'));
}

function imageTask() {
    return src(files.imagePath).pipe(dest('wwwroot/dist/landing/images'));

}

function cacheBustTask() {
    var cbString = new Date().getTime();
    return src(['index.html'])
        .pipe(replace(/cb=\d+/g, 'cb=' + cbString))
        .pipe(dest('.'));
}

//function watchTask() {
//    watch([files.viewModelsPath], { interval: 1000, usePolling: true },
//        series(
//            parallel(viewModelsTask),
//            cacheBustTask
//        )
//    )
//};

// Export the default Gulp task so it can be run
// Runs the scss and js tasks simultaneously
// then runs cacheBust, then watch task
exports.default = series(
    parallel(scssTask, jsTask, imageTask)
    //parallel(viewModelsTask),
    //cacheBustTask,
    //watchTask
);