using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EnumSequence
{

    enum Sport { Football, Baseball, Basketball, Hockey, Boxing, Rugby, Fencing, }
    class ManualSportSequence : IEnumerable<Sport>
    {

        public IEnumerator<Sport> GetEnumerator()
        {
            return new ManualSportEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    class ManualSportEnumerator : IEnumerator<Sport>
    {
        int current = -1;
        public Sport Current { get => (Sport)current; }
        public void Dispose() { return; }

        object IEnumerator.Current { get => Current; }

        public bool MoveNext()
        {
            var maxEnumValue = Enum.GetValues(typeof(Sport)).Length;
            if ((int)current >= maxEnumValue - 1)
                return false;
            current++;
            return true;

        }

        public void Reset() { current = 0; }

    }

}
