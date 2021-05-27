const logModel = require('../log/log.model');
const moment = require('moment');

//CONTROLLARE
module.exports.getStatus = async(req, res, next) => {
    try {
        const query = {};
        const logs = await logModel.find(query);
        if (logs.length) {
            res.json(logs[0]);
        } else {
            res.json({
                STATOPROD: 'idle'
            });
        }
    }catch(err) {
        next(err);
    }
}