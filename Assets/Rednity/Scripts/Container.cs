using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Rednity
{
    [Serializable]
    public class Container : ScriptableObject
    {
        public ExpendoObject defaultState = new ExpendoObject();
        public List<IReducer> reducers = new List<IReducer>();

        public virtual void Init() { }

        protected void AddReducer(IReducer reducer)
        {
            defaultState[reducer.GetKey()] = reducer.GetDefaultState();
            reducers.Add(reducer);
        }
    }
}