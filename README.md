# <img src="https://raw.githubusercontent.com/Lostyn/Rednity/master/Misc/Logo1.png" height="100"> 

Rednity is a Unity vision of javascript Redux architecture.
This implementation is designed without dependency

# Concept

Redux itself is very simple.

Part of your application is stored in an object tree stored inside a single `store`.
The only way to change this state tree is to emit an `action`, an object describing what happened.
Actions are catch by `reducers` which transform the state tree, depending on the action emit.

Your components can `subscribe` to the store, to update itself when the state tree change.

That's it !

# Usage

1. Create your application state 

```csharp
public class Task  {
    private string _label;
    private Guid _id;

    public string Label { get { return _label; } }
    public Guid Id { get { return _id; } }
    public bool done;

    public Task(string label)
    {
        _id = Guid.NewGuid();
        _label = label;
    }
}

public class TodoState
{
    public List<Task> Tasks = new List<Task>();
}
```

2. Define action to change state

```csharp
public class TodoActionTypes
{
    public const string TOGGLE = "TOGGLE";
    public const string ADD = "ADD";
    public const string REMOVE = "REMOVE";
}

public class TodoActionCreators
{
    public static ExpendoObject ToggleItem(Guid todoId)
    {
        ExpendoObject action = new ExpendoObject();
        action["type"] = TodoActionTypes.TOGGLE;
        action["id"] = todoId;

        return action;
    }

    public static ExpendoObject RemoveItem(Guid todoId)
    {
        ExpendoObject action = new ExpendoObject();
        action["type"] = TodoActionTypes.REMOVE;
        action["id"] = todoId;

        return action;
    }

    public static ExpendoObject AddItem(string label)
    {
        ExpendoObject action = new ExpendoObject();
        action["type"] = TodoActionTypes.ADD;
        action["label"] = label;

        return action;
    }
}
```

3. Define Reducer to move state.

```csharp
public class TodoReducer : ReducerBase<TodoState>
{
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
```

4. Define a container

```csharp
[CreateAssetMenu(menuName = "Rednity/TaskContainer", fileName = "TaskContainers")]
public class TodoContainer : Container
{
    public override void Init()
    {
        AddReducer(new TodoReducer("todo"));
    }
}
```

_Note: Still thinking about this concept. Container allow you to split your code and have multiple actions/reducer/state in a single application, and improve your code visibility._

5. Setup your Unity scene
- Create a Container asset in your project with context menu `Rednity/TaskContainer`
- Add Rednity Component to a gameObject in your scene add fill the container variable with the Container asset

6. That's it, you can now connect your compoment to rednity !

```csharp
public class MyComponent : MonoBehaviour
{
	void OnEnable()
	{
		Rednity.Subscribe(OnStateChangeHandler) 	// Call when the state tree change 
			.Init(OnStateChangeHandler)				// Call one time at initialization
	}

	void OnStateChangeHandler(ExpendoObject state)
	{
		List<Task> list = state.Get<TodoState>("todo").Tasks;
	}
}
```

# Example

- [Todo](Assets/Rednity/Samples/Todo)