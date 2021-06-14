INSERT INTO Direction (Id,Name) 
VALUES 
(1, N'Росавтодор'),
(2, N'Росжелдор')
;

Insert into programgroup(Id,Name,Number,DirectionId)
VALUES
(1, N'Программа №1 (автодор)', 1, 1),
(2, N'Программа №1 (желдор)', 1, 2)
;