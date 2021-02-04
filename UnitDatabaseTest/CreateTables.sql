Create table Direction
(
	Id tinyint primary key,
	Name nvarchar(300) not null
);

Create table ProgramGroup
(
	Id tinyint primary key,
	Name nvarchar(300) not null,
	Number tinyint not null,
	DirectionId tinyint not null,
	constraint fk_direction_programgroup foreign key (DirectionId) references Direction(Id)
);

create table [User]
(
  Id bigint primary key,
  Surname nvarchar(100) null,
  Firstname nvarchar(100) null,
  Lastname nvarchar(100) null,
  ProgramGroupID tinyint not null,
  DateStartTest datetime not null,
  DateEndTest datetime not null,
  PassportSerie smallint not null,
  PassportNumber int not null,
  [Password] nvarchar(100) not null,
  constraint fk_programgroup_user foreign key (ProgramGroupId) references ProgramGroup(Id)
);

Create table TestingDate 
(
 Id bigint primary key,
 UserId bigint not null,
 ProgramGroupID tinyint not null,
 Date datetime not null,
 constraint fk_programgroup_testingdate foreign key(UserId) references [ProgramGroup](Id),
 constraint fk_user_testingdate foreign key(programGroupId) references [User](Id)
);

-- Это реальная таблица, а не плод воображения для тестирования концепции.
Create table Test
(
	Id tinyint primary key,
	Type tinyint not null,
	ProgramGroupId tinyint not null,
	constraint fk_programgroup_test foreign key(ProgramGroupId) references[ProgramGroup](Id)
);

Create table Question
(
	Id bigint primary key,
	Description nvarchar(2000) not null,
	Picture image null,
	QuestionType int not null,
	TestId tinyint not null,
	constraint fk_test_question foreign key(TestId) references [ProgramGroup](Id)
);

Create table Answer
(
	Id bigint primary key,
	QuestionID bigint not null,
	Description nvarchar(2000) not null,
	Points tinyint not null,
	constraint fk_question_answer foreign key(QuestionId) references[Question](Id)
);

Create table TestingResult
(	
	TestingDateID bigint not null,
	ExerciseType tinyint not null,
	Points tinyint not null,
	TrueAnswers tinyint not null,
	FalseAnswers tinyint not null,
	constraint fk_testingdate_testingresult foreign key(TestingDateId) references TestingDate(id)
);

