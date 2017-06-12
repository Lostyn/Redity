using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using React;

[CreateAssetMenu(menuName = "ReactContainers/counterContainer", fileName="CounterContainer")]
public class CounterContainers : Container {

    protected override void Init()
    {
        base.Init();
        Debug.Log("init");
        defaultState = new ExpendoObject();
        defaultState["count"] = 1;
    }
}
