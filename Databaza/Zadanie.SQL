/*
Created: 17. 08. 2021
Modified: 18. 08. 2021
Model: Microsoft SQL Server 2019
Database: MS SQL Server 2019
*/


-- Create tables section -------------------------------------------------

-- Table Zamestnanec

CREATE TABLE Zamestnanec
(
 id_zamestnanec Int NOT NULL,
 id_oddelenie Int NULL,
 titul Varchar(5) NULL,
 meno Varchar(15) NOT NULL,
 priezvisko Varchar(30) NOT NULL,
 mobil Varchar(15) NOT NULL,
 email Varchar(320) NOT NULL
)
go

-- Create indexes for table Zamestnanec

CREATE INDEX IX_Relationship13 ON Zamestnanec (id_oddelenie)
go

-- Add keys for table Zamestnanec

ALTER TABLE Zamestnanec ADD CONSTRAINT PK_Zamestnanec PRIMARY KEY (id_zamestnanec)
go

-- Table Oddelenie

CREATE TABLE Oddelenie
(
 id_oddelenie Int NOT NULL,
 id_ved_oddelenia Int NOT NULL,
 id_projekt Int NOT NULL,
 nazov Varchar(100) NULL
)
go

-- Create indexes for table Oddelenie

CREATE INDEX IX_Relationship6 ON Oddelenie (id_projekt)
go

CREATE INDEX IX_Relationship12 ON Oddelenie (id_ved_oddelenia)
go

-- Add keys for table Oddelenie

ALTER TABLE Oddelenie ADD CONSTRAINT PK_Oddelenie PRIMARY KEY (id_oddelenie)
go

-- Table Projekt

CREATE TABLE Projekt
(
 id_projekt Int NOT NULL,
 id_divizia Int NOT NULL,
 id_ved_projekt Int NOT NULL,
 nazov Varchar(100) NULL
)
go

-- Create indexes for table Projekt

CREATE INDEX IX_Relationship5 ON Projekt (id_divizia)
go

CREATE INDEX IX_Relationship11 ON Projekt (id_ved_projekt)
go

-- Add keys for table Projekt

ALTER TABLE Projekt ADD CONSTRAINT PK_Projekt PRIMARY KEY (id_projekt)
go

-- Table Divizia

CREATE TABLE Divizia
(
 id_divizia Int NOT NULL,
 id_firma Int NOT NULL,
 id_ved_divizie Int NOT NULL,
 nazov Varchar(100) NULL
)
go

-- Create indexes for table Divizia

CREATE INDEX IX_Relationship4 ON Divizia (id_firma)
go

CREATE INDEX IX_Relationship10 ON Divizia (id_ved_divizie)
go

-- Add keys for table Divizia

ALTER TABLE Divizia ADD CONSTRAINT PK_Divizia PRIMARY KEY (id_divizia)
go

-- Table Firma

CREATE TABLE Firma
(
 id_firma Int NOT NULL,
 id_veduci Int NOT NULL,
 nazov Varchar(100) NULL
)
go

-- Create indexes for table Firma

CREATE INDEX IX_Relationship9 ON Firma (id_veduci)
go

-- Add keys for table Firma

ALTER TABLE Firma ADD CONSTRAINT PK_Firma PRIMARY KEY (id_firma)
go





-- Create foreign keys (relationships) section ------------------------------------------------- 


ALTER TABLE Divizia ADD CONSTRAINT Relationship4 FOREIGN KEY (id_firma) REFERENCES Firma (id_firma) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE Projekt ADD CONSTRAINT Relationship5 FOREIGN KEY (id_divizia) REFERENCES Divizia (id_divizia) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE Oddelenie ADD CONSTRAINT Relationship6 FOREIGN KEY (id_projekt) REFERENCES Projekt (id_projekt) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE Firma ADD CONSTRAINT Relationship9 FOREIGN KEY (id_veduci) REFERENCES Zamestnanec (id_zamestnanec) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE Divizia ADD CONSTRAINT Relationship10 FOREIGN KEY (id_ved_divizie) REFERENCES Zamestnanec (id_zamestnanec) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE Projekt ADD CONSTRAINT Relationship11 FOREIGN KEY (id_ved_projekt) REFERENCES Zamestnanec (id_zamestnanec) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE Oddelenie ADD CONSTRAINT Relationship12 FOREIGN KEY (id_ved_oddelenia) REFERENCES Zamestnanec (id_zamestnanec) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE Zamestnanec ADD CONSTRAINT Relationship13 FOREIGN KEY (id_oddelenie) REFERENCES Oddelenie (id_oddelenie) ON UPDATE NO ACTION ON DELETE NO ACTION
go



