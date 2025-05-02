using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerMiniGame : MonoBehaviour
{
    public string sceneToLoad;

    void OnMouseDown()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}