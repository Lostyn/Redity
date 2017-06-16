using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using React;

public struct KeyboardState
{
    public Text target;
    public bool isMaj;
    public string value;
}


public class KeyboardReducer : Reducer
{
    public override object DefaultState()
    {
        return new KeyboardState();
    }

    public override void process(ref ExpendoObject state, ExpendoObject action)
    {
        string type = action.Get<string>("type");
        KeyboardState s = state.Get<KeyboardState>("keyboard");

        switch (type)
        {
            case KeyboardActionTypes.SET_TARGET:
                s.target = action.Get<Text>("target");
                s.value = s.target.text;
                break;
            case KeyboardActionTypes.TOOGLE_MAJ:
                s.isMaj = !s.isMaj;
                break;
            case KeyboardActionTypes.ADD_CHAR:
                s.value += action.Get<string>("char");
                break;
            case KeyboardActionTypes.REMOVE_CHAR:
                if (!string.IsNullOrEmpty(s.value))
                    s.value = s.value.Remove(s.value.Length - 1);
                break;
            case KeyboardActionTypes.VALID:
                s.target = null;
                s.value = "";
                break;
        }
        
        state["keyboard"] = s;
    }
}
