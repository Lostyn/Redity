using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace React
{
    [Serializable]
    public class Container : ScriptableObject
    {
        public ExpendoObject defaultState;

        public Container()
        {
            Init();
        }

        protected virtual void Init() { }

    }
}