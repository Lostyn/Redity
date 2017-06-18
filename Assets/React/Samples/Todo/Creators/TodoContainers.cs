using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using React;

[CreateAssetMenu(menuName = "ReactContainers/TaskContainers", fileName = "TaskContainers")]
public class TodoContainers : Container {

    public override void Init()
    {
        AddReducer(new TodoReducer("todo"));
    }
}
