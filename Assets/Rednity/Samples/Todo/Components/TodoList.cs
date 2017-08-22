using System.Collections.Generic;
using UnityEngine;

namespace Rednity.TodoSample
{
    public class TodoList : MonoBehaviour
    {

        [SerializeField] GameObject m_itemPrefab;
        [SerializeField] Transform m_grid;

        private void OnEnable()
        {
            Rednity.Subscribe(OnStateChange).Init(OnStateChange);
        }

        private void ProcessTask(Task t)
        {
            Transform child = m_grid.Find(t.Id.ToString());
            if (child == null)
            {
                child = Instantiate(m_itemPrefab, m_grid, false).transform;
                child.name = t.Id.ToString();
            }

            child.GetComponentInChildren<TodoItem>().Task = t;
        }

        public void OnStateChange(ExpendoObject state)
        {
            List<Task> list = state.Get<TodoState>("todo").Tasks;
            foreach (Transform c in m_grid)
            {
                if (list.FindIndex(o => o.Id.ToString() == c.name) == -1)
                    Destroy(c.gameObject);
            }

            list.ForEach(ProcessTask);
        }
    }
}