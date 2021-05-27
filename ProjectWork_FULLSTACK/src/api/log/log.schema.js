const mongoose = require("mongoose");

const LogSchema = mongoose.Schema({
    DATAATTUALE: Date,
    DATACONSEGNA: Date,
    CODICE: {type: String, required: true},
    ARTICOLO: String,
    PEZZI_PRODOTTI_PARZIALI_RELATIVI_COMMESSA: Number,
    PEZZI_BUONI: Number,
    PEZZI_SCARTI: Number,
    PEZZI_SCARTO_RIUTILIZZABILI: Number,
    AVVISO_PER_UFFICIO_DA_OPERATORE: String,
    TEMPO_DI_PRODUZIONE: Number,
    TEMPO_DI_PRODUZIONE_MOMENTANEO: Number,
    VELOCITA_MACCHINA_ATTUALE: Number,
    PEZZI_TOTALI: Number,
    STATOPROD: String,
    STATOMACCHINA: String,
    MANUALE: false
});

module.exports = mongoose.model("Log", LogSchema);
