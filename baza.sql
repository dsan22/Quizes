-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Sep 28, 2023 at 06:16 PM
-- Server version: 8.0.31
-- PHP Version: 8.0.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `quizes`
--

-- --------------------------------------------------------

--
-- Table structure for table `answer`
--

DROP TABLE IF EXISTS `answer`;
CREATE TABLE IF NOT EXISTS `answer` (
  `id` int NOT NULL AUTO_INCREMENT,
  `text` varchar(100) NOT NULL,
  `is_correct` tinyint(1) NOT NULL,
  `question_id` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `question_id` (`question_id`)
) ENGINE=InnoDB AUTO_INCREMENT=121 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `answer`
--

INSERT INTO `answer` (`id`, `text`, `is_correct`, `question_id`) VALUES
(21, '1', 0, 10),
(22, '2', 1, 10),
(23, '3', 0, 10),
(24, '4', 0, 10),
(25, '1', 1, 11),
(26, '2', 0, 11),
(27, '3', 0, 11),
(28, '4', 0, 11),
(29, '1', 0, 12),
(30, '12', 0, 12),
(31, '25', 1, 12),
(32, '64', 0, 12),
(33, '1', 1, 13),
(34, '2', 0, 13),
(35, '3', 0, 13),
(36, '4', 0, 13),
(37, '1', 0, 14),
(38, '2', 0, 14),
(39, '3', 0, 14),
(40, '4', 1, 14),
(41, '1', 0, 15),
(42, '5', 0, 15),
(43, '9', 0, 15),
(44, '10', 1, 15),
(45, '0', 0, 16),
(46, '-1', 0, 16),
(47, '7', 0, 16),
(48, '-9', 1, 16),
(49, '1', 0, 17),
(50, '10', 1, 17),
(51, '100', 0, 17),
(52, '1000', 0, 17),
(53, '1', 0, 18),
(54, '2', 0, 18),
(55, '3', 0, 18),
(56, '0', 1, 18),
(57, '2', 0, 19),
(58, '8', 1, 19),
(59, '4', 0, 19),
(60, '1', 0, 19),
(61, '1', 0, 20),
(62, '2', 0, 20),
(63, '3', 1, 20),
(64, '4', 0, 20),
(65, '1', 1, 21),
(66, '2', 0, 21),
(67, '3', 0, 21),
(68, '4', 0, 21),
(69, '2', 0, 22),
(70, '12', 0, 22),
(71, '14', 1, 22),
(72, '13', 0, 22),
(73, '2', 0, 23),
(74, '4', 0, 23),
(75, '6', 0, 23),
(76, '8', 1, 23),
(77, 'Answer1', 1, 24),
(78, 'Answer2', 0, 24),
(79, 'Answer3', 0, 24),
(80, 'Answer4', 0, 24),
(81, 'Answer1', 1, 25),
(82, 'Answer2', 0, 25),
(83, 'Answer3', 0, 25),
(84, 'Answer4', 0, 25),
(89, 'Beograd', 0, 27),
(90, 'London', 1, 27),
(91, 'Pariz', 0, 27),
(92, 'Bukuresta', 0, 27),
(97, 'London', 0, 29),
(98, 'Tokio', 0, 29),
(99, 'Beograd', 1, 29),
(100, 'Peking', 0, 29),
(101, 'Ankara', 0, 30),
(102, 'Moskva', 0, 30),
(103, 'Kijev', 0, 30),
(104, 'Pariz', 1, 30),
(105, 'Istanbul', 0, 31),
(106, 'Ankara', 1, 31),
(107, 'Atina', 0, 31),
(108, 'Madrid', 0, 31),
(109, 'Peking', 0, 32),
(110, 'Atina', 0, 32),
(111, 'Beograd', 0, 32),
(112, 'Moskva', 1, 32),
(113, 'Tokio', 1, 33),
(114, 'Nis', 0, 33),
(115, 'Madrid', 0, 33),
(116, 'London', 0, 33);

-- --------------------------------------------------------

--
-- Table structure for table `question`
--

DROP TABLE IF EXISTS `question`;
CREATE TABLE IF NOT EXISTS `question` (
  `id` int NOT NULL AUTO_INCREMENT,
  `text` varchar(100) NOT NULL,
  `quiz_id` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `quiz_id` (`quiz_id`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `question`
--

INSERT INTO `question` (`id`, `text`, `quiz_id`) VALUES
(10, '1+1', 1),
(11, '3-2', 1),
(12, '5*5', 1),
(13, '7/7', 1),
(14, '2^2', 1),
(15, '17-7', 1),
(16, '1-10', 1),
(17, '5*2', 1),
(18, '1-1', 1),
(19, '4+4', 1),
(20, '1+2', 1),
(21, '1*1', 1),
(22, '7+7', 1),
(23, '2+6', 1),
(24, 'Question text', 14),
(25, 'Question text', 14),
(27, 'Engleska', 16),
(29, 'Srbija', 16),
(30, 'Francuska', 16),
(31, 'Turska', 16),
(32, 'Rusija', 16),
(33, 'Japan', 16);

-- --------------------------------------------------------

--
-- Table structure for table `quiz`
--

DROP TABLE IF EXISTS `quiz`;
CREATE TABLE IF NOT EXISTS `quiz` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `created_by` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `created_by` (`created_by`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `quiz`
--

INSERT INTO `quiz` (`id`, `name`, `created_by`) VALUES
(1, 'Prvi kviz', 6),
(2, 'Drugi kviz', 6),
(13, 'test', 6),
(14, 'NoviQviz', 7),
(16, 'Glavni gradovi', 13);

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
CREATE TABLE IF NOT EXISTS `user` (
  `id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `is_admin` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`id`, `username`, `password`, `is_admin`) VALUES
(5, 'username', '1234', 0),
(6, 'admin', 'admin', 1),
(7, 'admin123', 'admin', 1),
(8, 'user123', 'user', 0),
(9, 'admin12323', '123', 1),
(13, 'dusan', '1234', 1),
(15, 'korisnik1', '1234', 0),
(16, 'korisnik2', '1234', 0),
(17, 'korisnik3', '1234', 0),
(18, 'korisnik4', '1234', 0);

-- --------------------------------------------------------

--
-- Table structure for table `user_quiz_answer`
--

DROP TABLE IF EXISTS `user_quiz_answer`;
CREATE TABLE IF NOT EXISTS `user_quiz_answer` (
  `id` int NOT NULL AUTO_INCREMENT,
  `user_quiz_attempt_id` int NOT NULL,
  `answer_id` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `user_quiz_attempt_id` (`user_quiz_attempt_id`),
  KEY `answer_id` (`answer_id`)
) ENGINE=InnoDB AUTO_INCREMENT=395 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `user_quiz_answer`
--

INSERT INTO `user_quiz_answer` (`id`, `user_quiz_attempt_id`, `answer_id`) VALUES
(1, 1, 24),
(2, 1, 28),
(3, 1, 32),
(4, 1, 36),
(5, 1, 40),
(6, 1, 44),
(7, 1, 48),
(8, 1, 52),
(9, 1, 56),
(10, 1, 60),
(11, 1, 64),
(12, 1, 68),
(13, 1, 72),
(14, 1, 76),
(15, 2, 22),
(16, 2, 26),
(17, 2, 30),
(18, 2, 34),
(19, 2, 38),
(20, 2, 42),
(21, 2, 46),
(22, 2, 50),
(23, 2, 54),
(24, 2, 58),
(25, 2, 62),
(26, 2, 66),
(27, 2, 70),
(28, 2, 74),
(29, 3, 22),
(30, 3, 26),
(31, 3, 30),
(32, 3, 34),
(33, 3, 38),
(34, 3, 42),
(35, 3, 46),
(36, 3, 50),
(37, 3, 54),
(38, 3, 58),
(39, 3, 62),
(40, 3, 66),
(41, 3, 70),
(42, 3, 74),
(43, 4, 22),
(44, 4, 26),
(45, 4, 30),
(46, 4, 34),
(47, 4, 38),
(48, 4, 42),
(49, 4, 46),
(50, 4, 50),
(51, 4, 54),
(52, 4, 58),
(53, 4, 62),
(54, 4, 66),
(55, 4, 70),
(56, 4, 74),
(57, 5, 22),
(58, 5, 26),
(59, 5, 30),
(60, 5, 34),
(61, 5, 38),
(62, 5, 42),
(63, 5, 46),
(64, 5, 50),
(65, 5, 54),
(66, 5, 58),
(67, 5, 62),
(68, 5, 66),
(69, 5, 70),
(70, 5, 74),
(71, 6, 22),
(72, 6, 26),
(73, 6, 30),
(74, 6, 34),
(75, 6, 38),
(76, 6, 42),
(77, 6, 46),
(78, 6, 50),
(79, 6, 54),
(80, 6, 58),
(81, 6, 62),
(82, 6, 66),
(83, 6, 70),
(84, 6, 74),
(85, 7, 22),
(86, 7, 26),
(87, 7, 30),
(88, 7, 34),
(89, 7, 38),
(90, 7, 42),
(91, 7, 46),
(92, 7, 50),
(93, 7, 54),
(94, 7, 58),
(95, 7, 62),
(96, 7, 66),
(97, 7, 70),
(98, 7, 74),
(99, 8, 22),
(100, 8, 26),
(101, 8, 30),
(102, 8, 34),
(103, 8, 38),
(104, 8, 42),
(105, 8, 46),
(106, 8, 50),
(107, 8, 54),
(108, 8, 58),
(109, 8, 62),
(110, 8, 66),
(111, 8, 70),
(112, 8, 74),
(113, 9, 22),
(114, 9, 26),
(115, 9, 30),
(116, 9, 34),
(117, 9, 38),
(118, 9, 42),
(119, 9, 46),
(120, 9, 50),
(121, 9, 54),
(122, 9, 58),
(123, 9, 62),
(124, 9, 66),
(125, 9, 70),
(126, 9, 74),
(127, 10, 22),
(128, 10, 26),
(129, 10, 30),
(130, 10, 34),
(131, 10, 38),
(132, 10, 42),
(133, 10, 46),
(134, 10, 50),
(135, 10, 54),
(136, 10, 58),
(137, 10, 62),
(138, 10, 66),
(139, 10, 70),
(140, 10, 74),
(141, 11, 24),
(142, 11, 28),
(143, 11, 32),
(144, 11, 36),
(145, 11, 40),
(146, 11, 44),
(147, 11, 48),
(148, 11, 52),
(149, 11, 56),
(150, 11, 60),
(151, 11, 64),
(152, 11, 68),
(153, 11, 72),
(154, 11, 76),
(155, 12, 23),
(156, 12, 27),
(157, 12, 31),
(158, 12, 35),
(159, 12, 39),
(160, 12, 43),
(161, 12, 47),
(162, 12, 51),
(163, 12, 55),
(164, 12, 59),
(165, 12, 63),
(166, 12, 67),
(167, 12, 71),
(168, 12, 75),
(169, 13, 22),
(170, 13, 26),
(171, 13, 30),
(172, 13, 34),
(173, 13, 38),
(174, 13, 42),
(175, 13, 46),
(176, 13, 50),
(177, 13, 54),
(178, 13, 58),
(179, 13, 62),
(180, 13, 66),
(181, 13, 70),
(182, 13, 74),
(183, 14, 22),
(184, 14, 26),
(185, 14, 30),
(186, 14, 34),
(187, 14, 38),
(188, 14, 42),
(189, 14, 46),
(190, 14, 50),
(191, 14, 54),
(192, 14, 58),
(193, 14, 62),
(194, 14, 66),
(195, 14, 70),
(196, 14, 74),
(197, 15, 24),
(198, 15, 28),
(199, 15, 32),
(200, 15, 36),
(201, 15, 40),
(202, 15, 44),
(203, 15, 48),
(204, 15, 52),
(205, 15, 56),
(206, 15, 60),
(207, 15, 64),
(208, 15, 68),
(209, 15, 72),
(210, 15, 76),
(211, 19, 24),
(212, 19, 28),
(213, 19, 32),
(214, 19, 36),
(215, 19, 40),
(216, 19, 44),
(217, 19, 48),
(218, 19, 52),
(219, 19, 56),
(220, 19, 60),
(221, 19, 64),
(222, 19, 68),
(223, 19, 72),
(224, 19, 76),
(225, 20, 24),
(226, 20, 28),
(227, 20, 32),
(228, 20, 36),
(229, 20, 40),
(230, 20, 44),
(231, 20, 48),
(232, 20, 52),
(233, 20, 56),
(234, 20, 60),
(235, 20, 64),
(236, 20, 68),
(237, 20, 72),
(238, 20, 76),
(239, 21, 22),
(240, 21, 26),
(241, 21, 30),
(242, 21, 34),
(243, 21, 38),
(244, 21, 42),
(245, 21, 46),
(246, 21, 50),
(247, 21, 54),
(248, 21, 58),
(249, 21, 62),
(250, 21, 66),
(251, 21, 70),
(252, 21, 74),
(253, 22, 21),
(254, 22, 25),
(255, 22, 29),
(256, 22, 33),
(257, 22, 37),
(258, 22, 41),
(259, 22, 45),
(260, 22, 49),
(261, 22, 53),
(262, 22, 57),
(263, 22, 61),
(264, 22, 65),
(265, 22, 69),
(266, 22, 73),
(267, 23, 21),
(268, 23, 26),
(269, 23, 30),
(270, 23, 36),
(271, 23, 40),
(272, 23, 43),
(273, 23, 46),
(274, 23, 49),
(275, 23, 55),
(276, 23, 58),
(277, 23, 64),
(278, 23, 67),
(279, 23, 70),
(280, 23, 76),
(281, 24, 22),
(282, 24, 26),
(283, 24, 30),
(284, 24, 34),
(285, 24, 38),
(286, 24, 42),
(287, 24, 46),
(288, 24, 50),
(289, 24, 54),
(290, 24, 58),
(291, 24, 62),
(292, 24, 66),
(293, 24, 70),
(294, 24, 74),
(295, 25, 22),
(296, 25, 26),
(297, 25, 30),
(298, 25, 34),
(299, 25, 38),
(300, 25, 42),
(301, 25, 46),
(302, 25, 50),
(303, 25, 54),
(304, 25, 58),
(305, 25, 62),
(306, 25, 66),
(307, 25, 70),
(308, 25, 74),
(309, 26, 22),
(310, 26, 26),
(311, 26, 30),
(312, 26, 34),
(313, 26, 38),
(314, 26, 42),
(315, 26, 46),
(316, 26, 50),
(317, 26, 54),
(318, 26, 58),
(319, 26, 62),
(320, 26, 66),
(321, 26, 70),
(322, 26, 74),
(323, 27, 23),
(324, 27, 27),
(325, 27, 31),
(326, 27, 35),
(327, 27, 39),
(328, 27, 43),
(329, 27, 47),
(330, 27, 51),
(331, 27, 55),
(332, 27, 59),
(333, 27, 63),
(334, 27, 67),
(335, 27, 71),
(336, 27, 75),
(337, 28, 22),
(338, 28, 26),
(339, 28, 30),
(340, 28, 34),
(341, 28, 38),
(342, 28, 42),
(343, 28, 46),
(344, 28, 50),
(345, 28, 54),
(346, 28, 58),
(347, 28, 62),
(348, 28, 66),
(349, 28, 70),
(350, 28, 74),
(351, 29, 22),
(352, 29, 26),
(353, 29, 30),
(354, 29, 34),
(355, 29, 38),
(356, 29, 42),
(357, 29, 46),
(358, 29, 50),
(359, 29, 54),
(360, 29, 58),
(361, 29, 62),
(362, 29, 66),
(363, 29, 70),
(364, 29, 74),
(371, 31, 90),
(372, 31, 99),
(373, 31, 104),
(374, 31, 107),
(375, 31, 112),
(376, 31, 113),
(377, 32, 90),
(378, 32, 99),
(379, 32, 101),
(380, 32, 107),
(381, 32, 110),
(382, 32, 116),
(383, 33, 89),
(384, 33, 99),
(385, 33, 102),
(386, 33, 108),
(387, 33, 109),
(388, 33, 114),
(389, 34, 90),
(390, 34, 99),
(391, 34, 104),
(392, 34, 106),
(393, 34, 111),
(394, 34, 113);

-- --------------------------------------------------------

--
-- Table structure for table `user_quiz_attempt`
--

DROP TABLE IF EXISTS `user_quiz_attempt`;
CREATE TABLE IF NOT EXISTS `user_quiz_attempt` (
  `id` int NOT NULL AUTO_INCREMENT,
  `user_id` int NOT NULL,
  `quiz_id` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `user_id` (`user_id`),
  KEY `quiz_id` (`quiz_id`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `user_quiz_attempt`
--

INSERT INTO `user_quiz_attempt` (`id`, `user_id`, `quiz_id`) VALUES
(1, 5, 1),
(2, 5, 1),
(3, 5, 1),
(4, 5, 1),
(5, 5, 1),
(6, 5, 1),
(7, 5, 1),
(8, 5, 1),
(9, 5, 1),
(10, 5, 1),
(11, 5, 1),
(12, 5, 1),
(13, 5, 1),
(14, 5, 1),
(15, 5, 1),
(16, 5, 2),
(17, 5, 2),
(18, 5, 2),
(19, 5, 1),
(20, 5, 1),
(21, 5, 1),
(22, 5, 1),
(23, 5, 1),
(24, 5, 1),
(25, 5, 1),
(26, 5, 1),
(27, 5, 1),
(28, 5, 1),
(29, 5, 1),
(31, 15, 16),
(32, 16, 16),
(33, 17, 16),
(34, 18, 16);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `answer`
--
ALTER TABLE `answer`
  ADD CONSTRAINT `answer_ibfk_1` FOREIGN KEY (`question_id`) REFERENCES `question` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `question`
--
ALTER TABLE `question`
  ADD CONSTRAINT `question_ibfk_1` FOREIGN KEY (`quiz_id`) REFERENCES `quiz` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `quiz`
--
ALTER TABLE `quiz`
  ADD CONSTRAINT `quiz_ibfk_1` FOREIGN KEY (`created_by`) REFERENCES `user` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `user_quiz_answer`
--
ALTER TABLE `user_quiz_answer`
  ADD CONSTRAINT `user_quiz_answer_ibfk_1` FOREIGN KEY (`user_quiz_attempt_id`) REFERENCES `user_quiz_attempt` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `user_quiz_answer_ibfk_2` FOREIGN KEY (`answer_id`) REFERENCES `answer` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `user_quiz_attempt`
--
ALTER TABLE `user_quiz_attempt`
  ADD CONSTRAINT `user_quiz_attempt_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `user` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `user_quiz_attempt_ibfk_2` FOREIGN KEY (`quiz_id`) REFERENCES `quiz` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
