const logModel = require('../log/log.model');

//mi ristorna l'ultimo log a database
module.exports.getLastState = async(req, res, next) => {
    try {
        const lastLog = await logModel.getCommessa(req.params.codice);
        res.json(lastLog);
    }catch(err) {
        next(err);
    }
};

//Restituisce l'ultimo log tramite codice commessa solo se questo è in errore o concluso
module.exports.getOneLastState = async(req, res, next) => {
    try {
        const lastLog = await logModel.findLastByCommessa(req.params.codice);
        res.json(lastLog);
    }catch(err) {
        next(err);
    }
};

module.exports.list = async(req, res, next) => {
    try {
        const codici = await logModel.getCodiciCommessa();
        const logPromises = codici.map(codice => {
            return logModel.getCommessa(codice)
                .then(log => {
                    let Stato='Conclusa'

                    //DO PER SCONTATO CHE LA COMMESSA è IN ERRORE SE L'OPERATORE ESEGUE UN AVVISO
                    if(log.AVVISO_PER_UFFICIO_DA_OPERATORE=="")
                    {
                        if(log.PEZZI_TOTALI!=log.PEZZI_BUONI)
                        {
                            Stato='Attiva'                   
                        }
                    }
                    else{
                        Stato='Errore'
                    }
                    return {
                        DATAATTUALE: log.DATAATTUALE,
                        CODICE: log.CODICE,
                        ARTICOLO: log.ARTICOLO,
                        PEZZI_PRODOTTI_PARZIALI_RELATIVI_COMMESSA: log.PEZZI_BUONI+ log.PEZZI_SCARTI+log.PEZZI_SCARTO_RIUTILIZZABILI,
                        PEZZI_BUONI: log.PEZZI_BUONI,
                        PEZZI_SCARTI: log.PEZZI_SCARTI,
                        PEZZI_SCARTO_RIUTILIZZABILI: log.PEZZI_SCARTO_RIUTILIZZABILI,
                        AVVISO_PER_UFFICIO_DA_OPERATORE: log.AVVISO_PER_UFFICIO_DA_OPERATORE,
                        TEMPO_DI_PRODUZIONE: log.TEMPO_DI_PRODUZIONE,
                        TEMPO_DI_PRODUZIONE_MOMENTANEO: log.TEMPO_DI_PRODUZIONE_MOMENTANEO,
                        VELOCITA_MACCHINA_ATTUALE: log.VELOCITA_MACCHINA_ATTUALE,
                        PEZZI_TOTALI: log.PEZZI_TOTALI,
                        STATO:Stato
                    };
                });
        });

        const logs = await Promise.all(logPromises);
 
        res.json(logs);
    }catch(err) {
        next(err);
    }
};

//Restitisce tutti i log dato un codice
module.exports.getLogs = async(req, res, next) => {
    try {
        const logs = await logModel.find({commessa: req.params.codice});
        res.json(logs);
    } catch(err) {
        next(err);
    }
};

//Controlla se il codice della commessa esiste altrimneti da errore
module.exports.checkCodice = async(req, res, next) => {
    try {
        const exists = await logModel.existsByCode(req.params.codice);
        
        if (!exists) {
            throw new Error('Not Found');
        }
        next();
    } catch(err) {
        next(err);
    }
};

//si occupa di rexcuperare i dati del grafico
module.exports.getDatiGraficoComm = async(req, res, next) => {
    try {
        const lastLog = await logModel.getCommessaGrafico(req.params.codice);
        res.json(lastLog);
    }catch(err) {
        next(err);
    }
};