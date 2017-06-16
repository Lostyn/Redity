using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using React;

public class Field : RComposant, IPointerClickHandler
{
    [SerializeField] Text m_text;

    public override bool ShouldComponentUpdate(ExpendoObject nextProps)
    {
        return false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Dispatch(KeyboardActionCreator.SetTarget(m_text));
    }
}
