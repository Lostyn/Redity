using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace React
{
    public class RComposant : MonoBehaviour
    {

        private React _container;

        
        private ExpendoObject m_props;
        public ExpendoObject props
        {
            get { return m_props; }
        }

        bool _mounted = false;

        void Awake()
        {
            _container = FindObjectOfType<React>();

            if (_container == null)
                Debug.LogError("No container found");
        }

        IEnumerator Start()
        {
            ComponentWillMount();
            yield return new WaitForEndOfFrame();
            if (ShouldComponentSubscribe())
                _container.store.Subscribe(UpdateProps);

            m_props = _container.store.State;

            Render();
            ComponentDidMount();
        }

        void OnDisable()
        {
            ComponentWillUnmount();
            _container.store.Unsubscribe(UpdateProps);

            _container = null;
            _mounted = false;
        }

        protected void Dispatch(ExpendoObject action)
        {
            _container.Dispatch(action);
        }

        public void UpdateProps(ExpendoObject nextProps)
        {
            ComponentWillRecieveProps(nextProps);
            if (ShouldComponentUpdate(nextProps))
            {
                ComponentWillUpdate(nextProps);

                ExpendoObject lastProps = m_props;
                m_props = nextProps;
                Render();
                ComponentDidUpdate(lastProps);
            }
        }

        /* Initialization */
        protected virtual void ComponentWillMount() { _mounted = false; }
        protected virtual void ComponentDidMount() { _mounted = true; }
        protected virtual bool ShouldComponentSubscribe() { return false; }

        public virtual void Render() { }

        /*State Changes*/
        public virtual bool ShouldComponentUpdate(ExpendoObject nextProps) { return true; }
        protected virtual void ComponentWillUpdate(ExpendoObject nextProps) { }
        protected virtual void ComponentDidUpdate(ExpendoObject lastProps) { }

        /*Props Changes*/
        protected virtual void ComponentWillRecieveProps(object nextProps) { }

        /*Unmounting*/
        protected virtual void ComponentWillUnmount() { }
    }
}
