using System;
using System.Drawing;

namespace SystemVerifyKnowledge.Common.Interface
{
    public interface IQueryResult
    {
        (byte id, string name)[] LoadAllDirections();

        ulong? GetUserId(SignIn signIn);

        Student? GetStudent(SignIn signIn);
        string LoadDirectionName(byte programGroupId);

        (byte id, string name, byte number)[] LoadProgramsByDirecionAndType(byte directionID, int testType);

        (string name, byte number)? LoadProgramByProgramGroupId(byte programGroupId);

        DateTime[] LoadTestingDates();

        (string surname
            , string firstname
            , string lastname
            , byte programGroupId
            , DateTime dateStartTest
            , DateTime dateEndTest
            , uint passportNumber
            , ushort passportSerie)?
            LoadUserById(ulong userId);

        bool InsertNewUser(string firstname,
            string surname,
            string lastname,
           ushort passportSerie,
           uint passportNumber,
           DateTime startDate,
           DateTime endDate,
           string password,
           ulong programGroupID);

        (ulong id, string password)? FindPassword(uint passportSerie, uint passportNumber);

        ulong[] LoadQuestionIds(ulong testId, int exerciseType);

        (ulong userID, ulong testingDateId)[] LoadUsersResultByTestingDate(string testingDate);

        ulong LoadTestIdByProgramGroupIdAndType(ulong programGroupID, int testType);

        (byte numberCorrectAnswer, byte numberIncorrectanswers, byte points)? LoadTestResult(ulong testingDateId, int exerciseType);

        (string description, Image image)? LoadQuestion(ulong questionId);

        (ulong id, string description)[] LoadAnswers(ulong questionId);

        byte LoadSumPoints(ulong[] answerIds);

        void WriteTestResults(ulong userId, ulong programGroupId, (int type, byte points, byte trueAnswers, byte falseAnswers)[] exercises);
    }
}
