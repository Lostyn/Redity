using UnityEngine;
using React;

[CreateAssetMenu(menuName = "ReactContainers/KeyboardContainer", fileName= "KeyboardContainer")]
public class KeyboardContainers : Container {

    public override void Init()
    {
        AddReducer(new KeyboardReducer("keyboard"));
    }
}
