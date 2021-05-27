const logModel = require("./log.model");

module.exports.create = async (req, res, next) => {
    try {
        let body = req.body;
        let Stato = "";
        let StatoMacchina = "Macchina in STOP";
        let manu;
        
        /*
        if(body.STATOPROD == "" ){
            StatoMacchina = "Macchina in STOP";
            manu = false;
        }
        if(body.STATOPROD == "Conclusa"){
            StatoMacchina = "Macchina in STOP";
            manu = false;
        }
        if(body.STATOPROD == "Attiva" && (body.MANUALE==false)){
            StatoMacchina = "Macchina in START";
            manu = false;
        }
        if (body.STATOPROD == "Attiva" && (body.MANUALE==true)){
            StatoMacchina = "Macchina in manuale";
            manu = true;
        }*/
        

        //DO PER SCONTATO CHE LA COMMESSA è IN ERRORE SE L'OPERATORE ESEGUE UN AVVISO
        if (body.AVVISO_PER_UFFICIO_DA_OPERATORE == "" && body.PEZZI_TOTALI > body.PEZZI_BUONI + body.PEZZI_SCARTO_RIUTILIZZABILI) {
            Stato = "Attiva";
        } else {
            Stato = "Errore";
        }

        body.STATOPROD = Stato;
        body.STATOMACCHINA = StatoMacchina;
        body.MANUALE = manu;

        const created = await logModel.create(body);
        res.status(201);
        // non occore solo precauzione (controllo inserimento corretto)
        res.json(created);
        
    } catch (err) {
        next(err);
    }
};

module.exports.find = async (req, res, next) => {
    try {
        const list = await logModel.find(req.query);
        res.json(list);
    } catch (err) {
        next(err);
    }
};

module.exports.findLast = async (req, res, next) => {
    try {
        const list = await logModel.findLast();
        res.json(list);
    } catch (err) {
        next(err);
    }
};
