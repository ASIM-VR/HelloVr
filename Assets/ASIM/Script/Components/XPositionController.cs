using AsimVr.Parameters;
using UnityEngine;

namespace AsimVr.Components
{
    public class XPositionController : MonoBehaviour
    {
        [SerializeField]
        private FloatParameter m_parameter;

        private void Awake()
        {
            OnValueChanged();
            m_parameter.AddListener(OnValueChanged);
        }

        private void OnDestroy()
        {
            m_parameter.RemoveListener(OnValueChanged);
        }

        private void OnValueChanged()
        {
            transform.position = new Vector3(m_parameter.Value, transform.position.y, transform.position.z);
        }
    }
}