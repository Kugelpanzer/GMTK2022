-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 07, 2020 at 08:44 AM
-- Server version: 10.1.37-MariaDB
-- PHP Version: 7.3.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+01:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `brain_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `allowed_block`
--

CREATE TABLE `allowed_block` (
  `blockId` int(11) NOT NULL,
  `allowedBlockId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `block`
--

CREATE TABLE `block` (
  `id` int(11) NOT NULL,
  `maxSyn` int(64) NOT NULL,
  `conNum` int(64) NOT NULL,
  `forget` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `conection`
--

CREATE TABLE `conection` (
  `idSyn` int(64) NOT NULL,
  `idBlock` int(64) NOT NULL,
  `idSmartBit` int(64) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `smart_bit`
--

CREATE TABLE `smart_bit` (
  `id` int(64) NOT NULL,
  `blockIndex` int(64) NOT NULL,
  `ioList` varchar(1) NOT NULL,
  `value` varchar(255) NOT NULL,
  `outPoint` int(64) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `syn`
--

CREATE TABLE `syn` (
  `id` int(64) NOT NULL,
  `nconst` tinyint(1) NOT NULL,
  `ioList` varchar(1) NOT NULL,
  `inPoint` int(64) NOT NULL,
  `value` varchar(255) NOT NULL,
  `idSmartBit` int(64) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `allowed_block`
--
ALTER TABLE `allowed_block`
  ADD KEY `blockId` (`blockId`);

--
-- Indexes for table `block`
--
ALTER TABLE `block`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `conection`
--
ALTER TABLE `conection`
  ADD KEY `idSyn` (`idSyn`);

--
-- Indexes for table `smart_bit`
--
ALTER TABLE `smart_bit`
  ADD PRIMARY KEY (`id`),
  ADD KEY `block_index` (`blockIndex`);

--
-- Indexes for table `syn`
--
ALTER TABLE `syn`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idSmartBit` (`idSmartBit`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `block`
--
ALTER TABLE `block`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `smart_bit`
--
ALTER TABLE `smart_bit`
  MODIFY `id` int(64) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `syn`
--
ALTER TABLE `syn`
  MODIFY `id` int(64) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `allowed_block`
--
ALTER TABLE `allowed_block`
  ADD CONSTRAINT `allowed_block_ibfk_1` FOREIGN KEY (`blockId`) REFERENCES `block` (`id`);

--
-- Constraints for table `conection`
--
ALTER TABLE `conection`
  ADD CONSTRAINT `conection_ibfk_1` FOREIGN KEY (`idSyn`) REFERENCES `syn` (`id`);

--
-- Constraints for table `smart_bit`
--
ALTER TABLE `smart_bit`
  ADD CONSTRAINT `smart_bit_ibfk_1` FOREIGN KEY (`blockIndex`) REFERENCES `block` (`id`);

--
-- Constraints for table `syn`
--
ALTER TABLE `syn`
  ADD CONSTRAINT `syn_ibfk_1` FOREIGN KEY (`idSmartBit`) REFERENCES `smart_bit` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
