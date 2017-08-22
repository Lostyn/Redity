using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Rednity
{
    public class Rednity : MonoBehaviour
    {
        static Rednity _instance;
        public static Rednity Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<Rednity>();

                return _instance;
            }
        }

        [SerializeField] Container container;
        public Store store;
        public static Store Store { get { return Instance.store; } }
        
        private void Awake()
        {
            if (container != null)
            {
                container.Init();
                CreateStore();
            }
            else
                Debug.LogError("Not container found for initialization");
        }

        private void CreateStore()
        {
            store = new Store(container.defaultState);

            if (container.reducers != null)
                store.AddReducers(container.reducers);
        }

        public static Subscriber Subscribe(Action<ExpendoObject> cb)
        {
            return Instance.CreateSubcriberAndAdd(cb);
        }

        public static void Unsubcribe(Subscriber sub)
        {
            Store.Unsubscribe(sub);
        }

        public Subscriber CreateSubcriberAndAdd(Action<ExpendoObject> cb)
        {
            Subscriber sub = new Subscriber(cb);
            StartCoroutine(AddSubcriberWhenStoreInit(sub));
            
            return sub;
        }

        IEnumerator AddSubcriberWhenStoreInit(Subscriber sub)
        {
            while (store == null)
                yield return new WaitForEndOfFrame();

            store.AddSubscriber(sub);
            sub.SetStore(store);
        }

        public static void Dispatch(ExpendoObject action)
        {
            Instance.store.Dispatch(action);
        }
    }
}