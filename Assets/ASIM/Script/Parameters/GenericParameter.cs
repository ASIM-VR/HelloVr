using System;
using UnityEngine;

namespace AsimVr.Parameters
{
    public abstract class GenericParameter<T> : ScriptableObject
    {
        [SerializeField]
        protected T m_value;

        protected Action m_onValueChange;

        private void OnValidate()
        {
#if UNITY_EDITOR
            if(UnityEditor.EditorApplication.isPlaying)
            {
                m_onValueChange?.Invoke();
            }
#endif
        }

        public void AddListener(Action action)
        {
            m_onValueChange += action;
        }

        public void RemoveListener(Action action)
        {
            m_onValueChange -= action;
        }

        public T Value
        {
            get => m_value;
            set
            {
                m_value = value;
                m_onValueChange?.Invoke();
            }
        }
    }
}