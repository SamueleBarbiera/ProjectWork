const express = require("express");
const router = express.Router();
const logController = require("./log.controller");

//Usata per creare i log
router.post("/", logController.create);

//Usato per filtrare i log
router.get("/", logController.find);

//Usato
router.get("/last", logController.findLast);

module.exports = router;
