using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Label : RComposant<Label.defaultState> {

    [SerializeField] Text m_text;

    public override void Render() {
        m_text.text = props.count.ToString();
    }

    public struct defaultState { }
}
