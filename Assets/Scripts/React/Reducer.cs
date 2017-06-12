using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reducer
{
    public virtual void process(ref GlobalState state, ReactAction action)
    {
    }

    protected T GetValue<T>(ReactAction action, string key)
    {
        object value;
        action.TryGetValue(key, out value);

        if (value != null)
        {
            return (T)value;
        }

        return default(T);
    }
}
