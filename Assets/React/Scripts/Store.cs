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
        private List<IReducer> _reducers = new List<IReducer>();

        private List<Action<ExpendoObject>> _subscribers = new List<Action<ExpendoObject>>();
        
        public Store(ExpendoObject state) 
        {
            _state = state;
        }

        public void AddReducer(IReducer r)
        {
            _reducers.Add(r);
        }

        public void AddReducers(List<IReducer> rs)
        {
            _reducers.InsertRange(_reducers.Count, rs);
        }

        public void Dispatch(ExpendoObject action)
        {
            _reducers.ForEach(reducer =>
            {

                string key = reducer.GetKey();
                _state[key] = reducer.ReduceAny(_state[key], action);
            });
            
            SetState(_state);
        }

        private void SetState(ExpendoObject nextState)
        {
            _state = nextState;
            _subscribers.ForEach(_subscriber =>
            {
                _subscriber(_state);
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