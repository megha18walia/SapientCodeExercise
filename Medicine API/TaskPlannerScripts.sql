CREATE TAble [dbo].[User]
(
UserID varchar(200) primary key,
Username varchar(max) not null,
Email varchar(max) not null
)

GO

CREATE Table [dbo].[Portfolio]
(
PortfolioID UNIQUEIdentifier primary key,
PortfolioName  varchar(max) Not Null,
PortfolioDescription varchar(max),
CreatedDate datetime,
CreatedBy varchar(200) foreign key references [dbo].[User](UserID),
)

GO

Create Table [dbo].[Project]
(
ProjectID UNIQUEIdentifier primary key,
ProjectName varchar(max) Not null,
ProjectDescription varchar(max),
CreatedDate datetime,
CreatedBy varchar(200) foreign key references [dbo].[User](UserID),
PortfolioID UNIQUEIdentifier references Portfolio (PortfolioID)
)
GO
CREATE Table TaskStatus
(
StatusID int primary key,
StatusName varchar(max) Not Null 
)
GO

Create Table TaskPriority
(
PriorityID int primary key,
PriorityName varchar(max)
)
GO 



CREATE TABLE [dbo].[Task]
(
TaskID UNIQUEIdentifier primary key,
TaskName varchar(max) Not Null,
TaskDescription varchar(max) not null,
CreatedDate datetime,
CraetedBy varchar(200) foreign key references [dbo].[User](UserID),
[Priority] int Foreign key references TaskPriority(PriorityId),
DueDate datetime,
[Status] int Foreign key references TaskStatus(StatusID)
)

GO

Create TAble TaskAssignment
(
AssignmentID UNIQUEIdentifier primary key,
TaskID UNIQUEIdentifier Foreign key references Task(TaskID),
AssignedTo varchar(200) foreign key references [dbo].[User](UserID),
AssignmentDate datetime not null,
Comment varchar(max)
)