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
-- Table structure for table `тест №1. основы c sharp.`
--

DROP TABLE IF EXISTS `тест №1. основы c sharp.`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `тест №1. основы c sharp.` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `question` longtext NOT NULL,
  `answers` longtext NOT NULL,
  `good_answer` longtext NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `тест №1. основы c sharp.`
--

LOCK TABLES `тест №1. основы c sharp.` WRITE;
/*!40000 ALTER TABLE `тест №1. основы c sharp.` DISABLE KEYS */;
INSERT INTO `тест №1. основы c sharp.` VALUES (1,'Какой тип переменной используется в коде: int a = 5','1 байт;Знаковое 32-бит целое;Знаковое 64-бит целое;Знаковое8-бит целое¯','1'),(2,'Чему будет равен с, если int a = 10, int b = 4, int c = a % b','1;3;11;2¯','3'),(3,'Обозначение оператора «ИЛИ»','Or;!;||;!=¯','2'),(4,'Обозначения оператора «НЕ»','Not;!=;!;No¯','2'),(5,'Как найти квадратный корень из числа x','Sqrt(x);Arifmetic.sqrt;Summ.Koren(x);Math.Sqrt(x)¯','3'),(6,'Как сделать декрементация числа','++;—;%%;!=¯','1'),(7,'Как сделать инкрементацию числа','++;—;%%;!=¯','0'),(8,'Что сделает программа выполнив следующий код: Console.WriteLine(«Hello, World!»)','Вырежет слово Hello, World! из всего текста;Удалит все значения с Hello, World!;Напишет Hello, World!;Напишет на новой строчке Hello, World!¯','3'),(9,'Что делает оператор «%»','Возвращает процент от суммы;Возвращает тригонометрическую функцию;Возвращает остаток от деления;Ни чего из выше перечисленного¯','2'),(10,'Чему будет равен с, если int a = 0, int c = a—','1;Null;-1;0¯','2'),(11,'Чему будет равен с, если int a = 0, int c = —a','1;0;-1;Null¯','1'),(12,'Чему равен d, если int a = 0, int b = a++, int c = 0,  int d = a + b + c + 3','4;False;True;3l¯','0'),(13,'Для чего нужны условные операторы','Чтобы устанавливать условия пользователю;Чтобы были;Для оптимизации программы;Для ветвления программы¯','3'),(14,'Что вернет функция Termin после выполения. Код:int Termin(){int a = 1 int b = 3 if (a != 5) return a + b else return 0}','4;5;3;0¯','0'),(15,'Что такое массив','Набор однотипных данных, которые располагаются в памяти последовательно друг за другом;Набор текстовых значений в формате Unicode, которые расположены в случайном порядке;Набор данных типа int (32-бит целое);Переменная¯','0'),(16,'Какие бывают массивы ?','Разнообразные;Резиновые и статичные;Сложные и простые;Одномерные и многомерные¯','3'),(17,'Что такое цикл и для чего они нужны','Циклы нужны для многократного выполнения кода;Циклы нужны для многократного запуска программы;Циклы нужны для многократного размещения данных;Циклы нужны чтобы выполнить код без ошибок¯','0'),(18,'Какие бывают циклы?','Большие и маленькие;Цикл, Форич, Двойной цикл, Многократный;for, while, do-while, foreach;ref, out, static, root¯','2'),(19,'Чему будет равен с, если int a = 10  int b = 4  bool c = (a == 10 && b == 4)','14;Null;False;True¯','3'),(20,'Обозначение оператора «И»','&&;and;|;Все выше перечисленные¯','0');
/*!40000 ALTER TABLE `тест №1. основы c sharp.` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-03-22 22:52:25
