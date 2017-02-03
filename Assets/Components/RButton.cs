using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        State o = props;
        o.count = isMoins ? o.count - 1 : o.count + 1;
        Dispatch(o);
    }

    public override void Render()
    {
        m_button.enabled = isMoins ? props.count > 0 : props.count < 10;
    }

    public struct defaultState { }
}
