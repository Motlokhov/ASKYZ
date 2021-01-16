using System;
using System.Collections.Generic;

namespace CoreLib.Common
{
    public class ChildrenList:List<object>
    {
        protected int _index;

        public void Next()
        {
            _index++;
        }

        public void Previous()
        {
            _index--;
        }

        public object Current()
        {
            return this[_index];
        }

        public int GetIndex()
        {
            return _index;
        }

        public void GoToIndex(int index)
        {
            if( Count > index )
            {
                _index = index;
                return;
            }
            throw new Exception("Out of range exeption: Выход за пределы массива("+this.ToString()+")");
            
        }

        public bool HasNextIndex()
        {
            if(_index + 1 < Count )
            {
                return true;
            }
            return false;
        }

        public bool HasPreviousIndex()
        {
            if(_index > 0 )
            {
                return true;
            }
            return false;
        }
    }
}
