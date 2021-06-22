namespace SystemVerifyKnowledge.Common.Interface
{
    public interface IGrandExerciseModel : IModel
    {
        void LoadFor(Student student);

        void VerifyAnswers(ulong[] answersIds);

        void TestEnd();
    }
}
