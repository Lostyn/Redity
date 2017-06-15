using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using React;

public class Keyboard : RComposant<Keyboard.defaultState>
{
    public struct defaultState { }

    [SerializeField] CanvasGroup m_group;

    bool isOpen = true;
    string _value;

    protected override bool ShouldComponentSubscribe()
    {
        return true;
    }

    public override bool ShouldComponentUpdate(ExpendoObject nextProps, object nextState)
    {
        KeyboardState state = props.Get<KeyboardState>("keyboard");
        if ((state.target != null) != isOpen)
            return true;

        if (state.value != _value)
            return true;

        return false;
    }

    void Open()
    {
        isOpen = true;
        m_group.alpha = 1;
        m_group.interactable = true;
        m_group.blocksRaycasts = true;
    }

    void Close()
    {
        isOpen = false;
        m_group.alpha = 0;
        m_group.interactable = false;
        m_group.blocksRaycasts = false;
    }

    public override void Render()
    {
        Text target = props.Get<KeyboardState>("keyboard").target;
        string value = props.Get<KeyboardState>("keyboard").value;

        if (target == null && isOpen) Close();
        else if (target != null && !isOpen) Open();

        if (target != null)
        {
            target.text = value;
        }
    }
}
