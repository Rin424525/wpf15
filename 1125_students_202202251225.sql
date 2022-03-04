--
-- Скрипт сгенерирован Devart dbForge Studio 2020 for MySQL, Версия 9.0.391.0
-- Домашняя страница продукта: http://www.devart.com/ru/dbforge/mysql/studio
-- Дата скрипта: 25.02.2022 12:25:31
-- Версия сервера: 5.5.28
-- Версия клиента: 4.1
--

-- 
-- Отключение внешних ключей
-- 
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;

-- 
-- Установить режим SQL (SQL mode)
-- 
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- 
-- Установка кодировки, с использованием которой клиент будет посылать запросы на сервер
--
SET NAMES 'utf8';

DROP DATABASE IF EXISTS `1125_students`;

CREATE DATABASE IF NOT EXISTS `1125_students`
CHARACTER SET utf8
COLLATE utf8_general_ci;

--
-- Установка базы данных по умолчанию
--
USE `1125_students`;

--
-- Создать таблицу `group`
--
CREATE TABLE IF NOT EXISTS `group` (
  id int(11) NOT NULL AUTO_INCREMENT,
  title varchar(255) DEFAULT NULL,
  year int(11) DEFAULT NULL,
  curator_id int(11) DEFAULT NULL,
  special_id int(11) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 12,
AVG_ROW_LENGTH = 2340,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Создать таблицу `student`
--
CREATE TABLE IF NOT EXISTS student (
  id int(11) NOT NULL AUTO_INCREMENT,
  firstName varchar(255) DEFAULT NULL,
  lastName varchar(255) DEFAULT NULL,
  patronymicName varchar(255) DEFAULT NULL,
  birthday date DEFAULT NULL,
  group_id int(11) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 7,
AVG_ROW_LENGTH = 4096,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Создать внешний ключ
--
ALTER TABLE student
ADD CONSTRAINT FK_student_group_id FOREIGN KEY (group_id)
REFERENCES `group` (id);

--
-- Создать таблицу `specials`
--
CREATE TABLE IF NOT EXISTS specials (
  id int(11) NOT NULL AUTO_INCREMENT,
  title varchar(255) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Создать таблицу `prepods`
--
CREATE TABLE IF NOT EXISTS prepods (
  id int(11) NOT NULL AUTO_INCREMENT,
  firstName varchar(255) DEFAULT NULL,
  lastName varchar(255) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Создать таблицу `journal`
--
CREATE TABLE IF NOT EXISTS journal (
  id int(11) NOT NULL AUTO_INCREMENT,
  discipline_id int(11) DEFAULT NULL,
  student_id int(11) DEFAULT NULL,
  day date DEFAULT NULL,
  value varchar(20) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Создать таблицу `discipline`
--
CREATE TABLE IF NOT EXISTS discipline (
  id int(11) NOT NULL AUTO_INCREMENT,
  title varchar(255) DEFAULT NULL,
  prepod_id int(11) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Создать таблицу `curator`
--
CREATE TABLE IF NOT EXISTS curator (
  id int(11) NOT NULL AUTO_INCREMENT,
  firstName varchar(255) DEFAULT NULL,
  lastName varchar(255) DEFAULT NULL,
  birthday varchar(255) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

-- 
-- Вывод данных для таблицы `group`
--
INSERT INTO `group` VALUES
(1, '1141', 2018, NULL, NULL),
(2, '1141', 2018, NULL, NULL),
(3, 'Тест', 2022, NULL, NULL),
(4, 'Тест', 2022, NULL, NULL),
(5, 'Тест', 2022, NULL, NULL),
(6, 'Новая группа', 2022, NULL, NULL),
(7, 'Новая группа', 2022, NULL, NULL);

-- 
-- Вывод данных для таблицы student
--
INSERT INTO student VALUES
(3, 'Ел ', 'Сергей', 'Пирожки', '2011-11-11', 1),
(4, 'фы', 'вфыв', 'ыфвфы', '2011-12-29', 3),
(5, 'asfasfasfas', 'safasfafaf', 'fasfasfas', '0001-01-01', 6),
(6, 'asdasdasd', 'asdasd', 'sadasdasd', '0001-01-01', 7);

-- 
-- Вывод данных для таблицы specials
--
-- Таблица `1125_students`.specials не содержит данных

-- 
-- Вывод данных для таблицы prepods
--
-- Таблица `1125_students`.prepods не содержит данных

-- 
-- Вывод данных для таблицы journal
--
-- Таблица `1125_students`.journal не содержит данных

-- 
-- Вывод данных для таблицы discipline
--
-- Таблица `1125_students`.discipline не содержит данных

-- 
-- Вывод данных для таблицы curator
--
-- Таблица `1125_students`.curator не содержит данных

-- 
-- Восстановить предыдущий режим SQL (SQL mode)
--
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;

-- 
-- Включение внешних ключей
-- 
/*!40014 SET FOREIGN_KEY_CHECKS = @OLD_FOREIGN_KEY_CHECKS */;