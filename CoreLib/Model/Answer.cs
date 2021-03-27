using CoreLib.Common;

namespace CoreLib.Model
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
