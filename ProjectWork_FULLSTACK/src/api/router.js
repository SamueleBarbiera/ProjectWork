const express = require('express');
const router = express.Router();
const logsRouter = require('./log/log.router');
const commessaRouter = require('./commessa/commessa.router');
const statusRouter = require('./status/status.router');

//definizione delle route
router.use('/logs', logsRouter);
router.use('/status', statusRouter);
router.use('/commesse', commessaRouter);

module.exports = router;