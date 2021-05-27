$(document).ready(() => {
    const urlParams = new URLSearchParams(window.location.search);
    const getcommessa = {};
    getcommessa.commessa = urlParams.get("code");
    getcommessa.stato = urlParams.get("stato");
    getcommessa.from = urlParams.get("from");
    getcommessa.to = urlParams.get("to");

    const table = $("#myTable").DataTable({
        columns: [
            {
                data: "CODICE",
                defaultContent: "",
            },
            {
                data: "ARTICOLO",
                defaultContent: "",
            },
            {
                data: "DATAATTUALE",
                defaultContent: "",
                render: (data, type, row) => {
                    return moment(data).format("DD/MM/YY HH:MM:SS");
                },
            },
            {
                data: "DATACONSEGNA",
                defaultContent: "",
                render: (data, type, row) => {
                    return moment(data).format("DD/MM/YY HH:MM:SS");
                },
            },
            {
                data: "PEZZI_PRODOTTI_PARZIALI_RELATIVI_COMMESSA",
                defaultContent: "",
            },
            {
                data: "PEZZI_BUONI",
                defaultContent: "",
            },
            {
                data: "PEZZI_SCARTI",
                defaultContent: "",
            },
            {
                data: "PEZZI_SCARTO_RIUTILIZZABILI",
                defaultContent: "",
            },
            {
                data: "TEMPO_DI_PRODUZIONE",
                defaultContent: "",
            },
            {
                data: "TEMPO_DI_PRODUZIONE_MOMENTANEO",
                defaultContent: "",
            },
            {
                data: "STATOPROD",
                defaultContent: "",
            },
        ],
    });
    queryGET(getcommessa);
});

const queryGET = (query) => {
    let q = "";
    if (query.commessa) {
        q += "commessa=" + query.commessa;
    }
    if (query.stato) {
        q += "&stato=" + query.stato;
    }
    if (query.from) {
        q += "&from=" + query.from;
    }
    if (query.to) {
        q += "&to=" + query.to;
    }
    richiestaAPIGETLOGS(q);
};

const richiestaAPIGETLOGS = (query) => {
    let latestData = [];
    function statusPolling() {
        $.ajax({
            type: "GET",
            url: `http://50.19.147.177:3000/api/logs/?${query}`,
        })
            .then((result) => {
                //result.forEach((log) => stampaTabella(log));
                const newData = _.differenceBy(result, latestData, "_id");
                newData.forEach((log) => stampaTabella(log));
                latestData = result;
                setTimeout(function(){$(".loader-wrapper").fadeOut("slow");},1000);
            })
            .catch((err) => {
                location.href = "errore.html";
            });
    }
    setInterval(statusPolling, 1000);
};

const stampaTabella = (result) => {
    /*const template = $(`
        <tr style="font-size: 18px;">
            <td style="font-size: 18px;">${result.CODICE}</td>
            <td style="font-size: 18px;">${result.ARTICOLO}</td>
            <td style="font-size: 18px;">${moment(result.DATAATTUALE).format("DD/MM/YY HH:MM:SS")}</td>
            <td style="font-size: 18px;">${result.PEZZI_PRODOTTI_PARZIALI_RELATIVI_COMMESSA}</td>
            <td style="font-size: 18px;">${result.PEZZI_BUONI}</td>
            <td style="font-size: 18px;">${result.PEZZI_SCARTI}</td>
            <td style="font-size: 18px;">${result.PEZZI_SCARTO_RIUTILIZZABILI}</td>
            <td style="font-size: 18px;">${result.TEMPO_DI_PRODUZIONE}</td>
            <td style="font-size: 18px;">${result.TEMPO_DI_PRODUZIONE_MOMENTANEO}</td>
            <td style="font-size: 18px;">${result.VELOCITA_MACCHINA_ATTUALE}</td>
            <td style="font-size: 18px;">${result.STATOPROD}</td>
            <td style="font-size: 18px;">${moment(result.DATACONSEGNA).format('DD/MM/YY HH:MM:SS')}</td>
            <td style="font-size: 18px;">${result.STATOMACCHINA}</td>
            <td style="font-size: 18px;">${result.MANUALE}</td>
        </tr>
    `);*/

    let table = $("#myTable").DataTable();
    table.row.add(result).draw(false);
};
