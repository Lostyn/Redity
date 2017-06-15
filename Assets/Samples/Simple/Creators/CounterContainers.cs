using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using React;

[CreateAssetMenu(menuName = "ReactContainers/counterContainer", fileName="CounterContainer")]
public class CounterContainers : Container {

    public override void Init()
    {
        KeyboardReducer keybord = new KeyboardReducer();

        defaultState = new ExpendoObject();
        defaultState["count"] = 1;
        defaultState["keyboard"] = keybord.DefaultState();

        reducers = new List<Reducer>();
        reducers.Add(new CounterReducer());
        reducers.Add(keybord);
    }
}
