
using System;
using System.Data;


namespace Core.Testing
{
    using Common;
   public class Answer:Entity
    {       
        public Answer(ulong answerID,string name)
        {
            _id = answerID;
            _name = name;
        }


    }
}
