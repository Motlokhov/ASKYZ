begin tran
DECLARE @start INT = 1;
DECLARE @end INT = 50;
DECLARe @testId int = 1;

WITH numbers AS (
    SELECT @start AS number
    UNION ALL
    SELECT number + 1 
    FROM  numbers
    WHERE number < @end
)

-- common
insert Question
SELECT 
number as id
    , concat(N'Вопрос common № ', number, N' для теста № ', @testId) as question
    , null as picture
    , 0 as type
    , @testId as testid
FROM numbers
OPTION (MAXRECURSION 0);


select * from Question

insert Answer
select 
    (select isnull(max(id),0) from Answer) + ROW_NUMBER() over( order by answers.questionId) as answerId
    , answers.questionId
    , answers.answer
    , answers.points
from (
select q.Id as questionId, concat(N'Oтвет 1 для вопроса ',q.id) as answer, 0 as points  from Question as q
union
select q.Id, concat(N'Oтвет 2 для вопроса ',q.id), 0  from Question as q
union
select q.Id, concat(N'Oтвет 3 для вопроса ',q.id), 0  from Question as q
union
select q.Id, concat(N'Oтвет 4 для вопроса ',q.id), 1  from Question as q) as answers

-- themen
insert Question(Id,Description,TestId,Type)
select (select max(id) from Question) + 1, concat(N'Вопрос 1 themen для теста ',@testId), @testId, 1

Declare @quid int = (select max(id) from Question)

insert Answer(Id,Description,Points,QuestionID)
select (select max(id) from Answer) + 1, concat(N'Ответ 1 для вопроса №', @quid), 5, @quid

insert Answer(Id,Description,Points,QuestionID)
select (select max(id) from Answer) + 1, concat(N'Ответ 2 для вопроса №', @quid), 5, @quid

insert Answer(Id,Description,Points,QuestionID)
select (select max(id) from Answer) + 1, concat(N'Ответ 3 для вопроса №', @quid), 0, @quid

--
insert Question(Id,Description,TestId,Type)
select (select max(id) from Question) + 1, concat(N'Вопрос 2 themen для теста ',@testId), @testId, 1

Set @quid = (select max(id) from Question)

insert Answer(Id,Description,Points,QuestionID)
select (select max(id) from Answer) + 1, concat(N'Ответ 1 для вопроса №', @quid), 5, @quid

insert Answer(Id,Description,Points,QuestionID)
select (select max(id) from Answer) + 1, concat(N'Ответ 2 для вопроса №', @quid), 5, @quid

insert Answer(Id,Description,Points,QuestionID)
select (select max(id) from Answer) + 1, concat(N'Ответ 3 для вопроса №', @quid), 0, @quid

--
insert Question(Id,Description,TestId,Type)
select (select max(id) from Question) + 1, concat(N'Вопрос 3 themen для теста ',@testId), @testId, 1

Set @quid = (select max(id) from Question)

insert Answer(Id,Description,Points,QuestionID)
select (select max(id) from Answer) + 1, concat(N'Ответ 1 для вопроса №', @quid), 5, @quid

insert Answer(Id,Description,Points,QuestionID)
select (select max(id) from Answer) + 1, concat(N'Ответ 2 для вопроса №', @quid), 5, @quid

insert Answer(Id,Description,Points,QuestionID)
select (select max(id) from Answer) + 1, concat(N'Ответ 3 для вопроса №', @quid), 0, @quid

-- practical
insert Question(Id,Description,TestId,Type)
select (select max(id) from Question) + 1, concat(N'Вопрос 1 practical для теста ',@testId), @testId, 2

Set @quid = (select max(id) from Question)

insert Answer(Id,Description,Points,QuestionID)
select (select max(id) from Answer) + 1, concat(N'Ответ 1 для вопроса №', @quid), 20, @quid

insert Answer(Id,Description,Points,QuestionID)
select (select max(id) from Answer) + 1, concat(N'Ответ 2 для вопроса №', @quid), 10, @quid

insert Answer(Id,Description,Points,QuestionID)
select (select max(id) from Answer) + 1, concat(N'Ответ 3 для вопроса №', @quid), 0, @quid

--
insert Question(Id,Description,TestId,Type)
select (select max(id) from Question) + 1, concat(N'Вопрос 2 practical для теста ',@testId), @testId, 2

Set @quid = (select max(id) from Question)

insert Answer(Id,Description,Points,QuestionID)
select (select max(id) from Answer) + 1, concat(N'Ответ 1 для вопроса №', @quid), 20, @quid

insert Answer(Id,Description,Points,QuestionID)
select (select max(id) from Answer) + 1, concat(N'Ответ 2 для вопроса №', @quid), 10, @quid

insert Answer(Id,Description,Points,QuestionID)
select (select max(id) from Answer) + 1, concat(N'Ответ 3 для вопроса №', @quid), 0, @quid

--
insert Question(Id,Description,TestId,Type)
select (select max(id) from Question) + 1, concat(N'Вопрос 3 practical для теста ',@testId), @testId, 2

Set @quid = (select max(id) from Question)

insert Answer(Id,Description,Points,QuestionID)
select (select max(id) from Answer) + 1, concat(N'Ответ 1 для вопроса №', @quid), 20, @quid

insert Answer(Id,Description,Points,QuestionID)
select (select max(id) from Answer) + 1, concat(N'Ответ 2 для вопроса №', @quid), 10, @quid

insert Answer(Id,Description,Points,QuestionID)
select (select max(id) from Answer) + 1, concat(N'Ответ 3 для вопроса №', @quid), 0, @quid

select * from Question
select * from Answer
rollback