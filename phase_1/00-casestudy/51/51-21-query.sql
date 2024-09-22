-- 1. Query to Get All Patients
---------------------------------sql---------------------------------
SELECT * FROM Patients;
------------------------------------------------------------------

-- 2. Query to Get All Appointments for a Specific Doctor
---------------------------------sql---------------------------------
SELECT * FROM Appointments WHERE DoctorId = 2;
------------------------------------------------------------------

-- 3. Query to Get Medical History for a Specific Patient
---------------------------------sql---------------------------------
SELECT * FROM MedicalHistory WHERE PatientId = 1;
------------------------------------------------------------------

-- 4. Query to Get All Messages Sent by a Specific User
---------------------------------sql---------------------------------
SELECT * FROM Messages WHERE FromUserId = 2;
------------------------------------------------------------------

-- 5. Query to Get All Users with the Role of 'doctor'
---------------------------------sql---------------------------------
SELECT * FROM Users WHERE Role = 'doctor';
------------------------------------------------------------------

-- 6. Query to Get All Notifications for a Specific User
---------------------------------sql---------------------------------
SELECT * FROM Notifications WHERE UserId = 2;
------------------------------------------------------------------

-- 7. Query to Get All Successful EHR Imports
---------------------------------sql---------------------------------
SELECT * FROM EHR_IntegrationLogs WHERE Operation = 'import' AND Status = 'success';
------------------------------------------------------------------

-- 8. Query to Update the Status of an Appointment
---------------------------------sql---------------------------------
UPDATE Appointments
SET Status = 'completed'
WHERE AppointmentId = 1;
------------------------------------------------------------------

-- 9. Query to Delete a Patient Record
---------------------------------sql---------------------------------
DELETE FROM Patients
WHERE PatientId = 2;
------------------------------------------------------------------

-- 10. Query to Insert a New User
---------------------------------sql---------------------------------
INSERT INTO Users (Username, Email, PasswordHash, Role, CreatedAt, UpdatedAt)
VALUES ('dr_jane', 'jane.doe@mediconnect.com', 'hashed_password5', 'doctor', GETDATE(), GETDATE());
------------------------------------------------------------------