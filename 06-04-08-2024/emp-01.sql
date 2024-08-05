-- create emp search db 
CREATE DATABASE emp_search_db;
-- To use emp_search_db
USE emp_search_db;

-- create emp and dept tables and insert data on them
CREATE TABLE DEPT (
    DEPTNO INT PRIMARY KEY,
    DNAME VARCHAR(50),
    LOC VARCHAR(50)
);

INSERT INTO DEPT (DEPTNO, DNAME, LOC) VALUES
(10, 'ACCOUNTING', 'NEW YORK'),
(20, 'RESEARCH', 'DALLAS'),
(30, 'SALES', 'CHICAGO'),
(40, 'OPERATIONS', 'BOSTON');

CREATE TABLE EMP (
    EMPNO INT PRIMARY KEY,
    ENAME VARCHAR(50),
    JOB VARCHAR(50),
    MGR INT,
    HIREDATE DATE,
    SAL DECIMAL(10, 2),
    COMM DECIMAL(10, 2),
    DEPTNO INT,
    FOREIGN KEY (DEPTNO) REFERENCES DEPT(DEPTNO)
);

INSERT INTO EMP (EMPNO, ENAME, JOB, MGR, HIREDATE, SAL, COMM, DEPTNO) VALUES
(7369, 'SMITH', 'CLERK', 7902, '2010-12-17', 800.00, NULL, 20),
(7499, 'ALLEN', 'SALESMAN', 7698, '2011-02-20', 1600.00, 300.00, 30),
(7521, 'WARD', 'SALESMAN', 7698, '2011-02-22', 1250.00, 500.00, 30),
(7566, 'JONES', 'MANAGER', 7839, '2011-04-02', 2975.00, NULL, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, '2011-09-28', 1250.00, 1400.00, 30),
(7698, 'BLAKE', 'MANAGER', 7839, '2011-05-01', 2850.00, NULL, 30),
(7782, 'CLARK', 'MANAGER', 7839, '2011-06-09', 2450.00, NULL, 10),
(7788, 'SCOTT', 'ANALYST', 7566, '2012-12-09', 3000.00, NULL, 20),
(7839, 'KING', 'PRESIDENT', NULL, '2011-11-17', 5000.00, NULL, 10),
(7844, 'TURNER', 'SALESMAN', 7698, '2011-09-08', 1500.00, 0.00, 30),
(7876, 'ADAMS', 'CLERK', 7788, '2013-01-12', 1100.00, NULL, 20),
(7900, 'JAMES', 'CLERK', 7698, '2011-12-03', 950.00, NULL, 30),
(7902, 'FORD', 'ANALYST', 7566, '2011-12-03', 3000.00, NULL, 20),
(7934, 'MILLER', 'CLERK', 7782, '2012-01-23', 1300.00, NULL, 10);


-- To drop emp_search_db
-- DROP DATABASE emp_search_db;

-- display departments
SELECT * FROM dept;

-- display departments by deptno
SELECT DEPTNO, DNAME, LOC 
FROM DEPT 
WHERE DEPTNO = 20;

-- display departments by dname
SELECT DEPTNO, DNAME, LOC 
FROM DEPT 
WHERE DNAME = 'RESEARCH';

-- display departments by LOC
SELECT DEPTNO, DNAME, LOC 
FROM DEPT 
WHERE LOC = 'CHICAGO';

-- display all employees 
SELECT * FROM EMP;

-- display employee by EMPNO 
SELECT EMPNO, ENAME, JOB, 
    MGR, HIREDATE, SAL, COMM, DEPTNO  
FROM EMP
WHERE EMPNO=7566;

-- display employee by ENAME 
SELECT EMPNO, ENAME, JOB, 
    MGR, HIREDATE, SAL, COMM, DEPTNO  
FROM EMP
WHERE ENAME='JONES';

-- display JONES colleges by DEPTNO 
SELECT EMPNO, ENAME, JOB, 
    MGR, HIREDATE, SAL, COMM, DEPTNO  
FROM EMP
WHERE DEPTNO=20;

--display employees of job title CLERK
SELECT EMPNO, ENAME, JOB, 
    MGR, HIREDATE, SAL, COMM, DEPTNO  
FROM EMP
WHERE JOB='CLERK';

--display employees who joined in year 2013
SELECT EMPNO, ENAME, JOB, 
    MGR, HIREDATE, SAL, COMM, DEPTNO  
FROM EMP
WHERE year(HIREDATE)='2013';

--display employees who joined in year 2011
SELECT EMPNO, ENAME, JOB, 
    MGR, HIREDATE, SAL, COMM, DEPTNO  
FROM EMP
WHERE year(HIREDATE)='2011';

--display employees who joined in year 2011 and sort by name
SELECT EMPNO, ENAME, JOB, 
    MGR, HIREDATE, SAL, COMM, DEPTNO  
FROM EMP
WHERE year(HIREDATE)='2011'
ORDER BY ENAME;

--display employees who joined in year 2011 and sort by name Z-A
SELECT EMPNO, ENAME, JOB, 
    MGR, HIREDATE, SAL, COMM, DEPTNO  
FROM EMP
WHERE year(HIREDATE)='2011'
ORDER BY ENAME DESC;

--display employees who joined in year 2011 and sort by SAL ascending
SELECT EMPNO, ENAME, JOB, 
    MGR, HIREDATE, SAL, COMM, DEPTNO  
FROM EMP
WHERE year(HIREDATE)='2011'
ORDER BY SAL;

--display employees who joined in year 2011 and sort by SAL ascending then by name A-Z
--to sort ascending | A-Z "ORDER BY col ASC", descending | Z-A: "ORDER BY col DESC"
SELECT EMPNO, ENAME, JOB, 
    MGR, HIREDATE, SAL, COMM, DEPTNO  
FROM EMP
WHERE year(HIREDATE)='2011'
ORDER BY SAL, ENAME;

--display employees who joined in year 2011 and sort by SAL descending
SELECT EMPNO, ENAME, JOB, 
    MGR, HIREDATE, SAL, COMM, DEPTNO  
FROM EMP
WHERE year(HIREDATE)='2011'
ORDER BY SAL DESC;

--display employees who joined in year 2011 and sort by SAL descending then by name A-Z
SELECT EMPNO, ENAME, JOB, 
    MGR, HIREDATE, SAL, COMM, DEPTNO  
FROM EMP
WHERE year(HIREDATE)='2011'
ORDER BY SAL DESC, ENAME;

