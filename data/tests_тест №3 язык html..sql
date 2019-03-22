CREATE DATABASE  IF NOT EXISTS `tests` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */;
USE `tests`;
-- MySQL dump 10.13  Distrib 8.0.13, for Win64 (x86_64)
--
-- Host: localhost    Database: tests
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
-- Table structure for table `тест №3 язык html.`
--

DROP TABLE IF EXISTS `тест №3 язык html.`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `тест №3 язык html.` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `question` longtext NOT NULL,
  `answers` longtext NOT NULL,
  `good_answer` longtext NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `тест №3 язык html.`
--

LOCK TABLES `тест №3 язык html.` WRITE;
/*!40000 ALTER TABLE `тест №3 язык html.` DISABLE KEYS */;
INSERT INTO `тест №3 язык html.` VALUES (1,'Атрибут text тега <bodу>','устанавливает цвет текста документа ;станавливает цвет гиперссылок при нажатии;станавливает цвет гиперссылок;станавливает цвет гиперссылок на которых вы уже побывали;фоновое изображение прокручиваться не будет¯','0'),(2,'Атрибут bgproperties=fixed тега <body> устанавливает','фоновое изображение прокручиваться не будет;устанавливает цвет текста документа;устанавливает цвет гиперссылок;устанавливает цвет гиперссылок на которых вы уже побывали;пределяет цвет еще не просмотренной ссылки¯','0'),(3,'В этом разделе располагается вся содержательная часть документа','<body> ;<lmg> ;<big>   ;<small>   ;<area>¯   ','0'),(4,'Какой тег определяет место, где помещается различная информация, не отображаемая в теле документа.','<head>  ;<а>;<font>   ;<body>    ;<html>¯','0'),(5,'Какой тег указывает программе просмотра страниц, что это HTML документ ','HTML>    ;/HTML/       ;\'HTML\'    ;\"HTML\"    ;I-HTML-I¯','0'),(6,'Как выглядит закрывающий тег HTML','</HTML> ;/HTML/ ;*;HTML*  ;\"/HTML\";\'-/HTMI -\'¯ ','0'),(7,'Тeг <!--...--> является - тегом ','комментария ;списка;графики;форматирования;логического форматирования¯','0'),(8,'Какой из перечисленных атрибутов относится к тегу <bodу>','bgcolor  ;href;sue ;width ;name¯','0'),(9,'Атрибут bgcolor определяет','цвет фона   ;цвет текста   ;цвет ссылки ;цветскролинга ;цвет рамки¯','0'),(10,'Атрибут face относится к тегу','<font>    ;<head>   ;<а>   ;<body>   ;<html>¯','0'),(11,'Какой из перечисленных атрибутов относится к тегу <font>','size  ;border  ;bgcolor   ;width ;align¯','0'),(12,'Teг <font>','определяет выводимый шрифт, его цвет и размер ;рисует рамку вокруг текста и других объектов;создает плавающее окно;создает переключатель;выделяет чувствительную область¯','0'),(13,'Размер текста в теге <font> размещается в пределе','от 1 до7  ;от 4 до     ;от 2 до 3   ;от 8 до 9   ;от З до5¯','0'),(14,'Для создания подчеркнутого текста служит тег','<U>     ;<B>     ;<A>     ;<I>     ;<S>¯','0'),(15,'Для написания текста курсивом служит тег','<I>         ;<В>      ;<А>     ;<U>;<S>¯','0'),(16,'Для создания в тексте эффекта жирности служит тег','<B>      ;<U>    ;<A>     ;< I >      ;<S>¯','0'),(17,'Какой тег указывает, что текст должен быть зачеркнутым','<S>;<В>      ;<А>     ;< I >      ;<U> ¯   ','0'),(18,'Какой тег выводит текст более крупным','<big>   ;<center>   ;<агеа>    ;<small>    ;<body>¯','0'),(19,'Для перевода текста на новую строку используется тег','<br> ;<bling> ;<big> ;<body>;<area>¯','0'),(20,'Этот тег используется для выделения, подчеркивания важных фрагментов текста курсивом','<EM>;<U> ;<UL>    ;<OL>     ;<DD>¯    ','0');
/*!40000 ALTER TABLE `тест №3 язык html.` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-03-22 22:52:26
