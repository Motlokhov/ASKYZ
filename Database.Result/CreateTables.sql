Create database Askyz;

Create table Answer
(
	Id bigint primary key,
	QuestionID bigint not null,
	Description nvarchar(2000) not null,
	Points tinyint not null
)

Create table Direction
(
	Id tinyint primary key,
	Name nvarchar(300) not null
)

Create table ProgramGroup
(
	Id tinyint primary key,
	Name nvarchar(300) not null,
	Number tinyint not null,
	DirectionId tinyint not null
)

Create table Question
(
	Id bigint primary key,
	Description nvarchar(2000) not null,
	Picture image null,
	QuestionType int not null,
	TestId tinyint not null,
)

-- Это реальная таблица, а не плод воображения для тестирования концепции.
Create table Test
(
	Id tinyint primary key,
	Type tinyint not null,
	ProgramGroupId tinyint not null
)

Create table TestingDate 
(
 Id bigint primary key,
 UserId bigint not null,
 ProgramGroupID tinyint not null,
 Date datetime not null
)

Create table TestingResult
(	
	TestingDateID bigint not null,
	ExerciseType tinyint not null,
	Points tinyint not null,
	TrueAnswers tinyint not null,
	FalseAnswers tinyint not null
)

create table [User]
(
  Id bigint  primary key,
  Surname nvarchar(100) null,
  Firstname nvarchar(100) null,
  Lastname nvarchar(100) null,
  ProgramGroupID tinyint not null,
  DateStartTest datetime not null,
  DateEndTest datetime not null,
  PassportSerie smallint not null,
  PassportNumber int not null,
  [Password] nvarchar(100) not null,
)

alter table Answer 
add constraint fk_question_answer
foreign key (QuestionId)
references Question(Id);
go

alter table Question 
add constraint fk_test_question
foreign key (TestId) references Test(Id);
go 

alter table Test
add constraint fk_programGroup_test
foreign key (ProgramGroupId) references ProgramGroup(Id);
go

alter table ProgramGroup
add constraint fk_direction_programGroup
foreign key (DirectionId) references Direction(Id);
go

alter table TestingResult
add constraint fk_testingdate_testingresult
foreign key (TestingDateId) references TestingDate(Id);
go

alter table TestingDate
add constraint fk_user_testingdate
foreign key (UserId) references [User](Id);
go

alter table TestingDate
add constraint fk_programgroup_testingdate
foreign key (ProgramGroupId) references ProgramGroup(Id)
go

