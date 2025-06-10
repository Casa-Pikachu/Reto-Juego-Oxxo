using Unity.VisualScripting;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    public GameObject Panel;

    public void Pause()
    {
        Panel.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("Is Paused");
    }

    public void Continue()
    {
        Panel.SetActive(false);
        Time.timeScale = 1;
        Debug.Log("Is Continued");
    }

}
