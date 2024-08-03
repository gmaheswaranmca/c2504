/*
Practice on SQL Server:
    trainer_search_app
    1. resource: trainer_search_db / trainer CRUD operations 
    trainer : {id, name, skill, place} 
*/

-- setup database / tables required

-- to create the database "trainer_search_db"
CREATE DATABASE trainer_search_db;

-- to switch/use the database "trainer_search_db" ie to make as active / current database
USE trainer_search_db;

-- to creaate table "trainer" in db "trainer_search_db"(active)
CREATE TABLE trainer (
	id integer primary key identity(1,1),
	name varchar(255) not null,
	skill varchar(512) not null,
	place varchar(126) not null
);

-- to see about table "trainer"
sp_help trainer;

-- to display / query rows of trainer 
SELECT * FROM trainer;

-- to insert (one) trainer "mahesh"
INSERT INTO trainer(name, skill, place) VALUES('mahesh', 'c#', 'mysore');
-- to insert (one) trainer "gopal" -- multiline cmd
INSERT INTO trainer(name, skill, place) 
VALUES('gopal', 'c#', 'trivandrum');
-- to insert (many) trainers "sanjay" and "mishel" -- multiline cmd
INSERT INTO trainer(name, skill, place) 
	VALUES('sanjay', 'management', 'trivandrum'),
		  ('mishel', 'wpf', 'idukki');
/*
-- to insert (many) trainers "sanjay" and "mishel" -- single cmd
INSERT INTO trainer(name, skill, place) VALUES('neha', 'c# trainee', 'trivandrum'),('ashna', 'c# trainee', 'kochi');
*/
-- to delete duplicate "mahesh"
DELETE FROM trainer WHERE id = 5;

-- to delete trainees "neha" and "ashna" -- id IN (6,7) ==> id is either 6 or 7
DELETE FROM trainer WHERE id IN (6,7);

-- to display trainers "mahesh", "mishe" name and skill 
SELECT name, skill FROM trainer WHERE id IN(1,4);

-- to update trainers "mahesh" and "mishel" skill as "wpf and c#"
UPDATE trainer 
SET skill='wpf and c#'
WHERE id IN(1,4);

-- to display trainers "mahesh", "mishe" name and skill using name based search
SELECT name, skill FROM trainer WHERE name IN('mahesh','mishel');

-- to update trainers "mahesh" and "mishel" skill as "WPF and C#" using named based where cond
UPDATE trainer 
SET skill='WPF and C#'
WHERE name IN('mahesh','mishel');


-- to update many rows or delete many rows -- rare use cases in real time 
-- practice: realtimew we do update / delete a record at a time
-- practice: use id for where cond to update / delete

-- to display mahesh using id based where cond
SELECT * FROM trainer WHERE id = 1;

-- to update mahesh's name as "Mahesh" and place as "Mysore"
UPDATE trainer 
SET name='Mahesh', place='Mysore'
WHERE id = 1;

-- to display mishel using id based where cond
SELECT * FROM trainer WHERE id = 4;

-- to update mishel's name as "Mishel", place as "Idukki", and skill as "C# and WPF"
UPDATE trainer 
SET name='Mishel', place='Idukki', skill='C# and WPF'
WHERE id = 4;


-- CRUD operations on trainer resource / table 
-- CRUD : [C]reate one trainer, [R]ead all trainers, Read by id, [U]pdate by id, [D]elete by id
-- #1 to insert (one) trainer 
INSERT INTO trainer(name, skill, place) VALUES('mahesh', 'c#', 'mysore');
-- #2 to query all trainers 
SELECT id, name, skill, place FROM trainer;
-- #3 to query trainer by id 
SELECT id, name, skill, place FROM trainer 
WHERE id=4;
-- #4 to update trainer by id
UPDATE trainer 
SET name='Mishel', place='Idukki', skill='C# and WPF'
WHERE id = 4;
-- #5 to delete trainer by id 
DELETE FROM trainer 
WHERE id=4;

/*
-- to drop the table "trainer" -- practice: before drop table, delete all trainers first
DROP TABLE trainer;
*/

/*
-- to drop the DATABASE "trainer_search_db" -- practice: before drop db, drop all other objects ie tables, views etc
DROP DATABASE trainer_search_db;
*/