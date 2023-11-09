drop table Department
create table Department
(
	DpId int identity(1,1) primary key,
	DpName nvarchar(255) unique
);
create table Employee
(
	EmpId int identity(1,1) primary key,
	EmpName nvarchar(255),
	Gender int,
	DpId int,
	constraint FK_Employee_Department foreign key (DpId) references Department(DpId)
);
ALTER TABLE Employee
ADD CONSTRAINT CK_Gender
CHECK (Gender IN (0, 1));