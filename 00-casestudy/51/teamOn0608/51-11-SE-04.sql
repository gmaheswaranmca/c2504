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