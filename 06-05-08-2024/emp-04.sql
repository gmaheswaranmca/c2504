-- display departments
SELECT * FROM dept;
-- display all employees 
SELECT * FROM EMP;

-- aggregators | compute min/max/sum/avg/count from many rows
--	COUNT | SUM | AVG | MIN | MAX


-- to find number of departments 
SELECT COUNT(*) AS NUMBER_OF_DEPT FROM DEPT;

-- to find number of employees
SELECT COUNT(*) AS NUMBER_OF_EMP FROM EMP;

-- to find total salaries "SAL"
SELECT SUM(SAL) AS TOT_SAL FROM EMP;

-- to find avg of salaries -- two aggregators used to find avg
SELECT SUM(SAL)/COUNT(*) AS AVG_SAL FROM EMP;

-- to find avg of salaries 
SELECT AVG(SAL) AS AVG_SAL FROM EMP;

-- to find min salary
SELECT MIN(SAL) AS MIN_SAL FROM EMP;

-- to find min salary
SELECT MAX(SAL) AS MAX_SAL FROM EMP;

-- to find avg experience
SELECT AVG( DATEDIFF( YEAR, HIREDATE, GETDATE() ) ) AS AVG_EXPERIENCE 
FROM EMP;

--to display number of emp, sum of experience, avg experience
SELECT
    COUNT( * ) AS NUM_OF_EMP,
	SUM( DATEDIFF( YEAR, HIREDATE, GETDATE() ) ) AS TOT_EXPERIENCE,
	AVG( DATEDIFF( YEAR, HIREDATE, GETDATE() ) ) AS AVG_EXPERIENCE 
FROM EMP;

-- SELECT 179/14

--to display difference between min and max salary of employees [Keerthan, Sahla]
SELECT MAX(SAL) - MIN(SAL) AS DIFF_OF_MAX_MIN_SAL 
FROM EMP;

--to find TOT SAL of JOB SALESPERSON 'SALESMAN' [Keerthan, Sahla]
SELECT SUM(SAL) AS TOT_SAL_OF_SALESPERSON
FROM EMP
WHERE JOB='SALESMAN';

-- what is group by 
	-- categorize the rows into groups 
	-- then each group we may apply aggregators
-- to find distinct jobs
SELECT JOB FROM EMP; -- dublicated jobs 
SELECT DISTINCT JOB FROM EMP; -- no job title is repeated -- 1
-- to count distinct jobs 
SELECT COUNT(DISTINCT JOB) FROM EMP; -- count distinct jobs
-- to display distinct jobs without DISTINCT -- 2	1 and 2 are to disp distinct jobs 
SELECT JOB 
FROM EMP
GROUP BY JOB;

--to find each job title total salary [Sahla, Rishwin]
SELECT JOB, SUM(SAL) as JOB_SAL
FROM EMP 
GROUP BY JOB;

--to find each deptno avg salary and max sal [Sahla, Rishwin]
SELECT DEPTNO, AVG(SAL) as DEPT_AVG_SAL, MAX(SAL) as DEPT_MAX_SAL
FROM EMP
GROUP BY DEPTNO;

-- to find experience based total salary [Rishwin, Anjana ER]
SELECT DATEDIFF(YEAR, HIREDATE, GETDATE()) as EXPERIENCE, SUM(SAL) as EXPERIENCE_SAL
FROM EMP 
GROUP BY DATEDIFF(YEAR, HIREDATE, GETDATE());

-- to find deptno total salary and total salary below 9000 [Anjana ER, Keerthana]
-- step 1 find deptno based tot sal 
SELECT DEPTNO, SUM(SAL) as DEPT_SAL
FROM EMP
GROUP BY DEPTNO;
--step 2 filter tot sal below 9000
	-- to filter after group by we cannot use where cond
	-- to filter after group b we must use HAVING clause 
	-- HAVING is filtering used along with GROUP BY 
SELECT DEPTNO, SUM(SAL) as DEPT_SAL
FROM EMP
GROUP BY DEPTNO
HAVING SUM(SAL) < 9000;

	-- wrong quering because alias name of selector cannot be used in filtering
	SELECT DEPTNO, SUM(SAL) as DEPT_SAL
	FROM EMP
	GROUP BY DEPTNO
	HAVING DEPT_SAL < 9000;
-- to find deptno total salary and total salary above or equal 9000 [Anjana ER, Keerthana]
SELECT DEPTNO, SUM(SAL) as DEPT_SAL
FROM EMP
GROUP BY DEPTNO
HAVING SUM(SAL) >= 9000;

-- to find job total salary and job salary below 6000
SELECT JOB, SUM(SAL) as JOB_SAL
FROM EMP
GROUP BY JOB
HAVING SUM(SAL) < 6000;

-- to find job total salary and job salary above or equal 6000
SELECT JOB, SUM(SAL) as JOB_SAL
FROM EMP
GROUP BY JOB
HAVING SUM(SAL) >= 6000;

-- to find job total salary and job salary below 6000 sort by job name z-a
SELECT JOB, SUM(SAL) as JOB_SAL
FROM EMP
GROUP BY JOB
HAVING SUM(SAL) < 6000
ORDER BY JOB DESC;

-- to find dept based and then job based total salary
-- sort by dept then by job 
SELECT DEPTNO, JOB, COUNT(*) as DEPT_JOB_COUNT, SUM(SAL) as DEPT_JOB_SAL 
FROM EMP 
GROUP BY DEPTNO, JOB
ORDER BY DEPTNO, JOB;

-- max salary getter 
	-- step 1: to find max sal [Anugrah Krishnan, Alan Kuriakose]
	SELECT MAX(SAL) FROM EMP; -- scalar value : one row - one col : one cell data 
	-- step 2: scal valued query may be in the cond as val/data
	SELECT EMPNO, ENAME, JOB, 
		MGR, HIREDATE, SAL, COMM, DEPTNO 
	FROM EMP 
	WHERE SAL=(SELECT MAX(SAL) FROM EMP);
-- min salary getter [Anugrah Krishnan, Alan Kuriakose]
	SELECT EMPNO, ENAME, JOB, 
		MGR, HIREDATE, SAL, COMM, DEPTNO 
	FROM EMP 
	WHERE SAL=(SELECT MIN(SAL) FROM EMP);
-- below or equal avg sal getters [Anugrah Krishnan, Alan Kuriakose]
	SELECT EMPNO, ENAME, JOB, 
		MGR, HIREDATE, SAL, COMM, DEPTNO 
	FROM EMP 
	WHERE SAL<=(SELECT AVG(SAL) FROM EMP);

-- above avg sal getters [Anugrah Krishnan, Alan Kuriakose]
	SELECT EMPNO, ENAME, JOB, 
		MGR, HIREDATE, SAL, COMM, DEPTNO 
	FROM EMP 
	WHERE SAL>(SELECT AVG(SAL) FROM EMP);

-- why join 
	-- to get data of matching rows of two or more tables 
-- disp empno, deptno, empname, deptname [Girish, Anurag Ashok]
	/*
	SELECT 14 * 4;

	SELECT EMP.EMPNO, EMP.ENAME, EMP.DEPTNO, DEPT.DNAME
	FROM EMP 
		INNER JOIN DEPT ON (1=1); -- CROSS JOIN -- each emp joined with every dept

	SELECT EMP.EMPNO, EMP.ENAME, EMP.DEPTNO, DEPT.DNAME
	FROM EMP 
		CROSS JOIN DEPT; -- CROSS JOIN
	*/
SELECT EMP.EMPNO, EMP.ENAME, EMP.DEPTNO, DEPT.DNAME
FROM EMP 
	INNER JOIN DEPT ON (EMP.DEPTNO = DEPT.DEPTNO); -- emp's matched dept 

-- to display emp name, loc [Girish, Anurag Ashok]
SELECT  e.ENAME, d.LOC
FROM EMP as e
	INNER JOIN DEPT as d ON (e.DEPTNO = d.DEPTNO); 

-- to count loc based emps
SELECT d.LOC, COUNT(*) as LOC_EMPS_COUNT
FROM EMP as e
	INNER JOIN DEPT as d ON (e.DEPTNO = d.DEPTNO)
GROUP BY d.LOC;

-- to count dept name based emps
SELECT d.DNAME, COUNT(*) as DNAME_EMPS_COUNT
FROM EMP as e
	INNER JOIN DEPT as d ON (e.DEPTNO = d.DEPTNO)
GROUP BY d.DNAME;

-- to dept name based emps tot sal 
SELECT d.DNAME, SUM(e.SAL) as DNAME_SAL
FROM EMP as e
	INNER JOIN DEPT as d ON (e.DEPTNO = d.DEPTNO)
GROUP BY d.DNAME;

-- to display each dept's total salary (including dept not in emp)
	-- step 1
	-- to display emp name, dept name (and display extra dept if so)
		SELECT e.ENAME, d.DNAME
		FROM EMP as e
			INNER JOIN DEPT as d ON (e.DEPTNO = d.DEPTNO); -- matched rows

		SELECT e.ENAME, d.DNAME 
		FROM EMP as e
			RIGHT OUTER JOIN DEPT as d ON (e.DEPTNO = d.DEPTNO); -- matched rows + extra rows(right) -- at left side NULL vals

		SELECT isnull(e.ENAME,'NO EMPS') as ENAME, d.DNAME 
		FROM EMP as e
			RIGHT OUTER JOIN DEPT as d ON (e.DEPTNO = d.DEPTNO); -- matched rows + extra rows(right) -- to avoid nulls at left use ISNULL
	--step 2
SELECT d.DNAME, SUM(e.SAL) as DNAME_SAL
FROM EMP as e
	INNER JOIN DEPT as d ON (e.DEPTNO = d.DEPTNO)
GROUP BY d.DNAME;
	--step 3
SELECT d.DNAME, SUM(ISNULL(e.SAL,0)) as DNAME_SAL
FROM EMP as e
	RIGHT OUTER JOIN DEPT as d ON (e.DEPTNO = d.DEPTNO)
GROUP BY d.DNAME;
	--step 4 display each dept's total salary sort by dept sal 
SELECT d.DNAME, SUM(ISNULL(e.SAL,0)) as DNAME_SAL
FROM EMP as e
	RIGHT OUTER JOIN DEPT as d ON (e.DEPTNO = d.DEPTNO)
GROUP BY d.DNAME
ORDER BY DNAME_SAL;

--- types of joins 
-- INNER JOIN	: matched rows
-- CROSS JOIN	: each row of left table joined with every row of right table 
-- LEFT OUTER JOIN : matched rows + extra rows in left table 
-- RIGHT OUTER JOIN : matched rows + extra rows in right table
-- FULL OUTER JOIN : matched rows + extra rows in left and right table

	
