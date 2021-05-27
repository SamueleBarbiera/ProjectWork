# ProjectWork
Il seguente progetto, prevede un’automazione che, grazie ad un’applicazione permette ad un PC situato in un ufficio di inviare dati di commesse specifiche ad un PLC 
situato in reparto produzione. All’arrivo dei dati da due possibilità di avvio, la prima è un avvio virtuale, 
ovvero attraverso l’applicazione da ufficio si può avviare la produzione , l’altro invece è lo start fisico da pulsantiera collegata al PLC. Una volta iniziata la produzione,
essa si fermerà solo in condizione di emergenza della macchina, la quale mostrerà sul display HMI l’errore specifico, che verrà riportato poi sull'applicazione per ufficio
e sulla dashboard web. Man mano che la macchina stamperà le etichette, il valore dei pezzi prodotti aumenterà in tempo reale sia sul PLC che sul sito web , 
in modo da monitorare in modo efficiente tale produzione. Sia dalla applicazione riservata agli uffici che dalla pagina web si potrà vedere lo storico delle commesse eseguite,
con relativi codici, articoli, pezzi da produrre, data di inizio e data di consegna relative a tutte le commesse portate a termine. 
Verrà inoltre controllato continuamente che la connessione tra PC, API , PLC e database , sia sempre attiva e, in caso contrario , 
l’applicazione console darà come risultato l’errore di collegamento , mostrando quale parte di sistema sarà disconnessa.
