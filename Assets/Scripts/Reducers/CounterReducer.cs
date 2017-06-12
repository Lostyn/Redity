using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using React;

public class CounterReducer : Reducer {

	public override void process(ref ExpendoObject state, ExpendoObject action)
    {
        string type = action.Get<string>("type");

        switch (type.ToString())
        {
            case "INCREMENT":
                int value = action.Get<int>("value");
                state["count"] = state.Get<int>("count") + value;
                break;
            case "DECREMENT":
                state["count"] = state.Get<int>("count") - 1;
                break;
        }
    }
}
