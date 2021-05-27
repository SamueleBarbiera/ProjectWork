const notFound = require('./not-found');
const internal = require('./internal');
const validation = require('./validation-error');

module.exports = [notFound, validation, internal];