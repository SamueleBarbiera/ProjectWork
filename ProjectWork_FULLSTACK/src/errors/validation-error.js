module.exports = (err, req, res, next) => {
    if (err.name === 'ValidationError') {
        console.log(err);
        res.status(400);
        res.send(err.message);
    } else {
        next(err);
    }
}