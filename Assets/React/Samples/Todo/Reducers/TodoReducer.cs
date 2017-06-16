using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using React;
using System.Linq;
using System;

public class TodoReducer : Reducer
{

    public override void process(ref ExpendoObject state, ExpendoObject action)
    {
        string type = action.Get<string>("type");

        switch (type)
        {
            case TodoActionTypes.TOGGLE:
                Guid id = action.Get<Guid>("id");
                Task t = state.Get<List<Task>>("Tasks").First(o => o.Id == id);
                t.done = !t.done;
                break;
            case TodoActionTypes.ADD:
                Task task = new Task(action.Get<string>("label"));
                state.Get<List<Task>>("Tasks").Add(task);
                break;
            case TodoActionTypes.REMOVE:
                state["Tasks"] = state.Get<List<Task>>("Tasks").Where(o => o.Id != action.Get<Guid>("id")).ToList<Task>();
                break;
        }
    }
}
