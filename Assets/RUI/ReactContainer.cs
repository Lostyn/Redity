using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;


public class ReactContainer : MonoBehaviour {

    [SerializeField] State m_state;

    List<Action<State>> m_composant = new List<Action<State>>();

	public void RegisterComponent(Action<State> cb)
    {
        m_composant.Add(cb);
        cb(m_state);
    }

    public void UnregisterComponent(Action<State> cb)
    {
        m_composant.Remove(cb);
    }

    public void setState(State state)
    {
        m_state = state;
        int i = 0;
        for (i = 0; i < m_composant.Count; i++)
        {
            Action<State> action = m_composant[i];
            action(m_state);
        }
    }
}

[Serializable]
public struct State
{
    public int count;
}
