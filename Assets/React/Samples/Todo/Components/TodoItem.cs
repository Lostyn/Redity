using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using React;

public class TodoItem : RComposant {

    [SerializeField] Text m_text;
    [SerializeField] Image m_image;
    [SerializeField] Button m_btn;
    [SerializeField] Button m_remove;

    Task _task;
    public Task Task
    {
        set
        {
            _task = value;
            Render();
        }
    }

    protected override void ComponentDidMount()
    {
        base.ComponentDidMount();

        m_btn.onClick.AddListener(ToggleTask);
        m_remove.onClick.AddListener(RemoveHandler);
    }

    void ToggleTask()
    {
        Dispatch(TodoActionCreators.ToggleItem(_task.Id));
    }

    void RemoveHandler()
    {
        Dispatch(TodoActionCreators.RemoveItem(_task.Id));
    }

    public override void Render()
    {
        m_text.text = _task.Label;
        m_image.color = _task.done ? Color.green : Color.white;
    }
}
