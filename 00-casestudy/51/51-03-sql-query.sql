/*====================================================================================
^^^^^^^^^^^^^^^^^^^^^^^App : Pages SQL /Query Design^^^^^^^^^^^^^^^^^^^^^^^
==================================================================================== 
    SQL statements required 
        for the various functionalities of the 
        "MediConnect system", 
    beyond just table creation. 
    
    These include 
        queries 
            for 
                CRUD operations, 
                user authentication, 
                searching, and 
                updating records. 
*/

-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~Authentication Pages~~~~~~~~~~~~~~~~~~~~~~~~~~~
--  1. Login Page
-- - Validate User Credentials:
 ------------------------------sql------------------------------
  SELECT UserId, Username, Role
  FROM Users
  WHERE Email = 'user_email' AND PasswordHash = 'user_password_hash';
 ------------------------------------------------------------

--  2. Register Page
-- - Insert New User:
 ------------------------------sql------------------------------
  INSERT INTO Users (Username, Email, PasswordHash, Role, CreatedAt, UpdatedAt)
  VALUES ('new_username', 'new_email', 'new_password_hash', 'user_role', GETDATE(), GETDATE());
 ------------------------------------------------------------

--  3. Forgot Password Page
-- - Find User by Email:
 ------------------------------sql------------------------------
  SELECT UserId, Email
  FROM Users
  WHERE Email = 'user_email';
 ------------------------------------------------------------

--  4. Reset Password Page
-- - Update User Password:
 ------------------------------sql------------------------------
  UPDATE Users
  SET PasswordHash = 'new_password_hash', UpdatedAt = GETDATE()
  WHERE UserId = 'user_id';
 ------------------------------------------------------------

-- ``````````````````````User Management Pages``````````````````````

 5. User Dashboard
-- - Get User Overview Data (Example: Recent Appointments):
--  ------------------------------sql------------------------------
  SELECT TOP 5 * FROM Appointments
  WHERE DoctorId = 'user_id'
  ORDER BY Date DESC, Time DESC;
--  ------------------------------------------------------------

--  6. User Profile Page
-- - Get User Profile Data:
--  ------------------------------sql------------------------------
  SELECT Username, Email, Role
  FROM Users
  WHERE UserId = 'user_id';
--  ------------------------------------------------------------

-- - Update User Profile:
--  ------------------------------sql------------------------------
  UPDATE Users
  SET Username = 'new_username', Email = 'new_email', UpdatedAt = GETDATE()
  WHERE UserId = 'user_id';
--  ------------------------------------------------------------

-- ``````````````````````Patient Management Pages``````````````````````

--  7. Patients List Page
-- - Get All Patients:
 ------------------------------sql------------------------------
  SELECT * FROM Patients;
 ------------------------------------------------------------

-- - Search Patients:
 ------------------------------sql------------------------------
  SELECT * FROM Patients
  WHERE Name LIKE '%search_term%' OR Email LIKE '%search_term%';
 ------------------------------------------------------------

--  8. Add Patient Page
-- - Insert New Patient:
 ------------------------------sql------------------------------
  INSERT INTO Patients (Name, Dob, Gender, Phone, Email, Address, CreatedAt, UpdatedAt)
  VALUES ('new_name', 'new_dob', 'new_gender', 'new_phone', 'new_email', 'new_address', GETDATE(), GETDATE());
 ------------------------------------------------------------

--  9. Edit Patient Page
-- - Get Patient Data:
 ------------------------------sql------------------------------
  SELECT * FROM Patients
  WHERE PatientId = 'patient_id';
 ------------------------------------------------------------

-- - Update Patient Data:
 ------------------------------sql------------------------------
  UPDATE Patients
  SET Name = 'new_name', Dob = 'new_dob', Gender = 'new_gender', Phone = 'new_phone', Email = 'new_email', Address = 'new_address', UpdatedAt = GETDATE()
  WHERE PatientId = 'patient_id';
 ------------------------------------------------------------

--  10. Patient Details Page
-- - Get Patient Details:
 ------------------------------sql------------------------------
  SELECT * FROM Patients
  WHERE PatientId = 'patient_id';
 ------------------------------------------------------------

-- - Get Patient Medical History:
 ------------------------------sql------------------------------
  SELECT * FROM MedicalHistory
  WHERE PatientId = 'patient_id';
 ------------------------------------------------------------

-- - Get Patient Appointments:
 ------------------------------sql------------------------------
  SELECT * FROM Appointments
  WHERE PatientId = 'patient_id';
 ------------------------------------------------------------

-- ``````````````````````Appointment Management Pages``````````````````````

--  11. Appointments List Page
-- - Get All Appointments:
 ------------------------------sql------------------------------
  SELECT * FROM Appointments;
 ------------------------------------------------------------

-- - Search Appointments:
 ------------------------------sql------------------------------
  SELECT * FROM Appointments
  WHERE Reason LIKE '%search_term%' OR Status LIKE '%search_term%';
 ------------------------------------------------------------

--  12. Add Appointment Page
-- - Insert New Appointment:
 ------------------------------sql------------------------------
  INSERT INTO Appointments (PatientId, DoctorId, Date, Time, Reason, Status, CreatedAt, UpdatedAt)
  VALUES ('new_patient_id', 'new_doctor_id', 'new_date', 'new_time', 'new_reason', 'scheduled', GETDATE(), GETDATE());
 ------------------------------------------------------------

--  13. Edit Appointment Page
-- - Get Appointment Data:
 ------------------------------sql------------------------------
  SELECT * FROM Appointments
  WHERE AppointmentId = 'appointment_id';
 ------------------------------------------------------------

-- - Update Appointment Data:
 ------------------------------sql------------------------------
  UPDATE Appointments
  SET PatientId = 'new_patient_id', DoctorId = 'new_doctor_id', Date = 'new_date', Time = 'new_time', Reason = 'new_reason', Status = 'new_status', UpdatedAt = GETDATE()
  WHERE AppointmentId = 'appointment_id';
 ------------------------------------------------------------

--  14. Appointment Details Page
-- - Get Appointment Details:
 ------------------------------sql------------------------------
  SELECT * FROM Appointments
  WHERE AppointmentId = 'appointment_id';
 ------------------------------------------------------------

-- - Get Patient and Doctor Details for Appointment:
 ------------------------------sql------------------------------
  SELECT p.*, u.*
  FROM Appointments a
  JOIN Patients p ON a.PatientId = p.PatientId
  JOIN Users u ON a.DoctorId = u.UserId
  WHERE a.AppointmentId = 'appointment_id';
 ------------------------------------------------------------

-- ``````````````````````Communication Pages``````````````````````

--  15. Messages Page
-- - Get Messages for User:
 ------------------------------sql------------------------------
  SELECT * FROM Messages
  WHERE ToUserId = 'user_id' OR FromUserId = 'user_id'
  ORDER BY Timestamp DESC;
 ------------------------------------------------------------

--  16. Compose Message Page
-- - Insert New Message:
 ------------------------------sql------------------------------
  INSERT INTO Messages (FromUserId, ToUserId, Message, Timestamp, CreatedAt, UpdatedAt)
  VALUES ('from_user_id', 'to_user_id', 'message_body', GETDATE(), GETDATE(), GETDATE());
 ------------------------------------------------------------

-- ``````````````````````Notifications Page``````````````````````

--  17. Notifications Page
-- - Get Notifications for User:
 ------------------------------sql------------------------------
  SELECT * FROM Notifications
  WHERE UserId = 'user_id'
  ORDER BY CreatedAt DESC;
 ------------------------------------------------------------

-- - Mark Notification as Read:
 ------------------------------sql------------------------------
  UPDATE Notifications
  SET IsRead = 1
  WHERE NotificationId = 'notification_id';
 ------------------------------------------------------------

-- ``````````````````````Integration and Logs Pages``````````````````````

--  18. EHR Integration Logs Page
-- - Get EHR Integration Logs:
 ------------------------------sql------------------------------
  SELECT * FROM EHR_IntegrationLogs;
 ------------------------------------------------------------

-- - Search EHR Integration Logs:
 ------------------------------sql------------------------------
  SELECT * FROM EHR_IntegrationLogs
  WHERE EHRSystem LIKE '%search_term%' OR Status LIKE '%search_term%';
 ------------------------------------------------------------

-- ``````````````````````Settings and Administration Pages``````````````````````

--  19. Settings Page
-- - Get User Settings:
 ------------------------------sql------------------------------
  SELECT * FROM Users
  WHERE UserId = 'user_id';
 ------------------------------------------------------------

-- - Update User Settings:
 ------------------------------sql------------------------------
  UPDATE Users
  SET Email = 'new_email', PasswordHash = 'new_password_hash', UpdatedAt = GETDATE()
  WHERE UserId = 'user_id';
 ------------------------------------------------------------

--  20. Admin Dashboard
-- - Get System Overview (Example: Total Users):
 ------------------------------sql------------------------------
  SELECT COUNT(*) AS TotalUsers FROM Users;
 ------------------------------------------------------------

-- - Get Recent Activities:
 ------------------------------sql------------------------------
  SELECT * FROM Appointments
  ORDER BY CreatedAt DESC;
 ------------------------------------------------------------

-- ``````````````````````Help and Support Pages``````````````````````

--  21. Help Page
-- - Get Help Articles:
 ------------------------------sql------------------------------
  SELECT * FROM HelpArticles;
 ------------------------------------------------------------

--  22. Contact Support Page
-- - Insert Support Request:
 ------------------------------sql------------------------------
  INSERT INTO SupportRequests (UserId, Subject, Message, CreatedAt)
  VALUES ('user_id', 'subject', 'message_body', GETDATE());
 ------------------------------------------------------------

-- ``````````````````````SQL statements for the additional functionalities:``````````````````````

-- 1. SQL to Upload Profile Picture
--      To handle profile pictures, 
--      you would typically store the image path or URL in the database and 
--      save the actual image in a file storage system.

-- Add a column to the `Users` table to store the profile picture path:
------------------------------sql------------------------------
ALTER TABLE Users
ADD ProfilePicturePath NVARCHAR(255);
------------------------------------------------------------

-- Update the user's profile picture:
------------------------------sql------------------------------
UPDATE Users
SET ProfilePicturePath = 'new_profile_picture_path', UpdatedAt = GETDATE()
WHERE UserId = 'user_id';
------------------------------------------------------------

-- 2. Search Patients SQL with Sort
-- Search and sort patients by name, email, or other fields:
------------------------------sql------------------------------
SELECT * FROM Patients
WHERE Name LIKE '%search_term%' OR Email LIKE '%search_term%'
ORDER BY Name ASC; 
-- Change 'Name' to the column you want 
-- to sort by and 'ASC' to 'DESC' for descending order.
------------------------------------------------------------

-- 3. SQL for Patient Delete
-- Delete a patient by `PatientId`:
------------------------------sql------------------------------
-- DELETE FROM Patients
-- WHERE PatientId = 'patient_id';
------------------------------------------------------------

-- 4. SQL for Adding Medical History Fields
-- Add a new medical history record:
------------------------------sql------------------------------
INSERT INTO MedicalHistory (PatientId, Condition, DiagnosisDate, Notes, CreatedAt, UpdatedAt)
VALUES ('patient_id', 'condition_description', 'diagnosis_date', 'notes', GETDATE(), GETDATE());
------------------------------------------------------------

-- 5. SQL for Appointment Delete
-- Delete an appointment by `AppointmentId`:
------------------------------sql------------------------------
DELETE FROM Appointments
WHERE AppointmentId = 'appointment_id';
------------------------------------------------------------

-- 6. SQL for Deleting an Appointment (Repeated)
-- Delete an appointment by `AppointmentId` (same as above):
------------------------------sql------------------------------
DELETE FROM Appointments
WHERE AppointmentId = 'appointment_id';
------------------------------------------------------------