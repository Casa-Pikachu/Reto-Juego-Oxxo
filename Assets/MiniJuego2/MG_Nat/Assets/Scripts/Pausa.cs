using Unity.VisualScripting;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    public GameObject Panel;

    void Start()
    {
       Time.timeScale = 1;
    }
    public void Pause()
    {
        Panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        Panel.SetActive(false);
        Time.timeScale = 1;
    }

}
