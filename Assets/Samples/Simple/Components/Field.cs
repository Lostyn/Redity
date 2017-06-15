using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using React;

public class Field : RComposant<Field.defaultState>, IPointerClickHandler
{
    [SerializeField] Text m_text;
    public struct defaultState { }

    public override bool ShouldComponentUpdate(ExpendoObject nextProps, object nextState)
    {
        return false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Dispatch(KeyboardActionCreator.SetTarget(m_text));
    }
}
