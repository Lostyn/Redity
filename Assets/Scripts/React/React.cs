using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace React
{
    public class React : MonoBehaviour
    {
        public Store store;

        private void Awake()
        {
            CreateStore();
        }

        private void CreateStore()
        {
            store = new Store();
            store.AddReducer(new CounterReducer());
        }

        public void Dispatch(ReactAction action)
        {
            store.Dispatch(action);
        }
    }
}