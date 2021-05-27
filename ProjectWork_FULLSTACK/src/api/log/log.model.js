const Log = require("./log.schema");
const moment = require("moment");

//Crea il log tramite POST
module.exports.create = async (data) => {
    return Log.create(data);
};

//Query di ricerca con più parametri
module.exports.find = async (query) => {
    const q = {};
    if (query.commessa) {
        q.CODICE = query.commessa;
    }
    if (query.stato) {
        q.STATOPROD = {$regex: new RegExp(query.stato, "i")};
    }
    if (query.from || query.to) {
        q.DATAATTUALE = {};
    }
    if (query.from) {
        q.DATAATTUALE.$gte = query.from;
    }
    if (query.to) {
        q.DATAATTUALE.$lte = query.to;
    }
    return Log.find(q).sort({DATAATTUALE:-1 ,CODICE: -1});
};

//Restituisce tutte le commesse terminate o in errore ordinate per data
module.exports.findLast = async () => {
    const query = {};
    query.STATOPROD = {$nin: ["Attiva"]};
    return Log.find(query).sort({STATOPROD: -1, DATAATTUALE: -1});
};

//Restituisce l'ultimo log trmite codice commessa seolo se questo è in errore o concluso
module.exports.findLastByCommessa = async (codice) => {
    const query = {};
    query.STATOPROD = {$nin: ["Attiva"]};
    query.CODICE = codice;
    return Log.findOne(query).sort({STATOPROD: -1, DATAATTUALE: -1});
};

module.exports.lastLog = async (from, to) => {
    const q = {
        STATOPROD: "Attiva",
        DATAATTUALE: {
            $gte: from,
            $lte: to,
        },
    };
    return Log.findOne(q).sort({DATAATTUALE: -1});
};

//Mi restitisce l'ultimo log presente a database
module.exports.getCommessa = async (codice) => {
    return Log.findOne({CODICE: codice}).sort({DATAATTUALE: -1});
};

module.exports.getCodiciCommessa = async () => {
    return Log.find().distinct("CODICE");
};

//prepara e restituisce i dati per il grafico
module.exports.getCommessaGrafico = async (codice) => {
    let Tuttidaticommessa = await Log.find({CODICE: codice}).sort({
        DATAATTUALE: 1,
    });
    const datografico = {};
    const listaPezzi = [];
    const listaDate = [];
    Tuttidaticommessa.forEach((element) => {
        listaDate.push(moment(element.DATAATTUALE).format("LT"));
        listaPezzi.push(element.PEZZI_BUONI);
    });
    datografico.dateTime = listaDate;
    datografico.PezziProdotti = listaPezzi;
    return datografico;
};

//controlla se il codice commessa esiste
module.exports.existsByCode = async (codice) => {
    const record = await Log.findOne({CODICE: codice});
    return !!record;
};
