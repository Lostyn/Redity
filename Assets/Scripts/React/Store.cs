using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using System.Linq;

namespace React { 
    public class Store {

        private ExpendoObject _state;
        public ExpendoObject State
        {
            get { return _state; }
        }
        private List<Reducer> _reducers = new List<Reducer>();

        private List<Action<ExpendoObject>> _subscribers = new List<Action<ExpendoObject>>();
        
        public Store(ExpendoObject state) 
        {
            _state = state;
        }

        public void AddReducer(Reducer r)
        {
            _reducers.Add(r);
        }

        public void Dispatch(ExpendoObject action)
        {
            ExpendoObject nextState = State;
            _reducers.ForEach(reducer =>
            {
                reducer.process(ref nextState, action);
            });
            
            SetState(nextState);
        }

        private void SetState(ExpendoObject nextState)
        {
            _state = nextState;
            _subscribers.ForEach(_subscriber =>
            {
                _subscriber(nextState);
            });
        }

        public void Subscribe(Action<ExpendoObject> cb)
        {
            if (!_subscribers.Contains(cb))
                _subscribers.Add(cb);
        }

        public void Unsubscribe(Action<ExpendoObject> cb)
        {
            _subscribers.Remove(cb);
        }
    
    }

}