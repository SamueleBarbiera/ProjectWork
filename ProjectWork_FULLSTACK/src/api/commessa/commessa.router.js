const express = require('express');
const router = express.Router();
const commessaController = require('./commessa.controller');
//definizione dele api relative ai todo

router.get('/:codice',commessaController.checkCodice, commessaController.getLastState);

router.get('/', commessaController.list);

//mi ritona i log di una commessa specifica per il grafico
router.get('/:codice/dati', commessaController.checkCodice, commessaController.getDatiGraficoComm);

router.get('/:codice/logs',commessaController.checkCodice, commessaController.getLogs);

router.get('/:codice/details', commessaController.checkCodice, commessaController.getOneLastState);

module.exports = router;