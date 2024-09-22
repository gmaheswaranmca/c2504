--------------[Sahla team]--------------
----Aggregators------

-- COUNT
SELECT COUNT(*) AS NUMBER_OF_USERS FROM Users;

SELECT COUNT(*) AS NUMBER_OF_PATIENTS FROM Patients;

SELECT COUNT(*) AS NUMBER_OF_MedicalHistory FROM MedicalHistory;
 
SELECT COUNT(*) AS NUMBER_OF_Appointments FROM Appointments;

SELECT COUNT(*) AS NUMBER_OF_Messages FROM Messages;

SELECT COUNT(*) AS NUMBER_OF_EHR_IntegrationLogs FROM EHR_IntegrationLogs;

SELECT COUNT(*) AS NUMBER_OF_Notifications FROM Notifications;

-- Sum of date of birth of patients
SELECT SUM( DATEDIFF( YEAR, Dob, GETDATE() ) ) AS SUM_AGE
FROM Patients;

SELECT SUM( DATEDIFF( YEAR, Dob, GETDATE() ) ) AS SUM_AGE
FROM Patients
WHERE PatientId IN(1,2);

--Average of date of birth of patients
SELECT AVG( DATEDIFF( YEAR, Dob, GETDATE() ) ) AS AVG_AGE
FROM Patients
WHERE PatientId IN(1,2);

--MIN date of birth
SELECT MIN(Dob) AS MIN_Dob FROM Patients;

SELECT * FROM Patients ORDER BY Dob;

SELECT MIN(DATEDIFF( YEAR, Dob, GETDATE())) AS MIN_AGE FROM Patients;

--MAX date of birth
SELECT MAX(Dob) AS MAX_Dob FROM Patients;

SELECT * FROM Patients ORDER BY Dob DESC;

SELECT MAX(DATEDIFF( YEAR, Dob, GETDATE())) AS MAX_AGE FROM Patients;


-- List the number of users by role.
SELECT Role, COUNT(*) AS NumberOfUsers
FROM Users
GROUP BY Role;

-- Count the number of patients by gender. 
SELECT Gender, COUNT(*) AS NumberOfPatients
FROM Patients
GROUP BY Gender;

-- Count the number of medical conditions recorded by condition type.
SELECT Condition, COUNT(*) AS NumberOfCases
FROM MedicalHistory
GROUP BY Condition;

-- Count the number of appointments scheduled by doctor.
SELECT DoctorId, COUNT(*) AS NumberOfAppointments
FROM Appointments
GROUP BY DoctorId;

-- Count the number of messages sent by each user. 
SELECT FromUserId, COUNT(*) AS NumberOfMessagesSent
FROM Messages
GROUP BY FromUserId;

-- Count the number of operations by status. 
SELECT Status, COUNT(*) AS NumberOfOperations
FROM EHR_IntegrationLogs
GROUP BY Status;

-- Count the number of notifications by read status. 
SELECT IsRead, COUNT(*) AS NumberOfNotifications
FROM Notifications
GROUP BY IsRead;

-- List roles with more than one user. 
SELECT Role, COUNT(*) AS NumberOfUsers
FROM Users
GROUP BY Role
HAVING COUNT(*) > 1;

-- Count the number of patients by gender where the count is greater than 2. 
SELECT Gender, COUNT(*) AS NumberOfPatients
FROM Patients
GROUP BY Gender
HAVING COUNT(*) > 2;

-- List conditions with more than one recorded case. 
SELECT Condition, COUNT(*) AS NumberOfCases
FROM MedicalHistory
GROUP BY Condition
HAVING COUNT(*) > 1;

-- List doctors who have more than two appointments scheduled. 
SELECT DoctorId, COUNT(*) AS NumberOfAppointments
FROM Appointments
GROUP BY DoctorId
HAVING COUNT(*) > 2;

-- List operations that failed more than once. 
SELECT Status, COUNT(*) AS NumberOfOperations
FROM EHR_IntegrationLogs
WHERE Status = 'failure'
GROUP BY Status
HAVING COUNT(*) > 1;

--  Retrieve all appointments for each doctor 
SELECT 
    u.UserId AS DoctorId,
    u.Username AS DoctorUsername,
    COUNT(a.AppointmentId) AS NumberOfAppointments,
    STRING_AGG(p.Name, ', ') AS PatientNames
FROM 
    Appointments a
JOIN 
    Patients p ON a.PatientId = p.PatientId
JOIN 
    Users u ON a.DoctorId = u.UserId
GROUP BY 
    u.UserId, u.Username
ORDER BY 
    u.UserId;

-- [Sharon team]
-- aggregators | compute min/max/sum/avg/count from many rows
--	COUNT | SUM | AVG | MIN | MAX

-- to find the number of patients
SELECT COUNT(*) AS NUMBER_OF_PATIENTS FROM PATIENTS;

-- to find the number of users
SELECT COUNT(*) AS NUMBER_OF_PATIENTS FROM USERS;

-- to find  sum of average age of patients
SELECT SUM( DATEDIFF( YEAR, DOB, GETDATE() ) )/ COUNT(*) AS AVG_AGE FROM patients;

-- to find average age 
SELECT AVG( DATEDIFF( YEAR, DOB, Getdate() ) ) AS AVG_AGE FROM Patients;


-- to find age of Patient with PatientId = 1
SELECT DATEDIFF( YEAR, DOB, Getdate() )  AS AGE FROM Patients where PatientId=1;


-- to find min age of patients
SELECT MIN( DATEDIFF( YEAR, DOB, GETDATE() ) ) AS MIN_AGE FROM PATIENTS;

-- to find max age of patients
SELECT MAX( DATEDIFF( YEAR, DOB, GETDATE() ) ) AS MAX_AGE FROM PATIENTS;


-- to display distint role of users
SELECT ROLE 
FROM USERS
GROUP BY ROLE;


-- to display number of distint role of users
SELECT COUNT(*), ROLE
FROM USERS
GROUP BY ROLE;

-- to display the IDs of doctors who have at least one appointment scheduled.
SELECT DoctorId, COUNT(*) AS NumberofAppointments
FROM Appointments
GROUP BY DoctorId
HAVING COUNT(*) > 0;


--total number of patients with condition "Hypertension"
SELECT Condition, COUNT(PatientId) AS PatientCount
FROM MedicalHistory
WHERE Condition = 'Hypertension'
GROUP BY Condition;


--average number of appointments per doctor
SELECT DoctorId, AVG(AppointmentCount) AS AvgAppointments 
FROM (SELECT DoctorId, COUNT(AppointmentId) AS AppointmentCount
FROM Appointments
GROUP BY DoctorId) AS DoctorAppointments
GROUP BY DoctorId;

--to find the name of the patient with  age 30 greater than 30 using HAVING
SELECT Name, DOB, DATEDIFF(YEAR, DOB, GETDATE()) AS Age
FROM Patients
GROUP BY Name, DOB
HAVING DATEDIFF(YEAR, DOB, GETDATE()) >=30

--to find the name of the patient with  age 30 greater than 30 using HAVING sort by name z-a
SELECT Name, DOB, DATEDIFF(YEAR, DOB, GETDATE()) AS Age
FROM Patients
GROUP BY Name, DOB
HAVING DATEDIFF(YEAR, DOB, GETDATE()) >=30
ORDER BY NAME DESC;

--to display number of patients with each condition
SELECT Condition, COUNT(PatientId) AS PatientCount
FROM MedicalHistory
GROUP BY Condition;

-- to find Patients with age less than average age
SELECT PatientId
FROM Patients
WHERE DATEDIFF(YEAR, DOB, GETDATE()) < (
    SELECT AVG(DATEDIFF(YEAR, DOB, GETDATE()))
    FROM Patients
);


--to find the name of the patient with age 30 greater than 30 using HAVING , then order by age first and then by name (GROUP BY, HAVING, ORDER BY)
SELECT Name, Dob, DATEDIFF(YEAR, DOB, GETDATE()) AS Age
FROM Patients
GROUP BY Name, DOB
HAVING DATEDIFF(YEAR, DOB, GETDATE()) >=30
order by age, name;

-- to display the date of appoinment slot of patient
SELECT patientid, date, time 
FROM Appointments
ORDER BY time;