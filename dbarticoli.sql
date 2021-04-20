-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Creato il: Apr 20, 2021 alle 16:31
-- Versione del server: 10.4.14-MariaDB
-- Versione PHP: 7.4.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbarticoli`
--

-- --------------------------------------------------------

--
-- Struttura della tabella `articoli`
--

CREATE TABLE `articoli` (
  `ID` int(11) NOT NULL,
  `Titolo` varchar(30) NOT NULL,
  `Descrizione` varchar(90) DEFAULT NULL,
  `Prezzo` decimal(7,2) NOT NULL DEFAULT 5.99
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dump dei dati per la tabella `articoli`
--

INSERT INTO `articoli` (`ID`, `Titolo`, `Descrizione`, `Prezzo`) VALUES
(1, 'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', 'b', '0.00'),
(2, 'ssssssdfgyui', 'fegsfnwe', '0.00'),
(4, 'aaaaaaaaaaaaaaaaa', 'bbbbbbb', '89.00'),
(6, 'mmaaaaaaaa', 'aaaaa', '1.00'),
(10, 'ssssssdfqrte5yr6', 'fegsfnwe', '0.00'),
(17, 'saì', 'NULL', '5.99'),
(21, 'TEST', 'NULL', '5.99'),
(23, 'aaa', 'aa', '0.00'),
(25, 'aaaaaaa', NULL, '0.00'),
(26, 'a', 'aaa', '0.00'),
(28, 'b', 'bbb', '0.00'),
(33, '1', NULL, '566.00'),
(36, '1q1', '', '0.00'),
(42, 'Godel', NULL, '0.00'),
(43, 'Godel, Escher', 'aa', '67.00'),
(46, 'Homo Deus', 'Harari', '0.00'),
(47, 'The Queens Gambit', 'aaaaa', '-2.00'),
(48, 'Happy Days', 'e', '0.00'),
(49, 'beta', NULL, '0.00'),
(50, 'bbbbbbbbbb', 'bbb', '0.00'),
(89, 'string', 'string', '0.00'),
(91, 'strinnnng', 'string', '0.00'),
(92, 'strinnnnnnnng', 'string', '0.00'),
(93, '<script>alert(\'ciao\')</script>', NULL, '0.00'),
(96, '<script>alert(\'ciao\');</script', NULL, '0.00'),
(99, 'prova', '<script>alert(\'ciao\');</script>', '0.00');

--
-- Indici per le tabelle scaricate
--

--
-- Indici per le tabelle `articoli`
--
ALTER TABLE `articoli`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `Titolo` (`Titolo`);

--
-- AUTO_INCREMENT per le tabelle scaricate
--

--
-- AUTO_INCREMENT per la tabella `articoli`
--
ALTER TABLE `articoli`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=100;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
