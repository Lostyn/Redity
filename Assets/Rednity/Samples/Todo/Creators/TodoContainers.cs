using UnityEngine;

namespace Rednity.TodoSample
{
    [CreateAssetMenu(menuName = "ReactContainers/TaskContainers", fileName = "TaskContainers")]
    public class TodoContainers : Container
    {

        public override void Init()
        {
            AddReducer(new TodoReducer("todo"));
        }
    }
}