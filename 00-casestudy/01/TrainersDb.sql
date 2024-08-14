CREATE DATABASE TrainersDb;
USE TrainersDb;
CREATE TABLE Trainers(Id int PRIMARY KEY IDENTITY(1,1), Name nvarchar(255), Place nvarchar(255), Skill nvarchar(255));
INSERT INTO Trainers (Name, Place, Skill) VALUES ('Mahesh', 'Mysore', 'C#');
INSERT INTO Trainers (Name, Place, Skill) VALUES ('Sanjay', 'Trivendrum', 'Management');
INSERT INTO Trainers (Name, Place, Skill) VALUES ('Mishel', 'Idukki', 'WPF');
SELECT * FROM Trainers;