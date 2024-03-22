--CREATE DATABASE LEE;

--USE LEE;

--CREATE TABLE [User] (
--    [email] VARCHAR(255) PRIMARY KEY NOT NULL,
--    [password] VARCHAR(255) NOT NULL,
--	[type] VARCHAR(20) NOT NULL
--);

--CREATE TABLE [Student] (
--    [roll_number] INT IDENTITY(1,1) PRIMARY KEY,
--    [phone_number] VARCHAR(20) NOT NULL,
--	[batch] INT NOT NULL,
--    [email] VARCHAR(255) FOREIGN KEY REFERENCES [User]([email]) NOT NULL
--);

--CREATE TABLE [Teacher] (
--    [roll_number] INT IDENTITY(1,1) PRIMARY KEY,
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
--	[total] INT  NOT NULL,
--	[obtained] INT  NOT NULL,
--	[Weightage] INT NOT NULL,
--	[subject_id] INT FOREIGN KEY REFERENCES [Subject]([id]) NOT NULL
--);

--CREATE TABLE [Attendance](
--    [id] INT IDENTITY(1,1) PRIMARY KEY  NOT NULL,
--	[status] BIT NOT NULL,
--	[date] DATE NOT NULL,
--	[student_email] VARCHAR(255) FOREIGN KEY REFERENCES [User]([email]) NOT NULL,
--	[subject_id] INT FOREIGN KEY REFERENCES [Subject]([id]) NOT NULL,
--);


INSERT INTO [User] ([email], [password], [type])
VALUES ('abdullahshahid210@gmail.com', 'open sesame','Admin');

SELECT * FROM [User] where [email] = 'email' and [password] = 'password'