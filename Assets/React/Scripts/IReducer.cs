using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace React
{
    public interface IReducer {

        string GetKey();
        object GetDefaultState();
        object ReduceAny(object state, ExpendoObject action);

    }
}
