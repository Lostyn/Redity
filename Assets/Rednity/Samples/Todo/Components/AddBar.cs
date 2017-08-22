using UnityEngine;
using UnityEngine.UI;

namespace Rednity.TodoSample
{
    public class AddBar : MonoBehaviour
    {

        [SerializeField] InputField m_input;
        [SerializeField] Button m_add;

        private void OnEnable()
        {
            m_add.onClick.AddListener(OnAddHandler);
        }

        void OnAddHandler()
        {
            string value = m_input.text;
            if (!string.IsNullOrEmpty(value))
            {
                Rednity.Dispatch(TodoActionCreators.AddItem(value));

                m_input.text = "";
            }
        }
    }
}