using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using React;

public class AddBar : RComposant {

    [SerializeField] InputField m_input;
    [SerializeField] Button m_add;

    public override bool ShouldComponentUpdate(ExpendoObject nextProps)
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
            Dispatch(TodoActionCreators.AddItem(value));

            m_input.text = "";
        }
    }
}
