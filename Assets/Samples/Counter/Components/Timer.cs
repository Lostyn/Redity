using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using React;

public class Timer : RComposant<Timer.defaultState> {

    [SerializeField] Text m_text;

    public struct defaultState {
        public int value;
    }

    void Start()
    {
        defaultState s = state;
            s.value = 0;
        SetState(s);

        StartCoroutine(Increment());
    }

    IEnumerator Increment()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            defaultState s = state;
                s.value++;
            SetState(s);
        }
    }

    public override void Render()
    {
        m_text.text = state.value.ToString();
    }
}
