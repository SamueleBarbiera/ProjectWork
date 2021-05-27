const express = require('express');
const router = express.Router();
const statusController = require('./status.controller');

//mi ritorna l'ultimo log
router.get('/', statusController.getStatus);

module.exports = router;