CREATE DATABASE  IF NOT EXISTS `mydb_kokurin` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `mydb_kokurin`;
-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: mydb_kokurin
-- ------------------------------------------------------
-- Server version	5.7.39

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `group`
--

DROP TABLE IF EXISTS `group`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `group` (
  `group_name` varchar(10) NOT NULL,
  `code` varchar(10) NOT NULL,
  PRIMARY KEY (`group_name`),
  UNIQUE KEY `group_name_UNIQUE` (`group_name`),
  KEY `code_idx` (`code`),
  CONSTRAINT `code` FOREIGN KEY (`code`) REFERENCES `speciality` (`code`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `group`
--

LOCK TABLES `group` WRITE;
/*!40000 ALTER TABLE `group` DISABLE KEYS */;
INSERT INTO `group` VALUES ('КР-22А','08.01.04'),('КС-20Б','09.02.02'),('ПС-20Б','09.02.03'),('ПС-21Б','09.02.03'),('ИС-22Б','09.02.07'),('РМ-19А','11.01.02'),('ТМ-19А','15.02.08'),('ЭО-20А','38.02.01'),('БД-21А','38.02.07'),('БД-21Б','38.02.07'),('ПД-22Б','43.02.15'),('ПК-18А','43.02.15');
/*!40000 ALTER TABLE `group` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `speciality`
--

DROP TABLE IF EXISTS `speciality`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `speciality` (
  `code` varchar(10) NOT NULL,
  `spec_name` varchar(100) NOT NULL,
  PRIMARY KEY (`code`),
  UNIQUE KEY `code_UNIQUE` (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `speciality`
--

LOCK TABLES `speciality` WRITE;
/*!40000 ALTER TABLE `speciality` DISABLE KEYS */;
INSERT INTO `speciality` VALUES ('08.01.04','Кровельщик'),('09.02.02','Компьютерные сети'),('09.02.03','Программирование в компьютерных системах'),('09.02.07','Информационные системы и программирование'),('09.03.01','Информатика и вычислительная техника'),('11.01.02','Радиомеханик'),('15.00.00','Машиностроение'),('15.01.30','Слесарь'),('15.02.08','Технология машиностроения'),('19.01.04','Пекарь'),('23.02.02','Автомобиле – и тракторостроение'),('23.02.03','Техническое обслуживание и ремонт автомобильного транспорта'),('38.02.01','Экономика и бухгалтерский учет (по отраслям)'),('38.02.07','Банковское дело'),('43.02.15','Поварское и кондитерское дело');
/*!40000 ALTER TABLE `speciality` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `student`
--

DROP TABLE IF EXISTS `student`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `student` (
  `student_tk` int(11) NOT NULL AUTO_INCREMENT,
  `st_surname` varchar(50) NOT NULL,
  `st_name` varchar(50) NOT NULL,
  `st_pt` varchar(50) NOT NULL,
  `group_name` varchar(10) NOT NULL,
  PRIMARY KEY (`student_tk`),
  KEY `group_name_idx` (`group_name`),
  CONSTRAINT `group_name` FOREIGN KEY (`group_name`) REFERENCES `group` (`group_name`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=119 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `student`
--

LOCK TABLES `student` WRITE;
/*!40000 ALTER TABLE `student` DISABLE KEYS */;
INSERT INTO `student` VALUES (111,'Кокурин','Егор','Алексеевич','ПС-20Б'),(112,'Курочкин','Алексей','Сергеевич','ЭО-20А'),(113,'Комаров','Илья','Владимирович','ТМ-19А'),(114,'Жеглова','Мария','Викторовна','БД-21А'),(115,'Аверина','Арина','Дмитриевна','БД-21Б'),(116,'Власова','Карина','Сергеевна','БД-21Б'),(117,'Каргин','Данила','Сергеевич','ИС-22Б'),(118,'Моржаков','Виктор','Сергеевич','РМ-19А');
/*!40000 ALTER TABLE `student` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subject`
--

DROP TABLE IF EXISTS `subject`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subject` (
  `code` int(11) NOT NULL AUTO_INCREMENT,
  `sub_name` varchar(100) NOT NULL,
  PRIMARY KEY (`code`),
  UNIQUE KEY `code_UNIQUE` (`code`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subject`
--

LOCK TABLES `subject` WRITE;
/*!40000 ALTER TABLE `subject` DISABLE KEYS */;
INSERT INTO `subject` VALUES (1,'Математика'),(2,'Физика'),(3,'МДК 02.02. Технология разработки защиты баз данных'),(4,'ТВиМС'),(5,'МДК 01.01 Системное программирование'),(6,'БЖД'),(7,'Физическая культура'),(8,'МДК 03.02 Инструментальные средства разработки ПО'),(9,'Иностранный язык');
/*!40000 ALTER TABLE `subject` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `teacher`
--

DROP TABLE IF EXISTS `teacher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `teacher` (
  `id_tc` int(11) NOT NULL AUTO_INCREMENT,
  `tc_surname` varchar(50) NOT NULL,
  `tc_name` varchar(50) NOT NULL,
  `tc_pt` varchar(50) NOT NULL,
  PRIMARY KEY (`id_tc`),
  UNIQUE KEY `id_tc_UNIQUE` (`id_tc`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teacher`
--

LOCK TABLES `teacher` WRITE;
/*!40000 ALTER TABLE `teacher` DISABLE KEYS */;
INSERT INTO `teacher` VALUES (1,'Королев','Илья','Александрович'),(2,'Соколов','Дмитрий','Михайлович'),(3,'Иванов','Илья ','Александрович'),(4,'Арсенова','Ангелина','Викторовна'),(5,'Мокрушин','Алексей','Сергеевич'),(6,'Новиков','Никита','Андреевич');
/*!40000 ALTER TABLE `teacher` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `timetable`
--

DROP TABLE IF EXISTS `timetable`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `timetable` (
  `idtimetable` int(11) NOT NULL AUTO_INCREMENT,
  `pair_num` varchar(10) NOT NULL,
  `date` varchar(45) NOT NULL,
  `group_n` varchar(10) NOT NULL,
  `code_sub` int(11) NOT NULL,
  `idteacher` int(11) NOT NULL,
  PRIMARY KEY (`idtimetable`),
  UNIQUE KEY `idtimetable_UNIQUE` (`idtimetable`),
  KEY `group_name_idx` (`group_n`),
  KEY `code_idx` (`code_sub`),
  KEY `idteacher_idx` (`idteacher`),
  CONSTRAINT `code_sub` FOREIGN KEY (`code_sub`) REFERENCES `subject` (`code`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `group_n` FOREIGN KEY (`group_n`) REFERENCES `group` (`group_name`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `idteacher` FOREIGN KEY (`idteacher`) REFERENCES `teacher` (`id_tc`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `timetable`
--

LOCK TABLES `timetable` WRITE;
/*!40000 ALTER TABLE `timetable` DISABLE KEYS */;
INSERT INTO `timetable` VALUES (26,'1 пара','21.11.2022','ПС-20Б',1,3),(27,'2 пара','21.11.2022','ПС-20Б',8,3);
/*!40000 ALTER TABLE `timetable` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `id_usr` int(11) NOT NULL AUTO_INCREMENT,
  `name_usr` varchar(45) NOT NULL,
  `login_usr` varchar(45) NOT NULL,
  `pwd_usr` varchar(45) NOT NULL,
  `users_privilege` varchar(45) NOT NULL,
  PRIMARY KEY (`id_usr`),
  UNIQUE KEY `id_usr_UNIQUE` (`id_usr`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'admin','admin','admin','admin'),(2,'Кокурин Е.А.','koko','koko','user');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-11-22  1:02:43
