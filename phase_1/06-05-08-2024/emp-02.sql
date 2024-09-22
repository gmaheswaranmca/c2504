-- display departments
SELECT * FROM dept;
-- display all employees 
SELECT * FROM EMP;

-- display employees empno, name, job, sal for salesman job 
SELECT EMPNO, ENAME, JOB, SAL 
FROM EMP
WHERE JOB='SALESMAN';

-- selectors 
--	-- column, expression, constant

-- display employees empno, name, job, sal, comm and gross sal
	-- SAL + null COMM is null only
	SELECT EMPNO, ENAME, JOB, SAL, COMM, SAL + COMM 
	FROM EMP;
	--make null comm as zero 
	SELECT EMPNO, ENAME, JOB, SAL, isnull(COMM,0) AS COMM, SAL + COMM 
	FROM EMP;
	-- isnull(COMM,0) : returns `COMM` if first arg 'COMM' is not null, else returns second arg `0`
	-- solving
SELECT EMPNO, ENAME, JOB, SAL, isnull(COMM,0) AS COMM, SAL + isnull(COMM,0) AS GROSSSAL 
FROM EMP;

--wrong quering I try to use "COMM1" for GROSSSAL calculation 
SELECT EMPNO, ENAME, JOB, SAL, isnull(COMM,0) AS COMM1, SAL + COMM1 AS GROSSSAL 
FROM EMP

-- display employees empno, name, job, sal, comm and gross sal sort by comm desc
--	Note: expression alias name can be used for sorting but not for another expr
SELECT EMPNO, ENAME, JOB, SAL, isnull(COMM,0) AS COMM1, SAL + isnull(COMM,0) AS GROSSSAL 
FROM EMP
ORDER BY COMM1 DESC;

-- display employees empno, name, job, sal, comm and gross sal sort by comm desc
--	Note: sort is possible by ordinal number (position of the result table column)
SELECT EMPNO, ENAME, JOB, SAL, isnull(COMM,0) AS COMM1, SAL + isnull(COMM,0) AS GROSSSAL 
FROM EMP
ORDER BY 5 DESC;

-- NOTE: ORDER BY takes column name, expression alias name, result table column `ordinal number`

-- to find percentage of 500 in 800?
SELECT 500.0/800.0*100.0

-- display employees empno, name, job, sal, non-null comm, comm % in gross sal 
SELECT EMPNO, ENAME, JOB, SAL, isnull(COMM,0) AS COMM,
	isnull(COMM,0)/ ( isnull(COMM,0) + SAL) * 100.0 AS COMM_PER
FROM EMP
-- Here, ( isnull(COMM,0) + SAL) is gross sal 
	-- then find comm per in the gross sal 

-- find your age by your birth_date "maheswaran"
SELECT '1979-04-09' BIRTH_DATE, getdate() TODAY_DATE, 
	DATEDIFF(YEAR, '1979-04-09', getdate()) AGE;

-- find your age by your birth_date "gayathri"
SELECT '2001-08-13' as BIRTH_DATE, getdate() as TODAY_DATE, 
	DATEDIFF(YEAR, '2001-08-13', getdate()) as AGE;

-- display employees experience in years and max age as 58
SELECT EMPNO, ENAME, HIREDATE, DATEDIFF(YEAR, HIREDATE, getdate()) as EXPERIENCE, 58 as MAX_AGE  
FROM EMP;

-- arith ops
SELECT 8+3, 8-3, 8*3, 8/3, 8%3

-- filtering
-- relational operators < > <= >= <> =
--			IN LIKE BETWEEN EXISTS
-- logical operators		AND OR NOT 

-- 1. display employeess whose salary is below 2500 [Neha, Shilpa]
SELECT EMPNO, ENAME, JOB, 
    MGR, HIREDATE, SAL, COMM, DEPTNO  
FROM EMP
WHERE SAL < 2500;
-- 2. display employeess whose salary is above 2500 [Riza, Yahkoop]
SELECT EMPNO, ENAME, JOB, 
    MGR, HIREDATE, SAL, COMM, DEPTNO  
FROM EMP
WHERE SAL > 2500;
-- 3. display employeess whose salary is below or equal 2500 [Riza, Yahkoop]
SELECT EMPNO, ENAME, JOB, 
    MGR, HIREDATE, SAL, COMM, DEPTNO  
FROM EMP
WHERE SAL <= 2500;
-- 4. display employeess whose salary is above or equal 2500 [Gayathri, Ashna]
SELECT EMPNO, ENAME, JOB, 
    MGR, HIREDATE, SAL, COMM, DEPTNO  
FROM EMP
WHERE SAL >= 2500;

-- 5. display employeess whose salary is equal 3000 [Gayathri, Ashna]
SELECT EMPNO, ENAME, JOB, 
    MGR, HIREDATE, SAL, COMM, DEPTNO  
FROM EMP
WHERE SAL = 3000;
-- 6. display employeess whose salary is not equal 3000 [Gayathri, Ashna]
SELECT EMPNO, ENAME, JOB, 
    MGR, HIREDATE, SAL, COMM, DEPTNO  
FROM EMP
WHERE SAL <> 3000; -- "WHERE SAL != 3000" will also work
-- 7a. display employeess whose salary is any of 3000, 1250 [Sarika, Anjana NK]
SELECT EMPNO, ENAME, JOB, 
    MGR, HIREDATE, SAL, COMM, DEPTNO  
FROM EMP
WHERE SAL IN (3000, 1250); -- similar to "SAL = 3000 OR SAL = 1250"
-- 7b. display employeess whose salary is not any of 3000, 1250 [Sarika, Anjana NK]
SELECT EMPNO, ENAME, JOB, 
    MGR, HIREDATE, SAL, COMM, DEPTNO  
FROM EMP
WHERE SAL NOT IN (3000, 1250); -- similar to "NOT (SAL IN (3000, 1250)) "
-- 8. display employeess whose salary is between 2000 and 3500 [Sarika, Anjana NK]
SELECT EMPNO, ENAME, JOB, 
    MGR, HIREDATE, SAL, COMM, DEPTNO  
FROM EMP
WHERE SAL BETWEEN 2000 AND 3500; -- similar to "SAL >= 2000 AND SAL <= 3500" | "2000 <= SAL AND SAL <= 3500"
-- 9. display employeess whose salary is not between 2000 and 3500 [Sarika, Anjana NK]
SELECT EMPNO, ENAME, JOB, 
    MGR, HIREDATE, SAL, COMM, DEPTNO  
FROM EMP
WHERE SAL NOT BETWEEN 2000 AND 3500;
-- 10. display employeess whose name starts with 'S' [Sarika, Anjana NK]
SELECT EMPNO, ENAME, JOB, 
    MGR, HIREDATE, SAL, COMM, DEPTNO  
FROM EMP
WHERE ENAME LIKE 'S%';
-- 11. display employeess whose name ends with 'D' [Ashna, Neha]
SELECT EMPNO, ENAME, JOB, 
    MGR, HIREDATE, SAL, COMM, DEPTNO  
FROM EMP
WHERE ENAME LIKE '%D';
-- 12. display employeess whose name contains 'AM' [Ashna, Neha]
SELECT EMPNO, ENAME, JOB, 
    MGR, HIREDATE, SAL, COMM, DEPTNO  
FROM EMP
WHERE ENAME LIKE '%AM%';
-- 13. display employeess whose name not starts with 'S' [Ashna, Neha]
SELECT EMPNO, ENAME, JOB, 
    MGR, HIREDATE, SAL, COMM, DEPTNO  
FROM EMP
WHERE ENAME NOT LIKE 'S%';
-- 14. display employeess whose name not ends with 'D' [Ashna, Neha]
SELECT EMPNO, ENAME, JOB, 
    MGR, HIREDATE, SAL, COMM, DEPTNO  
FROM EMP
WHERE ENAME NOT LIKE '%D';
-- 15. display employeess whose name not contains 'AM' [Ashna, Neha]
SELECT EMPNO, ENAME, JOB, 
    MGR, HIREDATE, SAL, COMM, DEPTNO  
FROM EMP
WHERE ENAME NOT LIKE '%AM%';




