using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using React;

public class RButton : RComposant<RButton.defaultState> {

    [SerializeField] Button m_button;
    [SerializeField] bool isMoins;

    protected override void ComponentDidMount()
    {
        base.ComponentDidMount();
        m_button.onClick.AddListener(HandlerClic);
    }

    protected override void ComponentWillUnmount()
    {
        base.ComponentWillUnmount();
        m_button.onClick.RemoveListener(HandlerClic);
    }

    void HandlerClic()
    {
        ReactAction action = new ReactAction();
        action.Add("type", isMoins ? "DECREMENT" : "INCREMENT");
        action.Add("value", 2);

        Dispatch(action);
    }

    public override void Render()
    {
        m_button.enabled = isMoins ? props.count > 0 : props.count < 10;
    }

    public struct defaultState { }
}
