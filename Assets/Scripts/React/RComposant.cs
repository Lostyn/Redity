using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace React
{
    public class RComposant<T> : MonoBehaviour where T : struct
    {

        private React _container;

        private T m_state;
        public T state
        {
            get { return m_state; }
            set
            {
                if (_mounted)
                {
                    Debug.LogError("state is read only after component was mount. Use setState function !");
                    return;
                }

                m_state = value;
            }
        }

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
            if (ShouldComponentUpdate(nextProps, state))
            {
                ComponentWillUpdate(nextProps, state);

                ExpendoObject lastProps = m_props;
                m_props = nextProps;
                Render();
                ComponentDidUpdate(lastProps, state);
            }
        }

        public void setState(T nextState)
        {
            if (ShouldComponentUpdate(props, nextState))
            {
                ComponentWillUpdate(props, nextState);

                T lastState = m_state;
                m_state = nextState;
                Render();
                ComponentDidUpdate(props, lastState);
            }
        }

        /* Initialization */
        protected virtual void ComponentWillMount() { _mounted = false; }
        protected virtual void ComponentDidMount() { _mounted = true; }
        protected virtual bool ShouldComponentSubscribe() { return false; }

        public virtual void Render() { }

        /*State Changes*/
        public virtual bool ShouldComponentUpdate(object nextProps, object nextState) { return true; }
        protected virtual void ComponentWillUpdate(object nextProps, object nextState) { }
        protected virtual void ComponentDidUpdate(object lastProps, object lastState) { }

        /*Props Changes*/
        protected virtual void ComponentWillRecieveProps(object nextProps) { }

        /*Unmounting*/
        protected virtual void ComponentWillUnmount() { }
    }
}
