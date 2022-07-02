-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Creato il: Gen 14, 2019 alle 23:15
-- Versione del server: 10.1.36-MariaDB
-- Versione PHP: 7.2.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `quizcross`
--
CREATE DATABASE quizcross;
USE quizcross;

-- --------------------------------------------------------

--
-- Struttura della tabella `divisioni`
--

CREATE TABLE `divisioni` (
  `PuntiIniziali` int(11) NOT NULL,
  `PuntiFinali` int(11) NOT NULL,
  `Immagine` varchar(20) NOT NULL,
  `ID_DIVISIONE` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dump dei dati per la tabella `divisioni`
--

INSERT INTO `divisioni` (`PuntiIniziali`, `PuntiFinali`, `Immagine`, `ID_DIVISIONE`) VALUES
(1, 1000000, 'bronzo', 'Bronzo');

-- --------------------------------------------------------

--
-- Struttura della tabella `domande`
--

CREATE TABLE `domande` (
  `ID_DOMANDA` int(11) NOT NULL,
  `Testo` text NOT NULL,
  `Risposta0` text NOT NULL,
  `Risposta1` text NOT NULL,
  `Risposta2` text NOT NULL,
  `Risposta3` text NOT NULL,
  `Soluzione` text NOT NULL,
  `Punti` int(11) NOT NULL,
  `FK_ID_GENERE` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dump dei dati per la tabella `domande`
--

INSERT INTO `domande` (`ID_DOMANDA`, `Testo`, `Risposta0`, `Risposta1`, `Risposta2`, `Risposta3`, `Soluzione`, `Punti`, `FK_ID_GENERE`) VALUES
(1, 'Dove sbarcano gli \" Alleati \" il 22 gennaio 1944 ?', 'Ad Anzio', 'A Marsala', 'A Trieste', 'A Quarto', 'Ad Anzio', 100, 'Storia'),
(2, 'Di quale giornale fu direttore Mussolini?', 'La Repubblica', 'Il fatto quotidiano', 'L\'Avanti', 'Non ? mai stato direttore di alcun giornale', 'Il fatto quotidiano', 100, 'Storia'),
(3, 'Che legge venne approvata in Italia dal Parlamento nel 1970?', 'La legge sull\'aborto\r\n', 'La legge sulle carceri\r\n', 'La legge sull\'omosessualit?', 'La legge sul divorzio', 'La legge sul divorzio', 100, 'Storia'),
(4, 'In che anno il governo Giolitti diede le dimissioni dopo l\'uscita dei radicali?', '1913', '1914', '1915', '1916', '1914', 100, 'Storia'),
(5, 'In seguito a cosa inizi? la Seconda Guerra Mondiale?', 'L\'invasione della Francia', 'L\'invasione della Polonia', 'L\'invasione dell\'Inghilterra', 'Nessuna delle risposte precendenti', 'Nessuna delle risposte precendenti', 100, 'Storia'),
(6, 'Il sindacato dei lavoratori italiani fondato nel 1906 si chiamava:', 'Confederazione Italiana Sindacati Lavoratori', 'Confederazione Generale del Lavoro', 'Confederazione Italiana Dirigenti d\'Azienda', 'Unione Lavoratori', 'Unione Lavoratori', 100, 'Storia'),
(7, 'Uno dei piani politici-economici messi in atto dagli Stati Uniti dopo la Seconda Guerra Mondiale si chiamava:', 'I Patti Lateranensi', 'Il Trattato di Maastricht', 'Il Trattato di Lisbona', 'Il Piano Marshall', 'Il Piano Marshall', 100, 'Storia'),
(8, 'In che anno fu firmato l\'armistizio che port? alla conclusione della prima guerra mondiale?', 'Novembre 1918', 'Marzo 1918', 'Novembre 1919', 'Aprile 1919', 'Aprile 1919', 100, 'Storia'),
(9, 'In che anno Mussolini dichiar? guerra alla Gran Bretagna e alla Francia?', '1939', '1940', '1941', '1938', '1938', 100, 'Storia'),
(10, 'Come si chiama una parte dell\'India che divenne uno stato autonomo nel 1947?', 'Pakistan', 'Delhi', 'Manipur', 'Tibet', 'Tibet', 100, 'Storia'),
(11, 'Che tassa venne introdotto durante il periodo fascista?', 'sul grano', 'sugli allevamenti', 'sul celibato', 'sui terreni', 'sui terreni', 100, 'Storia'),
(12, 'Chi era Presidente del Consiglio dei Ministri nel 1984 quando si firm? il concordato tra Stato e Chiesa?', 'Andreotti', 'Cossiga', 'Scalfaro', 'Craxi', 'Cossiga', 100, 'Storia'),
(13, 'Qual ? la pi? grande isola della terra ?', 'Inghilterra', 'Groenlandia', 'Islanda', 'Madagascar', 'Groenlandia', 100, 'Geografia'),
(14, 'Quale dei seguenti paesi non si affaccia sul bacino del Mediterraneo ?', 'Siria', 'Albania', 'Tunisia', 'Sudan', 'Sudan', 100, 'Geografia'),
(15, 'Damasco ? la capitale...', 'della Cina.', ' della Turchia.', 'dell\'India.', 'della Siria.', 'della Siria.', 100, 'Geografia'),
(16, 'La capitale del Kuwait ?...', 'Al-Kuwait.', 'Mascate.', 'Dacca.', 'Katmandu.', 'Al-Kuwait.', 100, 'Geografia'),
(17, 'La capitale della Corea del Nord ?...', 'Seoul.', 'Valencia', 'Pyongyang.', 'Ulan Bator.', 'Pyongyang.', 100, 'Geografia'),
(18, 'La capitale del Gibuti ?...', 'Rabat.', 'Gibuti.', 'Bissau.', 'Monrovia.', 'Gibuti.', 100, 'Geografia'),
(19, 'La capitale dell\'Uganda ?...', 'Quinto.', 'Canberra.', 'Kampala.', 'Mbabane.', 'Kampala.', 100, 'Geografia'),
(20, 'La capitale di Capo Verde ?...', 'Nairobi.', 'Antananarivo.', 'Il Cairo.', 'Praia.', 'Praia.', 100, 'Geografia'),
(21, 'Chi di questi autori ha scritto l\'Infinito?', 'Alessandro Manzoni', 'Giacomo Leopardi', 'Cesare Beccaria', 'Giovanni Pascoli', 'Giacomo Leopardi', 100, 'Italiano'),
(22, 'Quanto fa 2/0?', 'Indeterminato', 'Zero', 'Due', 'Impossibile', 'Impossibile', 100, 'Matematica'),
(23, 'Mal comune mezzo…', 'Gaudio', 'Mattino', 'Giorno', 'Vicino', 'Gaudio', 100, 'Italiano'),
(24, 'Quale di queste e\' una locuzione avverbiale?', 'Andando al mare', 'Passo dopo passo', 'Velocemente', 'Domani', 'Passo dopo passo', 100, 'Italiano'),
(28, 'Il participio passato del verbo essere è:', 'Stato', 'Fu', 'Essere', 'Sarà', 'Stato', 100, 'Italiano'),
(29, 'Il termine mandria è un sostantivo', 'Singolare', 'Collettivo', 'Di gruppo', 'Plurale', 'Collettivo', 100, 'Italiano'),
(30, 'Chi vinse il mondiale di calcio del 1958?', 'Brasile', 'Francia', 'Italia', 'Germania', 'Brasile', 100, 'Sport'),
(31, 'Quanti giocatori ha una squadra di basket in campo?', '4', '5', '6', '7', '5', 100, 'Sport'),
(32, 'Chi è il vincitore del pallone d\'oro 2018?', 'Luka Modric', 'Cristiano Ronaldo', 'Lionel Messi', 'Neymar Jr', 'Luka Modric', 100, 'Sport'),
(33, 'Quale di queste squadre ha vinto più Champions League?', 'Roma', 'Napoli', 'Paris Saint-Germain', 'Nottingham Forest', 'Nottingham Forest', 100, 'Sport'),
(34, 'Qual e\' la formula dell\'acqua?', 'CO2', 'H20', 'H2O', 'CO', 'H2O', 100, 'Chimica'),
(35, 'Una soluzione acquosa 1,0 mM contiene, nel volume di 1 litro, un numero di moli pari a: ', '1000', '0,001', '1', '0,1', '0,001', 100, 'Chimica'),
(36, 'La % m/m indica: ', 'I grammi di soluto in 100 g di soluzione', 'I grammi di soluto in un litro di soluzione', 'I Kg di soluto in 100 ml di soluzione', 'I grammi di soluto in 100 ml di solvente', 'I grammi di soluto in 100 g di soluzione', 100, 'Chimica'),
(37, 'Come si chiama il giornalista che segue il capo dello stato?', 'Quirinalista', 'Presidente del consiglio', 'Direttore dello stato', 'Giornalista del quirinale', 'Quirinalista', 100, 'Diritto'),
(38, 'Chi è l\'attuale Presidente del Consiglio?', 'Giuseppe Conte', 'Matteo Salvini', 'Luigi Di Maio', 'Sergio Mattarella', 'Giuseppe Conte', 100, 'Diritto'),
(39, 'Quanto fa : Ln(9)', '2.08', '2.19', '1.67', '9.3', '2.19', 100, 'Matematica'),
(40, 'Benjamin Franklin inventò:', 'Ruota', 'Parafulmine', 'Motoscafo', 'Aceto', 'Parafulmine', 100, 'Scienze'),
(41, 'Il primo termometro fu realizzato da?', 'Galileo Galilei', 'Daniel Fahrenheit', 'Leonardo Da Vinci', 'Friedrich Nietzsche', 'Galileo Galilei', 100, 'Scienze'),
(42, 'La macchina a vapore fu inventata da:', 'Galileo Galilei', 'Thomas Edison', 'James Watt', 'Benjamin Franklin', 'James Watt', 100, 'Scienze'),
(43, 'Adolphe Sax inventò il sassofono nel:', '1778', '1612', '1925', '1841', '1841', 100, 'Scienze');

-- --------------------------------------------------------

--
-- Struttura della tabella `domandenelround`
--

CREATE TABLE `domandenelround` (
  `FK_ID_ROUND` int(11) NOT NULL,
  `FK_ID_DOMANDA` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Struttura della tabella `generi`
--

CREATE TABLE `generi` (
  `ID_GENERE` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dump dei dati per la tabella `generi`
--

INSERT INTO `generi` (`ID_GENERE`) VALUES
('Chimica'),
('Diritto'),
('Geografia'),
('Italiano'),
('Matematica'),
('Scienze'),
('Sport'),
('Storia');

-- --------------------------------------------------------

--
-- Struttura della tabella `giocatori`
--

CREATE TABLE `giocatori` (
  `USERNAME` varchar(20) NOT NULL,
  `Password` varchar(20) NOT NULL,
  `Punti` int(11) NOT NULL,
  `PartiteVinte` int(11) NOT NULL,
  `FK_ID_DIVISIONE` varchar(10) DEFAULT NULL,
  `Avatar` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Tabella contenente l''elenco dei player';

--
-- Dump dei dati per la tabella `giocatori`
--

INSERT INTO `giocatori` (`USERNAME`, `Password`, `Punti`, `PartiteVinte`, `FK_ID_DIVISIONE`, `Avatar`) VALUES
('cavailmagnifico', 'cavailmagnifico', 10000, 100, 'Bronzo', 'primo'),
('cestiogallo', 'cestiogallo', 10000, 100, 'Bronzo', 'secondo'),
('tanzone2000', 'tanzone2000', 10000, 100, 'Bronzo', 'terzo');

-- --------------------------------------------------------

--
-- Struttura della tabella `partite`
--

CREATE TABLE `partite` (
  `ID_PARTITA` int(11) NOT NULL,
  `Punti1` int(11) DEFAULT NULL,
  `Punti2` int(11) DEFAULT NULL,
  `FK_USERNAME1` varchar(20) NOT NULL,
  `FK_USERNAME2` varchar(20) NOT NULL,
  `FK_USERNAME_VINCITORE` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Struttura della tabella `rispostegiocatori`
--

CREATE TABLE `rispostegiocatori` (
  `FK_USERNAME` varchar(20) NOT NULL,
  `FK_ID_DOMANDA` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Struttura della tabella `rounds`
--

CREATE TABLE `rounds` (
  `ID_ROUND` int(11) NOT NULL,
  `FK_ID_PARTITA` int(11) NOT NULL,
  `NumeroRound` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Tabella contenenti i round da gestire ';

-- --------------------------------------------------------

--
-- Struttura della tabella `sfide`
--

CREATE TABLE `sfide` (
  `ID_SFIDA` int(11) NOT NULL,
  `FK_ID_PARTITA` int(11) NOT NULL,
  `DataInizio` date NOT NULL,
  `DataScadenza` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Tabella contenente le sfide.';

--
-- Indici per le tabelle scaricate
--

--
-- Indici per le tabelle `divisioni`
--
ALTER TABLE `divisioni`
  ADD PRIMARY KEY (`ID_DIVISIONE`);

--
-- Indici per le tabelle `domande`
--
ALTER TABLE `domande`
  ADD PRIMARY KEY (`ID_DOMANDA`),
  ADD KEY `FK_DOMANDE_GENERE` (`FK_ID_GENERE`);

--
-- Indici per le tabelle `domandenelround`
--
ALTER TABLE `domandenelround`
  ADD KEY `FK_DOMANDER_DOMANDE` (`FK_ID_DOMANDA`),
  ADD KEY `FK_DOMANDER_ROUND` (`FK_ID_ROUND`);

--
-- Indici per le tabelle `generi`
--
ALTER TABLE `generi`
  ADD PRIMARY KEY (`ID_GENERE`);

--
-- Indici per le tabelle `giocatori`
--
ALTER TABLE `giocatori`
  ADD PRIMARY KEY (`USERNAME`),
  ADD KEY `FK_PLAYER_DIVISIONE` (`FK_ID_DIVISIONE`);

--
-- Indici per le tabelle `partite`
--
ALTER TABLE `partite`
  ADD PRIMARY KEY (`ID_PARTITA`),
  ADD KEY `FK_PARTITE_PLAYER1` (`FK_USERNAME1`),
  ADD KEY `FK_PARTITE_PLAYER2` (`FK_USERNAME2`),
  ADD KEY `FK_PARTITE_PLAYER_VINCENTE` (`FK_USERNAME_VINCITORE`);

--
-- Indici per le tabelle `rispostegiocatori`
--
ALTER TABLE `rispostegiocatori`
  ADD KEY `FK_RISPOSTE_DOMANDE` (`FK_ID_DOMANDA`),
  ADD KEY `FK_RISPOSTE_PLAYER` (`FK_USERNAME`);

--
-- Indici per le tabelle `rounds`
--
ALTER TABLE `rounds`
  ADD PRIMARY KEY (`ID_ROUND`),
  ADD KEY `FK_ROUND_PARTITA` (`FK_ID_PARTITA`);

--
-- Indici per le tabelle `sfide`
--
ALTER TABLE `sfide`
  ADD PRIMARY KEY (`ID_SFIDA`),
  ADD KEY `FK_SFIDA_PARTITA` (`FK_ID_PARTITA`);

--
-- AUTO_INCREMENT per le tabelle scaricate
--

--
-- AUTO_INCREMENT per la tabella `domande`
--
ALTER TABLE `domande`
  MODIFY `ID_DOMANDA` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=44;

--
-- AUTO_INCREMENT per la tabella `partite`
--
ALTER TABLE `partite`
  MODIFY `ID_PARTITA` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=52;

--
-- AUTO_INCREMENT per la tabella `rounds`
--
ALTER TABLE `rounds`
  MODIFY `ID_ROUND` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=30;

--
-- AUTO_INCREMENT per la tabella `sfide`
--
ALTER TABLE `sfide`
  MODIFY `ID_SFIDA` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- Limiti per le tabelle scaricate
--

--
-- Limiti per la tabella `domande`
--
ALTER TABLE `domande`
  ADD CONSTRAINT `FK_DOMANDE_GENERE` FOREIGN KEY (`FK_ID_GENERE`) REFERENCES `generi` (`ID_GENERE`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Limiti per la tabella `domandenelround`
--
ALTER TABLE `domandenelround`
  ADD CONSTRAINT `FK_DOMANDER_DOMANDE` FOREIGN KEY (`FK_ID_DOMANDA`) REFERENCES `domande` (`ID_DOMANDA`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_DOMANDER_ROUND` FOREIGN KEY (`FK_ID_ROUND`) REFERENCES `rounds` (`ID_ROUND`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Limiti per la tabella `giocatori`
--
ALTER TABLE `giocatori`
  ADD CONSTRAINT `FK_PLAYER_DIVISIONE` FOREIGN KEY (`FK_ID_DIVISIONE`) REFERENCES `divisioni` (`ID_DIVISIONE`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Limiti per la tabella `partite`
--
ALTER TABLE `partite`
  ADD CONSTRAINT `FK_PARTITE_PLAYER1` FOREIGN KEY (`FK_USERNAME1`) REFERENCES `giocatori` (`USERNAME`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_PARTITE_PLAYER2` FOREIGN KEY (`FK_USERNAME2`) REFERENCES `giocatori` (`USERNAME`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_PARTITE_PLAYER_VINCENTE` FOREIGN KEY (`FK_USERNAME_VINCITORE`) REFERENCES `giocatori` (`USERNAME`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Limiti per la tabella `rispostegiocatori`
--
ALTER TABLE `rispostegiocatori`
  ADD CONSTRAINT `FK_RISPOSTE_DOMANDE` FOREIGN KEY (`FK_ID_DOMANDA`) REFERENCES `domande` (`ID_DOMANDA`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_RISPOSTE_PLAYER` FOREIGN KEY (`FK_USERNAME`) REFERENCES `giocatori` (`USERNAME`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Limiti per la tabella `rounds`
--
ALTER TABLE `rounds`
  ADD CONSTRAINT `FK_ROUND_PARTITA` FOREIGN KEY (`FK_ID_PARTITA`) REFERENCES `partite` (`ID_PARTITA`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Limiti per la tabella `sfide`
--
ALTER TABLE `sfide`
  ADD CONSTRAINT `FK_SFIDA_PARTITA` FOREIGN KEY (`FK_ID_PARTITA`) REFERENCES `partite` (`ID_PARTITA`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
