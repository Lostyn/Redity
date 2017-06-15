using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using React;

public class KeyboardTouch : RComposant<KeyboardTouch.defaultState>, 
                                IPointerClickHandler, 
                                IPointerEnterHandler, 
                                IPointerExitHandler
{
    enum KeyType
    {
        LETTER,
        MAJ,
        DELETE,
        ENTER
    }
    [SerializeField] KeyType m_keyType;

    public struct defaultState { }

    [SerializeField] Text m_label;
    [SerializeField] Graphic m_img;
    [SerializeField] Color m_over;
    [SerializeField] Color m_normal;

    public string letter;
    string Letter
    {
        get { return _isMaj ? letter.ToUpper(): letter.ToLower(); }
    }
    bool _isMaj;

    protected override bool ShouldComponentSubscribe()
    {
        return m_keyType == KeyType.LETTER;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        m_img.color = m_over;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_img.color = m_normal;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (m_keyType)
        {
            case KeyType.MAJ:
                Dispatch(KeyboardActionCreator.ToggleMaj());
                break;
            case KeyType.LETTER:
                Dispatch(KeyboardActionCreator.AddChar(Letter));
                break;
            case KeyType.DELETE:
                Dispatch(KeyboardActionCreator.RemoveChar());
                break;
            case KeyType.ENTER:
                Dispatch(KeyboardActionCreator.Valid());
                break;
        }
    }

    public override bool ShouldComponentUpdate(ExpendoObject nextProps, object nextState)
    {
        bool value = props.Get<KeyboardState>("keyboard").isMaj != _isMaj;
        _isMaj = props.Get<KeyboardState>("keyboard").isMaj;

        return value;
    }

    public override void Render()
    {
        m_label.text = m_keyType == KeyType.LETTER ? Letter : letter;
    }
}
