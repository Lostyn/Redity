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
        List<Task> tasks = new List<Task>();

        string path = Path.Combine(Application.persistentDataPath, "Todos.csv");
        string[] allLines = File.ReadAllLines(path, System.Text.Encoding.UTF8);

        for(int i = 0; i < allLines.Length; i++)
            tasks.Add(new Task(allLines[i]));

        defaultState["Tasks"] = tasks;
        defaultState["FilterMode"] = FilterMode.ALL;
    }


}
