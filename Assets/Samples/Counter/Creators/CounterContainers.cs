using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using React;

[CreateAssetMenu(menuName = "ReactContainers/counterContainer", fileName="CounterContainer")]
public class CounterContainers : Container {

    public override void Init()
    {
        defaultState = new ExpendoObject();
        defaultState["count"] = 1;
    }
}
