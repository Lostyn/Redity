using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Rednity
{
    public class Subscriber {

        public Action<ExpendoObject> callback;
        public Action<ExpendoObject> onInit;
        public Func<ExpendoObject, ExpendoObject, bool> condition;
        Store m_store;

        public Subscriber(Action<ExpendoObject> _callback)
        {
            callback = _callback;
            condition = (o, b) => true;
        }

        public Subscriber If(Func<ExpendoObject, ExpendoObject, bool> _condition)
        {
            condition = _condition;
            return this;
        }

        public Subscriber Init(Action<ExpendoObject> init)
        {
            if (m_store != null)
                init(m_store.State);
            else
                onInit = init;

            return this;
        }

        public void SetStore(Store store)
        {
            m_store = store;

            if (onInit != null)
            {
                onInit(m_store.State);
                onInit = null;
            }
        }
    }
}
