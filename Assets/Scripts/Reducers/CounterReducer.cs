using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using React;

public class CounterReducer : Reducer {

	public override void process(ref GlobalState state, ReactAction action)
    {
        string type = GetValue<string>(action, "type");

        switch (type.ToString())
        {
            case "INCREMENT":
                int value = GetValue<int>(action, "value");
                state.count += value;
                break;
            case "DECREMENT":
                state.count--;
                break;
        }
    }
}
