using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace React
{
    public abstract class ReducerBase<TState> : IReducer {

        public string key;

        public ReducerBase(string key)
        {
            this.key = key;
        }

        public string GetKey()
        {
            return this.key;
        }
        public object GetDefaultState()
        {
            return Activator.CreateInstance<TState>();
        }

        public abstract TState Reduce(TState state, ExpendoObject action);

        public object ReduceAny(object state, ExpendoObject action)
        {
            return this.Reduce((TState)state, action);
        }
    }
}
