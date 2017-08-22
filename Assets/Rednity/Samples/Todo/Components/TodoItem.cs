using UnityEngine;
using UnityEngine.UI;

namespace Rednity.TodoSample
{
    public class TodoItem : MonoBehaviour
    {

        [SerializeField] Text m_text;
        [SerializeField] Image m_image;
        [SerializeField] Button m_btn;
        [SerializeField] Button m_remove;

        Task _task;
        public Task Task
        {
            set
            {
                _task = value;
                SetInfos();
            }
        }

        private void OnEnable()
        {
            m_btn.onClick.AddListener(ToggleTask);
            m_remove.onClick.AddListener(RemoveHandler);
        }

        void ToggleTask()
        {
            Rednity.Dispatch(TodoActionCreators.ToggleItem(_task.Id));
        }

        void RemoveHandler()
        {
            Rednity.Dispatch(TodoActionCreators.RemoveItem(_task.Id));
        }

        public void SetInfos()
        {
            m_text.text = _task.Label;
            m_image.color = _task.done ? Color.green : Color.white;
        }
    }
}