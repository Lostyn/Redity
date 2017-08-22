using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace Rednity
{
    [Serializable]
    public class ExpendoObject : Dictionary<string, object>
    {
        public T Get<T>(string key)
        {
            object value;
            TryGetValue(key, out value);

            return (T)value;
        }
    }
}