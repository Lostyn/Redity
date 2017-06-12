using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace React
{
    public class React : MonoBehaviour
    {
        [SerializeField] Container container;
        public Store store;
        
        private void Awake()
        {
            container.Init();
            CreateStore(container.defaultState);
        }

        private void CreateStore(ExpendoObject defaultState)
        {
            store = new Store(defaultState);
            store.AddReducer(new CounterReducer());
            store.AddReducer(new TodoReducer());
        }

        public void Dispatch(ExpendoObject action)
        {
            store.Dispatch(action);
        }
    }
}