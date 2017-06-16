using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using React;
using System.IO;
using System.Linq;

[CreateAssetMenu(menuName = "ReactContainers/TaskContainers", fileName= "TaskContainers")]
public class TodoContainers : Container {

    public override void Init()
    {
        base.Init();

        defaultState = new ExpendoObject();

        defaultState["Tasks"] = new List<Task>();
        defaultState["FilterMode"] = FilterMode.ALL;

        reducers = new List<Reducer>();
        reducers.Add(new TodoReducer());
    }


}
