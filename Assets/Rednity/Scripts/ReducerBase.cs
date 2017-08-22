using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Rednity
{
    public abstract class ReducerBase<TState> : IReducer
    {

        public string key;
        TState cachedDefaultState;

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
            if (cachedDefaultState == null)
                cachedDefaultState = Activator.CreateInstance<TState>();

            return cachedDefaultState;
        }

        public abstract TState Reduce(TState state, ExpendoObject action);

        public object ReduceAny(object state, ExpendoObject action)
        {
            return this.Reduce((TState)state, action);
        }
    }
}
