using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace React
{
    public class Reducer
    {
        public virtual object DefaultState()
        {
            return null;
        }

        public virtual void process(ref ExpendoObject state, ExpendoObject action)
        {
        }
    }
}
