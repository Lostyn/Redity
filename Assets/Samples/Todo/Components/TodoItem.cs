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

    protected override void ComponentDidMount()
    {
        base.ComponentDidMount();

        m_btn.onClick.AddListener(ToggleTask);
    }

    void ToggleTask()
    {
        ExpendoObject action = new ExpendoObject();
        action["type"] = "TOGGLE";
        action["id"] = state.task.Id;

        Dispatch(action);
    }

    public override void Render()
    {
        m_text.text = state.task.Label;
        m_image.color = state.task.done ? Color.green : Color.white;
    }
}
