using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using React;
using System.Linq;
using System;

public class TodoState
{
    public List<Task> Tasks = new List<Task>();
}

public class TodoReducer : ReducerBase<TodoState> {

    public TodoReducer(string key) : base(key) { }

    public override TodoState Reduce(TodoState state, ExpendoObject action)
    {
        string type = action.Get<string>("type");

        switch (type)
        {
            case TodoActionTypes.TOGGLE:
                Guid id = action.Get<Guid>("id");
                Task t = state.Tasks.First(o => o.Id == id);
                t.done = !t.done;
                break;
            case TodoActionTypes.ADD:
                Task task = new Task(action.Get<string>("label"));
                state.Tasks.Add(task);
                break;
            case TodoActionTypes.REMOVE:
                state.Tasks = state.Tasks.Where(o => o.Id != action.Get<Guid>("id")).ToList<Task>();
                break;
        }

        return state;
    }

}
