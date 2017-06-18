using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

namespace React
{
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