-- all trainers
SELECT * FROM trainer;

-- display trainers name 
SELECT name FROM trainer;

-- display mahesh row 
SELECT id, name, skill, place 
FROM trainer
WHERE name='Mahesh';

-- display mahesh and Sanjay row 
SELECT id, name, skill, place 
FROM trainer
WHERE name IN('Mahesh','Sanjay') ;

-- display trainers starts wit 'M'
SELECT id, name, skill, place 
FROM trainer
WHERE name LIKE 'm%';

-- display trainers ends with 'L'
SELECT id, name, skill, place 
FROM trainer
WHERE name LIKE '%l';

-- display trainers whose name contains 'a'
SELECT id, name, skill, place 
FROM trainer
WHERE name LIKE '%a%';