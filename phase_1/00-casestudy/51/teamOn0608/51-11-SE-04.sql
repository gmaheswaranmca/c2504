--------------[Anugrah team]--------------
--SUB Query

--find patients who had  an appoinment BETWEEN '2024-08-10' AND '2024-08-14'

--SELECT * FROM Patients;
SELECT Name FROM Patients WHERE PatientId  IN(SELECT PatientId FROM Appointments WHERE Date BETWEEN '2024-08-10' AND '2024-08-14');



--LIST ALL DOCTORS WHO HAVE SCHEDULED APPOINTMENTS


--SELECT * FROM Users;
--SELECT * FROM Appointments;


SELECT 
    Username AS DoctorName
FROM 
    Users
WHERE 
    Role = 'doctor' AND UserId IN (SELECT DoctorId FROM Appointments);

--Get the number of unread notifications for each user.

SELECT 
    Username,
    (SELECT COUNT(*) FROM Notifications WHERE Notifications.UserId = Users.UserId AND IsRead = 0) AS UnreadNotifications
FROM 
    Users;

    --using GROUP BY

SELECT 
    Username, COUNT(*)  
    FROM Users INNER JOIN Notifications ON Users.UserId = Notifications.UserId
    WHERE isRead = 0 GROUP BY Username;
    

--List All Appointments with Patient and Doctor Details:

--Question: Write a query to list all appointments along with the patient's name, doctor's name, and the appointment date and time.
--Expected Output Columns: AppointmentId, PatientName, DoctorName, Date, Time


SELECT 
    a.AppointmentId,
    p.Name AS PatientName,
    u.Username AS DoctorName,
    a.Date,
    a.Time
FROM 
    Appointments a
    JOIN Patients p ON a.PatientId = p.PatientId
    JOIN Users u ON a.DoctorId = u.UserId;


--TO GET A LIST OF APPOINNTMENTS ALONG WITH PATIENT NAME


-- INNER JOIN KEY WORD SELECTS RECORDS THAT HAVE MATCHING VALUES IN BOTH TABLES.
-- LEFT INNER JOIN RETURNS ALL RECORDS FROM THE LEFT TABLES ALONG WITH MATCHING RECORD
-- RIGTH INNER JOIN RETURNS ALL RECORDS FROM THE RIGHT TABLES ALONG WITH MATCHING RECORD

SELECT 
    Appointments.AppointmentId,
    Patients.Name AS PatientName,
    Appointments.Date,
    Appointments.Time,
    Appointments.Reason,
    Appointments.Status
FROM 
    Appointments
INNER JOIN 
    Patients ON Appointments.PatientId = Patients.PatientId;

    --TO GET A LIST OF PATIENT NAME WITHOUT APPOINTMENT


    SELECT 
    Appointments.AppointmentId,
    Patients.Name AS PatientName,
    Appointments.Date,
    Appointments.Time,
    Appointments.Reason,
    Appointments.Status
FROM 
    Patients
LEFT JOIN 
    Appointments ON Patients.PatientId = Appointments.PatientId;


   -- Write a query to list EHR integration logs along with the patient's name.


SELECT 
    p.Name AS PatientName,
    e.EHRSystem,
    e.Operation
FROM 
    Patients p
    JOIN EHR_IntegrationLogs e ON p.PatientId = e.PatientId;

--------------[Anurag team]--------------
--INNER JOIN
SELECT u.Username, p.Name
FROM Users u
INNER JOIN Patients p ON u.UserId = p.PatientId; 


--LEFT JOIN
SELECT u.Username, p.Name
FROM Users u
LEFT JOIN Patients p ON u.UserId = p.PatientId; 

--RIGHT JOIN

SELECT u.Username, p.Name
FROM Users u
RIGHT JOIN Patients p ON u.UserId = p.PatientId; 

--CROSS JOIN

SELECT u.Username, p.Name
FROM Users u
CROSS JOIN Patients p;


-- #1
-- to display patients names of the appointments 
--   on dates between '2024-08-10' and '2024-08-10'
    -- query here

-- #2
-- the doctors scheduled appointments 
    -- query here

-- #3
-- each user's number of unread notifications :: use sub query in selectors 
        -- query here
        
-- each user's number of unread notifications :: use group by  
SELECT u.UserName, Count(*) as UnreadCount   
FROM Users as u 
    INNER JOIN Notifications n ON(u.UserID = n.UserID)
WHERE n.IsRead=0
Group By u.UserName; 
-- #4
-- 