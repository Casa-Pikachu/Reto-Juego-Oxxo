using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] float remainingTime;
   
    // Update is called once per frame
    public GameManager Manager;

    void Update()
    {

        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }

        else if (PlayerPrefs.GetInt("cantidad") < 6 || remainingTime <= 0)
        {
            PlayerPrefs.SetInt("Tiempo", 0);
            Debug.Log(PlayerPrefs.GetInt("Tiempo"));
            remainingTime = 0;
            Manager.endScene();
        }
    }

    

    
}
