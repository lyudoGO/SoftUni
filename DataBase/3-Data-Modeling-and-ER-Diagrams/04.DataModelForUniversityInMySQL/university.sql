-- phpMyAdmin SQL Dump
-- version 4.1.12
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Feb 11, 2015 at 09:39 AM
-- Server version: 5.6.16
-- PHP Version: 5.5.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `university`
--

-- --------------------------------------------------------

--
-- Table structure for table `courses`
--

CREATE TABLE IF NOT EXISTS `courses` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `professorId` int(11) NOT NULL,
  `departmentId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `professorId` (`professorId`),
  KEY `departmentId` (`departmentId`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=2 ;

--
-- Dumping data for table `courses`
--

INSERT INTO `courses` (`Id`, `Name`, `professorId`, `departmentId`) VALUES
(1, 'Basics C#', 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `departments`
--

CREATE TABLE IF NOT EXISTS `departments` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `facultyId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `facultyId` (`facultyId`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=5 ;

--
-- Dumping data for table `departments`
--

INSERT INTO `departments` (`Id`, `Name`, `facultyId`) VALUES
(1, 'Computer Systems and Technologies', 1),
(2, 'Electronics', 1),
(3, 'Mechanical Equipment and Technologies', 2),
(4, 'Mechanical and Instrument Engineering', 2);

-- --------------------------------------------------------

--
-- Table structure for table `faculties`
--

CREATE TABLE IF NOT EXISTS `faculties` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=5 ;

--
-- Dumping data for table `faculties`
--

INSERT INTO `faculties` (`Id`, `Name`) VALUES
(1, 'Electronics and Automation'),
(2, 'Mechanical Engineering');

-- --------------------------------------------------------

--
-- Table structure for table `professors`
--

CREATE TABLE IF NOT EXISTS `professors` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `departmentId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `departmentId` (`departmentId`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Dumping data for table `professors`
--

INSERT INTO `professors` (`Id`, `Name`, `departmentId`) VALUES
(1, 'Grisha Spasov', 1);

-- --------------------------------------------------------

--
-- Table structure for table `professorstitles`
--

CREATE TABLE IF NOT EXISTS `professorstitles` (
  `professorId` int(11) NOT NULL,
  `titleId` int(11) NOT NULL,
  KEY `professorId` (`professorId`),
  KEY `titleId` (`titleId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `professorstitles`
--

INSERT INTO `professorstitles` (`professorId`, `titleId`) VALUES
(1, 1),
(1, 5);

-- --------------------------------------------------------

--
-- Table structure for table `students`
--

CREATE TABLE IF NOT EXISTS `students` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `FacultyNumber` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `facultyId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `FacultyNumber` (`FacultyNumber`),
  KEY `facultyId` (`facultyId`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=5 ;

--
-- Dumping data for table `students`
--

INSERT INTO `students` (`Id`, `Name`, `FacultyNumber`, `facultyId`) VALUES
(1, 'Ivan Ivanov', '1000100', 1),
(2, 'Georgy Georgiev', '1000101', 1),
(3, 'Petyr Petrov', '1000200', 2),
(4, 'Silvia Petrova', '1000201', 2);

-- --------------------------------------------------------

--
-- Table structure for table `studentscourses`
--

CREATE TABLE IF NOT EXISTS `studentscourses` (
  `StudentId` int(11) NOT NULL,
  `CoursesId` int(11) NOT NULL,
  KEY `StudentId` (`StudentId`),
  KEY `CoursesId` (`CoursesId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `titles`
--

CREATE TABLE IF NOT EXISTS `titles` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=6 ;

--
-- Dumping data for table `titles`
--

INSERT INTO `titles` (`Id`, `Name`) VALUES
(1, 'Prof.'),
(2, 'Assoc.'),
(3, 'Principal Ass.'),
(4, 'eng.'),
(5, 'Ph.D.');

--
-- Constraints for dumped tables
--

--
-- Constraints for table `courses`
--
ALTER TABLE `courses`
  ADD CONSTRAINT `courses_ibfk_2` FOREIGN KEY (`departmentId`) REFERENCES `departments` (`Id`),
  ADD CONSTRAINT `courses_ibfk_1` FOREIGN KEY (`professorId`) REFERENCES `professors` (`Id`);

--
-- Constraints for table `departments`
--
ALTER TABLE `departments`
  ADD CONSTRAINT `departments_ibfk_1` FOREIGN KEY (`facultyId`) REFERENCES `faculties` (`Id`);

--
-- Constraints for table `professors`
--
ALTER TABLE `professors`
  ADD CONSTRAINT `professors_ibfk_1` FOREIGN KEY (`departmentId`) REFERENCES `departments` (`Id`);

--
-- Constraints for table `professorstitles`
--
ALTER TABLE `professorstitles`
  ADD CONSTRAINT `professorstitles_ibfk_2` FOREIGN KEY (`titleId`) REFERENCES `titles` (`Id`),
  ADD CONSTRAINT `professorstitles_ibfk_1` FOREIGN KEY (`professorId`) REFERENCES `professors` (`Id`);

--
-- Constraints for table `students`
--
ALTER TABLE `students`
  ADD CONSTRAINT `students_ibfk_1` FOREIGN KEY (`facultyId`) REFERENCES `faculties` (`Id`);

--
-- Constraints for table `studentscourses`
--
ALTER TABLE `studentscourses`
  ADD CONSTRAINT `studentscourses_ibfk_2` FOREIGN KEY (`CoursesId`) REFERENCES `courses` (`Id`),
  ADD CONSTRAINT `studentscourses_ibfk_1` FOREIGN KEY (`StudentId`) REFERENCES `students` (`Id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
