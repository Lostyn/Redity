using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using System.Linq;

namespace React { 
    public class Store {

        private GlobalState _state;
        public GlobalState State
        {
            get { return _state; }
        }
        private List<Reducer> _reducers = new List<Reducer>();

        private List<Action<GlobalState>> _subscribers = new List<Action<GlobalState>>();
        
        public void AddReducer(Reducer r)
        {
            _reducers.Add(r);
        }

        public void Dispatch(ReactAction action)
        {
            GlobalState nextState = State;
            _reducers.ForEach(reducer =>
            {
                reducer.process(ref nextState, action);
            });
            
            SetState(nextState);
        }

        private void SetState(GlobalState nextState)
        {
            _state = nextState;
            _subscribers.ForEach(_subscriber =>
            {
                _subscriber(nextState);
            });
        }

        public void Subscribe(Action<GlobalState> cb)
        {
            if (!_subscribers.Contains(cb))
                _subscribers.Add(cb);
        }

        public void Unsubscribe(Action<GlobalState> cb)
        {
            _subscribers.Remove(cb);
        }
    
    }

}