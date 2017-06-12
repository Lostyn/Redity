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

    protected override bool ShouldComponentSubscribe()
    {
        return true;
    }

    void HandlerClic()
    {
        ExpendoObject action = new ExpendoObject();
        action["type"] = isMoins ? "DECREMENT" : "INCREMENT";
        action["value"] = 2;

        Dispatch(action);
    }

    public override void Render()
    {
        int value = props.Get<int>("count");
        m_button.enabled = isMoins ? value > 0 : value < 10;
    }

    public struct defaultState { }
}
