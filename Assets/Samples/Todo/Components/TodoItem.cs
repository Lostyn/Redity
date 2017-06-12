using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using React;

public class TodoItem : RComposant<TodoItem.defaultState> {
    public struct defaultState {
        public Task task;
    }

    [SerializeField] Text m_text;
    [SerializeField] Image m_image;
    [SerializeField] Button m_btn;
    [SerializeField] Button m_remove;

    protected override void ComponentDidMount()
    {
        base.ComponentDidMount();

        m_btn.onClick.AddListener(ToggleTask);
        m_remove.onClick.AddListener(RemoveHandler);
    }

    void ToggleTask()
    {
        ExpendoObject action = new ExpendoObject();
        action["type"] = ActionTypes.TOGGLE;
        action["id"] = state.task.Id;

        Dispatch(action);
    }

    void RemoveHandler()
    {
        ExpendoObject action = new ExpendoObject();
        action["type"] = ActionTypes.REMOVE;
        action["id"] = state.task.Id;

        Dispatch(action);
    }

    public override void Render()
    {
        m_text.text = state.task.Label;
        m_image.color = state.task.done ? Color.green : Color.white;
    }
}
