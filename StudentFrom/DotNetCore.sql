Create Database DotNetCore;

Create Table Student(
       Id bigint IDENTITY(1,1) NOT NULL,
		Name varchar(255) NOT NULL,
		Email varchar(255) NOT NULL,
		Phone  varchar(255) NOT NULL,
		Address Varchar(255) NOT NULL,
		--[CONSTRAINT constraint_name] PRIMARY KEY (column1)
		CONSTRAINT PK PRIMARY KEY (Id)
);

Insert Into Student(Name,Email,Phone,Address)
Values('Rahim','rahim@gmail.com','01771761169','Khulna');

Insert Into Student(Name,Email,Phone,Address)
Values('Karim','Karim@gmail.com','01771761168','Dhaka');

  --[CONSTRAINT constraint_name] PRIMARY KEY (column1)

Create Table Course(
  Id bigint IDENTITY(1,1) NOT NULL,
  Title varchar(255) NOT NULL,
  Credit bigint NOT NULL,
    --[CONSTRAINT constraint_name] PRIMARY KEY (column1)

  CONSTRAINT PK1 PRIMARY KEY (Id)
);

Insert Into Course(Title,Credit)
Values('CSE 1101',3);
Insert Into Course(Title,Credit)
Values('CSE 1102',2);

  --CREATE TABLE TABLE_2(COLUMN_NAME FOREIGN KEY REFERENCES TABLE_1(COLUMN_NAME));
  --FOREIGN KEY(StudentId) REFERENCES Student(StudentId)

  Create Table StudentCourse(
   Id bigint IDENTITY(1,1) NOT NULL,
   StudentId bigint NOT NULL,
   CourseId bigint NOT NULL,
     --[CONSTRAINT constraint_name] PRIMARY KEY (column1)

   CONSTRAINT PK2 PRIMARY KEY (Id),
   FOREIGN KEY(CourseId) REFERENCES Course(Id),
   FOREIGN KEY(StudentId) REFERENCES Student(Id),
);

Insert Into StudentCourse(StudentId,CourseId)
Values(1,1);
Insert Into StudentCourse(StudentId,CourseId)
Values(2,1);

Select *from Student;
Select *from Course;
Select *from StudentCourse;

Drop Table Student;
Drop Table StudentCourse;
Drop Table Course;