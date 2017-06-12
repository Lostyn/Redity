using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using React;

public class AddBar : RComposant<AddBar.defaultState> {

    public struct defaultState { }

    [SerializeField] InputField m_input;
    [SerializeField] Button m_add;

    public override bool ShouldComponentUpdate(object nextProps, object nextState)
    {
        return false;
    }

    protected override void ComponentDidMount()
    {
        m_add.onClick.AddListener(OnAddHandler);
    }

    void OnAddHandler()
    {
        string value = m_input.text;
        if (!string.IsNullOrEmpty(value))
        {
            ExpendoObject action = new ExpendoObject();
            action["type"] = ActionTypes.ADD;
            action["label"] = value;
            Dispatch(action);

            m_input.text = "";
        }
    }
}
