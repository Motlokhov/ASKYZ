using CoreLib.Common;

namespace CoreLib.Testing
{
    public class Answer:Entity
    {       
        public Answer(ulong answerID,string name)
        {
            _id = answerID;
            _name = name;
        }


    }
}
