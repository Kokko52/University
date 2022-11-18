CREATE DATABASE  IF NOT EXISTS `university` /*!40100 DEFAULT CHARACTER SET utf8 COLLATE utf8_estonian_ci */;
USE `university`;
-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: university
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
  `group_name` varchar(45) COLLATE utf8_estonian_ci NOT NULL,
  `speciality_name` varchar(50) COLLATE utf8_estonian_ci NOT NULL,
  PRIMARY KEY (`group_name`),
  KEY `special_idx` (`speciality_name`),
  CONSTRAINT `special` FOREIGN KEY (`speciality_name`) REFERENCES `speciality` (`speciality_name`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_estonian_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `group`
--

LOCK TABLES `group` WRITE;
/*!40000 ALTER TABLE `group` DISABLE KEYS */;
INSERT INTO `group` VALUES ('АТ-19А','Автомобиле-тракторо строение'),('АТ-19Б','Автомобиле-тракторо строение'),('АС-21А','Автослесарь'),('БД-22Б','Банковское дело'),('БИ-21А','Биолог'),('БУ-19Б','Бухгалтер'),('БУ-22А','Бухгалтер'),('ВН-19А','Врач-невролог'),('ИД-20Б','Инженерное дело'),('ПС-20А','Программист'),('ПС-20Б','Программист'),('ПС-29А','Программист'),('СВ-19А','Сварщик'),('СТ-22Б','Стилист'),('ТМ-22Б','Технология машиностроения'),('ЭО-20А','Электрик');
/*!40000 ALTER TABLE `group` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `speciality`
--

DROP TABLE IF EXISTS `speciality`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `speciality` (
  `speciality_name` varchar(45) COLLATE utf8_estonian_ci NOT NULL,
  PRIMARY KEY (`speciality_name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_estonian_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `speciality`
--

LOCK TABLES `speciality` WRITE;
/*!40000 ALTER TABLE `speciality` DISABLE KEYS */;
INSERT INTO `speciality` VALUES ('Автомобиле-тракторо строение'),('Автослесарь'),('Банковское дело'),('Биолог'),('Бухгалтер'),('Дизайнер'),('Инженерное дело'),('Медицинское дело'),('Повар'),('Программист'),('Сварщик'),('Стилист'),('Технология машиностроения'),('Физик'),('Экономист'),('Электрик');
/*!40000 ALTER TABLE `speciality` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `student`
--

DROP TABLE IF EXISTS `student`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `student` (
  `student_ticket` int(11) NOT NULL AUTO_INCREMENT,
  `student_surname` varchar(100) COLLATE utf8_estonian_ci NOT NULL,
  `student_name` varchar(45) COLLATE utf8_estonian_ci NOT NULL,
  `student_patronymic` varchar(100) COLLATE utf8_estonian_ci NOT NULL,
  `group_name` varchar(50) COLLATE utf8_estonian_ci NOT NULL,
  PRIMARY KEY (`student_ticket`),
  UNIQUE KEY `student_ticket_UNIQUE` (`student_ticket`),
  KEY `groupn_idx` (`group_name`),
  CONSTRAINT `groupn` FOREIGN KEY (`group_name`) REFERENCES `group` (`group_name`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=128 DEFAULT CHARSET=utf8 COLLATE=utf8_estonian_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `student`
--

LOCK TABLES `student` WRITE;
/*!40000 ALTER TABLE `student` DISABLE KEYS */;
INSERT INTO `student` VALUES (111,'Кокурин','Егор','Алексеевич','ПС-20Б'),(112,'Овчинников','Дмитрий','Олегович','ПС-20Б'),(113,'Красильников','Елисей','Олегович','АТ-19Б'),(114,'Пестов','Гордей','Георгиевич','ВН-19А'),(115,'Трофимов ','Кирилл','Алексеевич','СВ-19А'),(116,'Лобанов','Иван','Андреевич','ЭО-20А'),(117,'Стрелков','Макар','Артемович','АТ-19Б'),(118,'Павлов','Роберт','Георгиевич','БУ-19Б'),(119,'Емельянова','Эмма','Артемовна','ИД-20Б'),(120,'Потапова','Влада','Алексеевна','БД-22Б'),(121,'Фролова ','Мария','Алексеевна','БД-22Б'),(122,'Комарова','Ангелина','Федотовна','БИ-21А'),(123,'Быкова','Екатерина','Артемовна','ПС-20А'),(124,'Сазонова','Кира','Егоровна','ВН-19А'),(125,'Тарасова',' Яна','Максовна','ВН-19А'),(126,'Голубева','Луиза','Максовна','АТ-19Б'),(127,'Копылова','Мартина','Андреевна','ТМ-22Б');
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
  `subject_name` varchar(50) COLLATE utf8_estonian_ci NOT NULL,
  PRIMARY KEY (`code`),
  UNIQUE KEY `code_UNIQUE` (`code`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8 COLLATE=utf8_estonian_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subject`
--

LOCK TABLES `subject` WRITE;
/*!40000 ALTER TABLE `subject` DISABLE KEYS */;
INSERT INTO `subject` VALUES (1,'Математика'),(2,'Физическая культура'),(3,'ОБЖ'),(4,'Философия'),(5,'Психология'),(6,'Информатика'),(7,'История'),(8,'МДК 01.01'),(9,'МДК 02.02'),(10,'МДК 01.02'),(11,'Экономика'),(12,'1С Бухгалтерия'),(13,'Финансовый анализ'),(14,'Биология'),(15,'Физика'),(16,'Техническая механика'),(17,'Электротехника'),(18,'Инженерная графика');
/*!40000 ALTER TABLE `subject` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `teacher`
--

DROP TABLE IF EXISTS `teacher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `teacher` (
  `idteacher` int(11) NOT NULL AUTO_INCREMENT,
  `teacher_surname` varchar(100) COLLATE utf8_estonian_ci NOT NULL,
  `teacher_name` varchar(50) COLLATE utf8_estonian_ci NOT NULL,
  `teacher_patronymic` varchar(100) COLLATE utf8_estonian_ci NOT NULL,
  PRIMARY KEY (`idteacher`),
  UNIQUE KEY `idteacher_UNIQUE` (`idteacher`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8 COLLATE=utf8_estonian_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teacher`
--

LOCK TABLES `teacher` WRITE;
/*!40000 ALTER TABLE `teacher` DISABLE KEYS */;
INSERT INTO `teacher` VALUES (1,'Корнилов','Михаил','Андреевна'),(2,'Григорьев','Игорь','Германновна'),(3,'Ларионов','Эльдар','Богдановна'),(4,'Фомичева','Мария','Еремеевна'),(5,'Степанов','Алексей','Игоревна'),(6,'Князев','Анатолий','Егоровна'),(7,'Чернов','Игорь','Фроловна'),(8,'Шубина','Татьяна','Артемовна'),(9,'Комиссарова','Алёна','Владиславовна'),(10,'Захарова','Тамара','Тарасовна'),(11,'Фокина','Таисия','Львовна'),(12,'Лазарева','Амина ','Глебовна'),(13,'Григорьева','Юлия','Алексеевна'),(14,'Матвеева','Мария','Дмитриевна'),(15,'Кузьмина','Карина','Юрьевна');
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
  `pair_number` int(11) NOT NULL,
  `date` varchar(45) COLLATE utf8_estonian_ci NOT NULL,
  `group_name` varchar(50) COLLATE utf8_estonian_ci NOT NULL,
  `code` int(11) NOT NULL,
  `idteacher` int(11) NOT NULL,
  PRIMARY KEY (`idtimetable`),
  UNIQUE KEY `idtimetable_UNIQUE` (`idtimetable`),
  KEY `sub_idx` (`code`),
  KEY `teacher_idx` (`idteacher`),
  KEY `gropname_idx` (`group_name`),
  CONSTRAINT `gropname` FOREIGN KEY (`group_name`) REFERENCES `group` (`group_name`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `subject` FOREIGN KEY (`code`) REFERENCES `subject` (`code`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `teacher` FOREIGN KEY (`idteacher`) REFERENCES `teacher` (`idteacher`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8 COLLATE=utf8_estonian_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `timetable`
--

LOCK TABLES `timetable` WRITE;
/*!40000 ALTER TABLE `timetable` DISABLE KEYS */;
INSERT INTO `timetable` VALUES (1,1,'20.12.2022','АТ-19А',1,1),(2,2,'20.12.2022','АТ-19А',2,2),(3,3,'20.12.2022','АТ-19А',3,5),(4,1,'20.12.2022','БИ-21А',3,5),(5,2,'20.12.2022','БИ-21А',5,2),(6,3,'20.12.2022','БИ-21А',10,15),(7,1,'20.12.2022','ПС-29А',7,9),(8,2,'20.12.2022','ПС-29А',8,13),(9,3,'20.12.2022','ПС-29А',15,8),(10,1,'20.12.2022','СТ-22Б',6,9),(11,2,'20.12.2022','СТ-22Б',6,9),(12,3,'20.12.2022','СТ-22Б',8,3),(13,1,'20.12.2022','ЭО-20А',14,4),(14,2,'20.12.2022','ЭО-20А',12,6),(15,3,'20.12.2022','ЭО-20А',1,1),(16,1,'20.12.2022','ИД-20Б',6,9),(17,2,'20.12.2022','ИД-20Б',4,10),(18,3,'20.12.2022','ИД-20Б',3,5);
/*!40000 ALTER TABLE `timetable` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `idusers` int(11) NOT NULL AUTO_INCREMENT,
  `users_name` varchar(100) COLLATE utf8_estonian_ci NOT NULL,
  `users_login` varchar(50) COLLATE utf8_estonian_ci NOT NULL,
  `users_pwd` varchar(45) COLLATE utf8_estonian_ci NOT NULL,
  `users_privilege` varchar(45) COLLATE utf8_estonian_ci NOT NULL,
  PRIMARY KEY (`idusers`),
  UNIQUE KEY `idusers_UNIQUE` (`idusers`)
) ENGINE=InnoDB AUTO_INCREMENT=106 DEFAULT CHARSET=utf8 COLLATE=utf8_estonian_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (2,'Овечкин А.А.','ovechkin','ovechkin','user'),(3,'Петров П.П.','petrov','petrov','user'),(4,'Аверина А.А.','averina','averina','user'),(5,'Администратор','admin','admin','admin'),(6,'Кокурин Е.А.','kokurin','kokurin','user');
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

-- Dump completed on 2022-11-18 15:25:31
