using UnityEngine;

public class SFXEstantes : MonoBehaviour
{

    public AudioClip estante;
    public AudioClip drop;
    public AudioClip borrar;

    public void bien()
    {
        AudioSource.PlayClipAtPoint(estante, Camera.main.transform.position, 0.5f); //Bajamos el volumen 
    }

    public void tirar()
    {
        AudioSource.PlayClipAtPoint(drop, Camera.main.transform.position, 0.5f); //Bajamos el volumen 
    }
    

    public void mal()
    {
        AudioSource.PlayClipAtPoint(borrar,Camera.main.transform.position, 0.5f); //Bajamos el volumen 
    }

    
}
