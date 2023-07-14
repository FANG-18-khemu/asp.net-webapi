create table DeptInfo(
DeptNO int  primary key,
DeptName varchar(40),
DeptLocation varchar(20)
)

select * from DeptInfo


insert into DeptInfo values(1,'science','second floor')
insert into DeptInfo values(2,'Maths','ground floor')
insert into DeptInfo values(3,'Sports','top floor')
insert into DeptInfo values(4,'English','5th floor')
insert into DeptInfo values(5,'Computers','1st floor')




create table EmpInfo(
EmpNo int primary key,
EmpName varchar(20),
EmpDesignation varchar(50),
EmpSalary int,
EmpIsPresent bit,
EmpDept int FOREIGN KEY REFERENCES DeptInfo(DeptNO) 
)

select * from EmpInfo

insert into EmpInfo values(1,'ravi','sr maths teacher',1999,0,1)
insert into EmpInfo values(2,'ram','jr maths teacher',19995,1,1)
insert into EmpInfo values(3,'ravi kumar','sports teacher',10999,1,4)
insert into EmpInfo values(4,'khem','Principle',1955909,1,3)
insert into EmpInfo values(5,'arihant','sr computer teacher',3434,1,2)
insert into EmpInfo values(6,'aniket','sr sports teacher',1559,1,1)
insert into EmpInfo values(7,'diyanshu','master esports teacher',193499,0,2)
insert into EmpInfo values(8,'Ashu','jr attitude teacher',192399,0,3)
insert into EmpInfo values(9,'Bhavu','sr communication teacher',194399,0,4)
insert into EmpInfo values(10,'Rohit','jr games teacher',194399,1,5)

