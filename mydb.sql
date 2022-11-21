-- MySQL Script generated by MySQL Workbench
-- Sun Nov 20 13:29:13 2022
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb_kokurin
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema mydb_kokurin
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb_kokurin` DEFAULT CHARACTER SET utf8 ;
USE `mydb_kokurin` ;

-- -----------------------------------------------------
-- Table `mydb_kokurin`.`speciality`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb_kokurin`.`speciality` (
  `code` VARCHAR(10) NOT NULL,
  `spec_name` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`code`),
  UNIQUE INDEX `code_UNIQUE` (`code` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb_kokurin`.`group`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb_kokurin`.`group` (
  `group_name` VARCHAR(10) NOT NULL,
  `code` VARCHAR(10) NOT NULL,
  PRIMARY KEY (`group_name`),
  UNIQUE INDEX `group_name_UNIQUE` (`group_name` ASC) VISIBLE,
  INDEX `code_idx` (`code` ASC) VISIBLE,
  CONSTRAINT `code`
    FOREIGN KEY (`code`)
    REFERENCES `mydb_kokurin`.`speciality` (`code`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb_kokurin`.`student`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb_kokurin`.`student` (
  `student_tk` INT NOT NULL AUTO_INCREMENT,
  `st_surname` VARCHAR(50) NOT NULL,
  `st_name` VARCHAR(50) NOT NULL,
  `st_pt` VARCHAR(50) NOT NULL,
  `group_name` VARCHAR(10) NOT NULL,
  PRIMARY KEY (`student_tk`),
  INDEX `group_name_idx` (`group_name` ASC) VISIBLE,
  CONSTRAINT `group_name`
    FOREIGN KEY (`group_name`)
    REFERENCES `mydb_kokurin`.`group` (`group_name`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb_kokurin`.`users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb_kokurin`.`users` (
  `id_usr` INT NOT NULL AUTO_INCREMENT,
  `name_usr` VARCHAR(45) NOT NULL,
  `login_usr` VARCHAR(45) NOT NULL,
  `pwd_usr` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id_usr`),
  UNIQUE INDEX `id_usr_UNIQUE` (`id_usr` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb_kokurin`.`teacher`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb_kokurin`.`teacher` (
  `id_tc` INT NOT NULL AUTO_INCREMENT,
  `tc_surname` VARCHAR(50) NOT NULL,
  `tc_name` VARCHAR(50) NOT NULL,
  `tc_pt` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id_tc`),
  UNIQUE INDEX `id_tc_UNIQUE` (`id_tc` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb_kokurin`.`subject`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb_kokurin`.`subject` (
  `code` INT NOT NULL AUTO_INCREMENT,
  `sub_name` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`code`),
  UNIQUE INDEX `code_UNIQUE` (`code` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb_kokurin`.`timetable`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb_kokurin`.`timetable` (
  `idtimetable` INT NOT NULL AUTO_INCREMENT,
  `pair_num` INT NOT NULL,
  `date` VARCHAR(45) NOT NULL,
  `group_n` VARCHAR(10) NOT NULL,
  `code_sub` INT NOT NULL,
  `idteacher` INT NOT NULL,
  PRIMARY KEY (`idtimetable`),
  INDEX `group_name_idx` (`group_n` ASC) VISIBLE,
  INDEX `code_idx` (`code_sub` ASC) VISIBLE,
  INDEX `idteacher_idx` (`idteacher` ASC) VISIBLE,
  CONSTRAINT `group_n`
    FOREIGN KEY (`group_n`)
    REFERENCES `mydb_kokurin`.`group` (`group_name`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `code_sub`
    FOREIGN KEY (`code_sub`)
    REFERENCES `mydb_kokurin`.`subject` (`code`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `idteacher`
    FOREIGN KEY (`idteacher`)
    REFERENCES `mydb_kokurin`.`teacher` (`id_tc`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
