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
            CreateStore();
        }

        private void CreateStore()
        {
            store = new Store(container.defaultState);

            if (container.reducers != null)
                store.AddReducers(container.reducers);
        }

        public void Dispatch(ExpendoObject action)
        {
            store.Dispatch(action);
        }
    }
}