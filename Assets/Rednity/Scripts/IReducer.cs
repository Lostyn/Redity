using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rednity
{
    public interface IReducer {

        string GetKey();
        object GetDefaultState();
        object ReduceAny(object state, ExpendoObject action);

    }
}
