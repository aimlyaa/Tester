CREATE DATABASE  IF NOT EXISTS `grps` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */;
USE `grps`;
-- MySQL dump 10.13  Distrib 8.0.13, for Win64 (x86_64)
--
-- Host: localhost    Database: grps
-- ------------------------------------------------------
-- Server version	8.0.13

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `551`
--

DROP TABLE IF EXISTS `551`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `551` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` tinytext NOT NULL,
  `password` tinytext,
  `token` tinytext,
  `result %` tinytext,
  `result` tinytext,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `551`
--

LOCK TABLES `551` WRITE;
/*!40000 ALTER TABLE `551` DISABLE KEYS */;
INSERT INTO `551` VALUES (1,'Малащук Максим Александрович',NULL,'NLJKHPCUXBOOYRPZHUSSPOHNPOYKTJEW',NULL,NULL),(3,'Рябых Сергей Эдуардович',NULL,'EPTKRNEZNWDUKQFSOQBDOPEFRJWJHSYS',NULL,NULL),(4,'Репников Никита Сергеевич',NULL,'MVWBTEUHEPDMODSELCEUBNXSHAOIGYUZ',NULL,NULL),(5,'Мельниченко Александр Александрович',NULL,NULL,NULL,NULL),(6,'Костин Богдан Александрович',NULL,'YQFSXJUKTOIICIJCBPBQNCUBSZHSBPHA',NULL,NULL),(7,'Карпов Артем Александрович',NULL,'KKPHSYJNYGLZKFOFIDWKOSTYSRZHBITZ',NULL,NULL),(8,'Миронова Елизовета Александровна',NULL,NULL,NULL,NULL),(9,'Видина Елена Александровна',NULL,'BTKCUUZWBTDSLJGWGALGJNOPPHGJVEWM',NULL,NULL),(10,'Григорьева Александра Александровна',NULL,NULL,NULL,NULL),(11,'Барабой Димитрий Александрович',NULL,'HWYXCSRTOQXYKYEQRXKMWETMELCFWCJB',NULL,NULL);
/*!40000 ALTER TABLE `551` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-03-22 22:52:24
