using Unity.VisualScripting;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject startScene;
    public GameObject spielScene;
    public void MouseClick()
    {
        startScene.SetActive(false);
        spielScene.SetActive(true);
    }
}
