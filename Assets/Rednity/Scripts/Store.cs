using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using System.Linq;

namespace Rednity
{ 
    public class Store {

        private ExpendoObject _state;
        public ExpendoObject State
        {
            get { return _state; }
        }
        private List<IReducer> _reducers = new List<IReducer>();
        private List<Subscriber> _subscribers = new List<Subscriber>();
        
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

        private void SetState(ExpendoObject prevState)
        {
            _subscribers.ForEach( sub =>
            {
                sub.callback(_state);
            });
        }

        public void AddSubscriber(Subscriber sub)
        {
            if (!_subscribers.Contains(sub))
                _subscribers.Add(sub);
        }

        public void Unsubscribe(Subscriber sub)
        {
            _subscribers.Remove(sub);
        }
    
    }
}