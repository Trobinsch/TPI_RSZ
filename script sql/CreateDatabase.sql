DROP DATABASE IF EXISTS `E-Banking`;
CREATE DATABASE IF NOT EXISTS `E-Banking`; 
USE `E-Banking`;
timbreuse
CREATE TABLE `Users` (
	`IdUser` INT UNSIGNED NOT NULL AUTO_INCREMENT,
	`Name` VARCHAR(50) NOT NULL,
	`Password` VARCHAR(30) NOT NULL,
	PRIMARY KEY (`IdUser`),
	UNIQUE INDEX `Name` (`Name`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=UTF8MB4;

CREATE TABLE `Accounts` (
	`IdAccount` INT UNSIGNED NOT NULL AUTO_INCREMENT,
	`AccountNumber` VARCHAR(50) NOT NULL,
	`Amount` VARCHAR(12) NOT NULL,
	PRIMARY KEY (`IdAccount`),
	UNIQUE INDEX `AccountNumber` (`AccountNumber`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=UTF8MB4;

CREATE TABLE `Payments` (
	`IdPayment` INT UNSIGNED NOT NULL AUTO_INCREMENT,
	`FkidAccount` INT UNSIGNED NOT NULL,
	`AccountNumber_owner` VARCHAR(9) NOT NULL,
	`AccountNumber_recipient` VARCHAR(9) NOT NULL,
	`Amount` int(10) NOT NULL,
	`Date` date NOT NULL,
	`information` VARCHAR(100) NOT NULL,
	`personal information` VARCHAR(350) NOT NULL,
	PRIMARY KEY (`idPayment`),
    FOREIGN KEY (`FkidAccount`) REFERENCES `E-Banking`.`Accounts`(`IdAccount`),
	FOREIGN KEY (`AccountNumber_owner`) REFERENCES `E-Banking`.`Accounts`(`AccountNumber`),
	FOREIGN KEY (`AccountNumber_recipient`) REFERENCES `E-Banking`.`Accounts`(`AccountNumber`)		
	) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=UTF8MB4;