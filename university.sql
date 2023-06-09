-- MySQL Script generated by MySQL Workbench
-- Thu Nov 17 17:50:32 2022
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema university
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema university
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `university` DEFAULT CHARACTER SET utf8 COLLATE utf8_estonian_ci ;
USE `university` ;

-- -----------------------------------------------------
-- Table `university`.`speciality`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`speciality` (
  `speciality_name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`speciality_name`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `university`.`group`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`group` (
  `group_name` VARCHAR(45) NOT NULL,
  `speciality_name` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`group_name`),
  INDEX `special_idx` (`speciality_name` ASC),
  CONSTRAINT `special`
    FOREIGN KEY (`speciality_name`)
    REFERENCES `university`.`speciality` (`speciality_name`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `university`.`student`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`student` (
  `student_ticket` INT NOT NULL AUTO_INCREMENT,
  `student_surname` VARCHAR(100) NOT NULL,
  `student_name` VARCHAR(45) NOT NULL,
  `student_patronymic` VARCHAR(100) NOT NULL,
  `group_name` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`student_ticket`),
  UNIQUE INDEX `student_ticket_UNIQUE` (`student_ticket` ASC),
  INDEX `groupn_idx` (`group_name` ASC),
  CONSTRAINT `groupn`
    FOREIGN KEY (`group_name`)
    REFERENCES `university`.`group` (`group_name`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `university`.`subject`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`subject` (
  `code` INT NOT NULL AUTO_INCREMENT,
  `subject_name` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`code`),
  UNIQUE INDEX `code_UNIQUE` (`code` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `university`.`teacher`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`teacher` (
  `idteacher` INT NOT NULL AUTO_INCREMENT,
  `teacher_surname` VARCHAR(100) NOT NULL,
  `teacher_name` VARCHAR(50) NOT NULL,
  `teacher_patronymic` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`idteacher`),
  UNIQUE INDEX `idteacher_UNIQUE` (`idteacher` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `university`.`timetable`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`timetable` (
  `idtimetable` INT NOT NULL AUTO_INCREMENT,
  `pair_number` INT NOT NULL,
  `date` VARCHAR(45) NOT NULL,
  `group_name` VARCHAR(50) NOT NULL,
  `code` INT NOT NULL,
  `idteacher` INT NOT NULL,
  PRIMARY KEY (`idtimetable`),
  UNIQUE INDEX `idtimetable_UNIQUE` (`idtimetable` ASC),
  INDEX `sub_idx` (`code` ASC),
  INDEX `teacher_idx` (`idteacher` ASC),
  INDEX `gropname_idx` (`group_name` ASC),
  CONSTRAINT `subject`
    FOREIGN KEY (`code`)
    REFERENCES `university`.`subject` (`code`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `teacher`
    FOREIGN KEY (`idteacher`)
    REFERENCES `university`.`teacher` (`idteacher`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `gropname`
    FOREIGN KEY (`group_name`)
    REFERENCES `university`.`group` (`group_name`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `university`.`users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`users` (
  `idusers` INT NOT NULL AUTO_INCREMENT,
  `users_name` VARCHAR(100) NOT NULL,
  `users_login` VARCHAR(50) NOT NULL,
  `users_pwd` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idusers`),
  UNIQUE INDEX `idusers_UNIQUE` (`idusers` ASC))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
