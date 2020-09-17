using AsimVr.Parameters;
using UnityEngine;
using UnityEngine.UI;

namespace AsimVr.GUI
{
    [RequireComponent(typeof(Slider))]
    public class FloatSlider : MonoBehaviour
    {
        [SerializeField]
        private FloatParameter m_parameter;

        private Slider m_slider;

        private void Awake()
        {
            m_slider = GetComponent<Slider>();
            m_slider.value = m_parameter.Value;
            m_slider.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnEnable()
        {
            m_slider.value = m_parameter.Value;
        }

        private void OnValueChanged(float value)
        {
            m_parameter.Value = value;
        }
    }
}