using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //public SFXManager SFXManager;
    //public GameObject item;


    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public int GetEstantes()
    {
        return PlayerPrefs.GetInt("cantidad");
    }

    public void checkEstantes()
    {
        if (GetEstantes() == 6)
        {
            endScene();
        }
    }

    public void endScene()
    {
        SceneManager.LoadScene("EndScene");
    }


    public void UpdateEstantes()
    {
        if (GetEstantes() < 6)
        {
            int stand = GetEstantes() + 1;
            PlayerPrefs.SetInt("cantidad", stand);
        }
    }
    



}
