using SystemVerifyKnowledge.CoreLib.Common;

namespace SystemVerifyKnowledge.CoreLib.Model
{
    public class Answer:Entity
    {       
        public Answer(ulong answerID,string name)
        {
            Id = answerID;
            Name = name;
        }


    }
}
