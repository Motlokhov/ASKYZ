using System.Collections.Generic;

namespace SystemVerifyKnowledge.CoreLib.Common
{
    public class ChildrenList<T>:List<T>
    {
        public int Index { get; private set; }

        public void SetNext() => Index++;

        public void SetPrevious() => Index--;

        public T Current() => this[Index];

        public bool HasNext => Index + 1 < Count;

        public bool HasPrevious => Index > 0;
    }
}
