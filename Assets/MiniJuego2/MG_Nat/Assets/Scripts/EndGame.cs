using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
   //public SFXManager sound;
   //public Text winText;

    [SerializeField] float remainingTime;
    // Update is called once per frame
    public GameManager Manager;
    public Text puntos;
    public Text fin;
    public Text monedas; 
    void Update()
    {
        //sound.end();

        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;

            //futura condicion para resetear timer si se logran 3 en una checar script the timer para que se resetee
        }
        
        else if (PlayerPrefs.GetInt("cantidad") < 6 || remainingTime <= 0)
        {
            PlayerPrefs.SetInt("Tiempo", 0);
            Debug.Log(PlayerPrefs.GetInt("Tiempo"));
            remainingTime = 0;
            Manager.endScene();
            //Gamecontroller.Instance.LoseGame(); ? check this 
        }
    }

    

    
}
