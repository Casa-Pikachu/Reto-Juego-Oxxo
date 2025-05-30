using UnityEngine;

public class SFXEstantes : MonoBehaviour
{

    public AudioClip fin;
    public AudioClip drop;

    public void end()
    {
        //Igualmente reproduce el sonido pero de la escena final
        AudioSource.PlayClipAtPoint(fin, Camera.main.transform.position, 0.5f); //Bajamos el volumen 
    }
    
        public void tirar()
    {
        //Igualmente reproduce el sonido pero de la escena final
        AudioSource.PlayClipAtPoint(drop,Camera.main.transform.position, 0.5f); //Bajamos el volumen 
    }

    
}
