const host = "http://50.19.147.177:3000/api";
$(document).ready(() => {
    richiestaAPIGET();
});

const richiestaAPIGET = () => {
    setInterval(statusPolling, 1000);
    function statusPolling() {
        $.ajax({
            type: "GET",
            url: host + `/status`,
        })
            .then((result) => {
                console.log(result);
                $("#status").empty();
                $("#stampaLog").empty();
                $("#stampaTitolo").empty();
                $("#articolo").empty();
                $("#stampaAvviso").empty();
                $("#stampaProd").empty();
                controlloStatus(result);
                setTimeout(function(){$(".loader-wrapper").fadeOut("slow");},1000);
            })
            .catch((err) => {
                location.href = "errore.html";
            });
    }
};

const richiestaAPIGETGrafico = (codice) => {
    $.ajax({
        type: "GET",
        url: host + `/commesse/${codice}/dati`,
    })
        .then((result) => {
            stampaGrafico(result);
        })
        .catch((err) => {
            location.href = "errore.html";
        });
};

const controlloStatus = (result) => {
    stampaArticolo(result);
    stampaTitolo(result);
    stampaTabella(result);
    stampaAvviso(result.STATOPROD);
    richiestaAPIGETGrafico(result.CODICE);
    

    if (result.STATOMACCHINA == "Macchina in START") {
        status(true);
    }else
    if (result.STATOMACCHINA == "Macchina in STOP") {
        status(false);
    }else
    if (result.STATOMACCHINA == "Macchina in manuale") {
        status(true);
    }else
    if (result.STATOPROD == "Macchina in emergenza") {
        status(false);
    }else
    if (result.STATOMACCHINA == "Allarmi in atto") {
        status(false);
    }else
    if (result.STATOMACCHINA == "Macchina in manutenzione") {
        status(false);
    }else
    if (result.STATOMACCHINA == "Macchina preinpostata per lo start automatico") {
        status(true);
    }else{
        status(true);
    }
};

const status = (type) => {
    const information = {img: String, text: String};
    if (type) {
        information.text = "Macchina in funzione";
        information.img = "/Immagini/OK.png";
    } else {
        information.text = "Macchina ferma";
        information.img = "/Immagini/STOP.png";
    }
    const card = $(`
        <img src="${information.img}" class="mx-auto d-block img-fluid unlock-icon" alt="...">
        <div class="h3 text-center">${information.text}</div>
    `);
    $("#status").prepend(card);
};

const stampaArticolo = (result) => {
    let immagine = "default";
    const listaArticoli = ["AziendaA", "AziendaB", "AziendaC"];
    listaArticoli.forEach((articolo) => {
        if (result.ARTICOLO == articolo) {
            immagine = result.ARTICOLO;
        }
    });
    const template = $(`
        <img src="/Immagini/${immagine}.png" class="mx-auto d-block img-fluid unlock-icon" alt="...">
        <div class="h3 text-center">${result.ARTICOLO}</div>
    `);

    $("#articolo").prepend(template);
};

const stampaTitolo = (result) => {
    const template = $(`
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css" integrity="sha384-B0vP5xmATw1+K9KRQjQERJvTumQW0nPEzvF6L/Z6nronJ3oUOFUFpCjEUQouq2+l" crossorigin="anonymous">
        <div class="jumbotron border rounded bg-light">
            <div class="row d-flex justify-content-center">
                <form class="justify-content-center">
                <a style="font-family:Helvetica Neue; color: white; text-decoration:none" href="storico.html?code=${result.CODICE}" class="link">
                    <span class="mask">
                        <div class="link-container">
                        <span class="link-title1 title">${result.CODICE}</span>
                        <span class="link-title2 title">CODICE</span>
                        </div>
                    </span>
                    <div class="link-icon">
                        <svg class="icon" width="24" height="24" xmlns="http://www.w3.org/2000/svg" fill-rule="evenodd" clip-rule="evenodd">
                        <path d="M21.883 12l-7.527 6.235.644.765 9-7.521-9-7.479-.645.764 7.529 6.236h-21.884v1h21.883z" />
                        </svg>
                        <svg class="icon" width="24" height="24" xmlns="http://www.w3.org/2000/svg" fill-rule="evenodd" clip-rule="evenodd">
                        <path d="M21.883 12l-7.527 6.235.644.765 9-7.521-9-7.479-.645.764 7.529 6.236h-21.884v1h21.883z" />
                        </svg>
                    </div>
                    </a>
                </form>
            </div>
        </div>
        <div class="jumbotron border rounded bg-light">
            <div class="row d-flex justify-content-center">
                <form class="justify-content-center">
                    <a style="font-family:Helvetica Neue; color: white; text-decoration:none" href="dettagli.html?code=${result.CODICE}" class="link">
                    <span class="mask">
                        <div class="link-container">
                        <span class="link-title1 title">${result.STATOPROD}</span>
                        <span class="link-title2 title">STATUS</span>
                        </div>
                    </span>
                    <div class="link-icon">
                        <svg class="icon" width="24" height="24" xmlns="http://www.w3.org/2000/svg" fill-rule="evenodd" clip-rule="evenodd">
                        <path d="M21.883 12l-7.527 6.235.644.765 9-7.521-9-7.479-.645.764 7.529 6.236h-21.884v1h21.883z" />
                        </svg>
                        <svg class="icon" width="24" height="24" xmlns="http://www.w3.org/2000/svg" fill-rule="evenodd" clip-rule="evenodd">
                        <path d="M21.883 12l-7.527 6.235.644.765 9-7.521-9-7.479-.645.764 7.529 6.236h-21.884v1h21.883z" />
                        </svg>
                    </div>
                    </a>
                </form>
            </div>
        </div>
  `);
    $("#stampaTitolo").prepend(template);
};

const stampaTabella = (result) => {
    const template = $(`
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css" integrity="sha384-B0vP5xmATw1+K9KRQjQERJvTumQW0nPEzvF6L/Z6nronJ3oUOFUFpCjEUQouq2+l" crossorigin="anonymous">
    <table class="table table-striped" style="box-shadow: 0 0 30px rgba(0, 4, 255, 0.15); border-radius: 8px;"> 
    <thead>
        <td colspan="2" style="background-color: #009879; color:white; border-top-left-radius: 8px; border-top-right-radius: 8px;">TABELLA</td>
    </thead>
    <tbody style="border-bottom: 5px solid #009879">
        <tr>
        <td>Data di Produzione</td>
        <td>${moment(result.DATAATTUALE).format("DD/MM/YY HH:MM:SS")}</td>
        </tr>
        <tr>
        <td>Data di Consegna</td>
        <td>${moment(result.DATACONSEGNA).format(
            "DD/MM/YY HH:MM:SS"
        )}</td>       
        </tr>
        <tr>
        <td>Pezzi prodotti sul totale</td>
        <td>${result.PEZZI_BUONI + result.PEZZI_SCARTO_RIUTILIZZABILI}/${
        result.PEZZI_TOTALI
    }</td>
        </tr>
        <tr>
        <td>Pezzi Buoni</td>
        <td>${result.PEZZI_BUONI}</td>
        </tr>
        <tr>
        <td>Pezzi Scartati</td>
        <td>${result.PEZZI_SCARTI}</td>       
        </tr>
        <tr>
        <td>Pezzi Scartati ma Buoni</td>
        <td>${result.PEZZI_SCARTO_RIUTILIZZABILI}</td>
        </tr>
        <tr>
        <td>Tempo di produzione</td>
        <td>${result.TEMPO_DI_PRODUZIONE}</td>       
        </tr>
        <tr>
        <td>Tempo di produzione momentaneo</td>
        <td>${result.TEMPO_DI_PRODUZIONE_MOMENTANEO}</td>
        </tr>
    </tbody>
    </table>`);
    $("#stampaLog").prepend(template);
};

const stampaAvviso = (statop) => {
    let style = "bg-success";
    if (statop == "" || statop == "Errore" || statop == "Conclusa") {
        style = "bg-danger";
    }
    let template = $(`
    <link rel="stylesheet" href="../css/style.css" />
    <div class="jumbotron ${style}  text-center">
    <h1 class="text-center" style="color:white; font-size:28px;">${statop}</h1>
    </div>   
`);
    $("#stampaAvviso").prepend(template);
};

const stampaGrafico = (result) => {
    const template = $(`
    `);
    $("#stampaProd").prepend(template);
    var ctx = document.getElementById("myChart");

    var myChart = new Chart(ctx, {
        type: "line",
        data: {
            labels: result.dateTime,
            datasets: [
                {
                    data: result.PezziProdotti,
                    lineTension: 0,
                    backgroundColor: "transparent",
                    borderColor: "#007bff",
                    borderWidth: 4,
                    pointBackgroundColor: "#007bff",
                },
            ],
        },
        options: {
            animation: {
                duration: 0,
            },
            scales: {
                yAxes: [
                    {
                        ticks: {
                            beginAtZero: false,
                        },
                    },
                ],
            },
            legend: {
                display: false,
            },
        },
    });
};
