using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using React;
using System;

public class KeyboardState
{
    public Text target;
    public bool isMaj;
    public string value;
}


public class KeyboardReducer : ReducerBase<KeyboardState>
{
    public KeyboardReducer(string key) : base(key) { }

    public override KeyboardState Reduce(KeyboardState state, ExpendoObject action)
    {
        string type = action.Get<string>("type");

        switch (type)
        {
            case KeyboardActionTypes.SET_TARGET:
                state.target = action.Get<Text>("target");
                state.value = state.target.text;
                break;
            case KeyboardActionTypes.TOOGLE_MAJ:
                state.isMaj = !state.isMaj;
                break;
            case KeyboardActionTypes.ADD_CHAR:
                state.value += action.Get<string>("char");
                break;
            case KeyboardActionTypes.REMOVE_CHAR:
                if (!string.IsNullOrEmpty(state.value))
                    state.value = state.value.Remove(state.value.Length - 1);
                break;
            case KeyboardActionTypes.VALID:
                state.target = null;
                state.value = "";
                break;
        }

        return state;
    }
}
