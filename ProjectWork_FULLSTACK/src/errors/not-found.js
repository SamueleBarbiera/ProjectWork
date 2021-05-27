module.exports = (err, req, res, next) => {
    if (err.message === 'Not Found') {
        res.status(404);
        res.send('Not Found');
    } else {
        next(err);
    }
}