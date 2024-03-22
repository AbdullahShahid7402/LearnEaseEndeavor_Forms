--CREATE DATABASE LEE;

--USE LEE;

--CREATE TABLE [User] (
--    [email] VARCHAR(255) PRIMARY KEY NOT NULL,
--    [password] VARCHAR(255) NOT NULL,
--	[type] VARCHAR(20) NOT NULL
--);

--CREATE TABLE [Student] (
--    [roll_number] INT IDENTITY(1,1) PRIMARY KEY,
--    [name] VARCHAR(255) NOT NULL,
--    [phone_number] VARCHAR(20) NOT NULL,
--	[batch] INT NOT NULL,
--    [email] VARCHAR(255) FOREIGN KEY REFERENCES [User]([email]) NOT NULL
--);

--CREATE TABLE [Teacher] (
--    [roll_number] INT IDENTITY(1,1) PRIMARY KEY,
--    [name] VARCHAR(255) NOT NULL,
--    [phone_number] VARCHAR(20) NOT NULL,
--	[visiting] BIT NOT NULL,
--    [email] VARCHAR(255) FOREIGN KEY REFERENCES [User]([email]) NOT NULL
--);

--CREATE TABLE [Subject] (
--    [id] INT IDENTITY(1,1) PRIMARY KEY,
--    [name] VARCHAR(255) NOT NULL,
--	[section] CHAR NOT NULL,
--    [email_student] VARCHAR(255) FOREIGN KEY REFERENCES [User]([email]) NOT NULL,
--    [email_teacher] VARCHAR(255) FOREIGN KEY REFERENCES [User]([email]) NOT NULL
--);

--CREATE TABLE [Assignment](
--    [id] INT IDENTITY(1,1) PRIMARY KEY  NOT NULL,
--	[name] VARCHAR(255)  NOT NULL,
--  [description] VARCHAR(255)  NOT NULL,
--	[total] INT  NOT NULL,
--	[obtained] INT  NOT NULL,
--	[Weightage] INT NOT NULL,
--	[subject_id] INT FOREIGN KEY REFERENCES [Subject]([id]) NOT NULL
--);

--CREATE TABLE [Attendance](
--    [id] INT IDENTITY(1,1) PRIMARY KEY  NOT NULL,
--	[status] VARCHAR(255) NOT NULL,
--	[date] DATE NOT NULL,
--	[student_id] INT FOREIGN KEY REFERENCES [Student]([roll_number]) NOT NULL,
--	[subject_id] INT FOREIGN KEY REFERENCES [Subject]([id]) NOT NULL,
--);


INSERT INTO [User] ([email], [password], [type])
VALUES ('abdullahshahid210@gmail.com', 'open sesame','Admin');

INSERT INTO [User] ([email], [password], [type])
VALUES ('i210721@nu.edu.pk', 'open sesame','Student');
INSERT INTO [User] ([email], [password], [type])
VALUES ('i210574@nu.edu.pk', 'rizi','Student');
INSERT INTO [User] ([email], [password], [type])
VALUES ('i210788@nu.edu.pk', 'binnu','Student');

INSERT INTO [User] ([email], [password], [type])
VALUES ('sidra.khalid@nu.edu.pk', '1234','Teacher');

INSERT INTO [Student] ([name], [phone_number], [batch], [email])
VALUES ('Abdullah Shahid Butt','012392912312',21,'i210721@nu.edu.pk');
INSERT INTO [Student] ([name], [phone_number], [batch], [email])
VALUES ('Rizwan Salim','2165542',21,'i210574@nu.edu.pk');
INSERT INTO [Student] ([name], [phone_number], [batch], [email])
VALUES ('Mubeen Qaiser','0232134655',21,'i210788@nu.edu.pk');

INSERT INTO [Teacher] ([name], [phone_number], [email], [visiting])
VALUES ('Sidra Khalid','03546565452','sidra.khalid@nu.edu.pk',0);
select * from [Teacher]

INSERT INTO [Subject] ([name], [section], [email_student], [email_teacher])
VALUES ('Software Engineering', 'F', 'i210721@nu.edu.pk', 'sidra.khalid@nu.edu.pk');
INSERT INTO [Subject] ([name], [section], [email_student], [email_teacher])
VALUES ('Software Engineering', 'F', 'i210574@nu.edu.pk', 'sidra.khalid@nu.edu.pk');
INSERT INTO [Subject] ([name], [section], [email_student], [email_teacher])
VALUES ('Software Engineering', 'F', 'i210788@nu.edu.pk', 'sidra.khalid@nu.edu.pk');

Select [Student].[roll_number],[Student].[name],0 as attendance from [Student] where [Student].[email] in (Select [Subject].[email_student] from [Subject] where [Subject].[name] = 'Software Engineering' and [Subject].[section] = 'F')

INSERT INTO Attendance (status, date, student_id, subject_id) VALUES ('Present', '2024-03-25', 12345, 1);

select *  from [Attendance]