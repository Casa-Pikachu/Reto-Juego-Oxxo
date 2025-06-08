using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Unity.VisualScripting;

public class CheckEquall : MonoBehaviour, IDropHandler
{
  [SerializeField] private Transform estante;
  public GameObject obj1;
  public GameObject obj2;
  public GameObject obj3;
  public GameManager Manager;
  public UIController UIController;
  public SFXEstantes audio; 

  bool sameTag = false;
  bool sameTag1 = false;
  bool sameTag2 = false;

  public void Start()
  {
    PlayerPrefs.SetInt("cantidad", 0);
    PlayerPrefs.SetInt("puntaje", 0); 
  }

  public void OnDrop(PointerEventData eventData)
  {
    GameObject item = eventData.pointerDrag;

    if (item.tag == obj1.tag)
    {
      sameTag = true;
      Debug.Log("It is");
    }


    if (item.tag == obj2.tag)
    { 
      sameTag1 = true;
      Debug.Log("It is 2");
    }

    if (item.tag == obj3.tag)
    {
      sameTag2 = true;
      Debug.Log("It is 3");

    }

    Debug.Log($"{sameTag}, {sameTag1}, {sameTag2}");


    StartCoroutine(Delay());
  }

  IEnumerator Delay()
  {
     yield return null;

    if (estante.childCount == 3)
    {
      if (sameTag && sameTag1 && sameTag2)
      {
        GameManager.Instance.SFX.bien();

        Image img = estante.GetChild(0).GetComponent<Image>();
        img.raycastTarget = false;

        Image img2 = estante.GetChild(1).GetComponent<Image>();
        img2.raycastTarget = false;

        Image img3 = estante.GetChild(2).GetComponent<Image>();
        img3.raycastTarget = false;

        Manager.UpdateEstantes();
        Manager.checkEstantes();
        UIController.AddPoints(30);
       GameManager.Instance.SFX.bien(); 

      }
      else
      {
        GameManager.Instance.SFX.mal();
        UIController.SubPoints(5);
        for (int i = estante.childCount - 1; i >= 0; i--)
        {
          Destroy(estante.GetChild(i).gameObject);
        }

        if (sameTag)
        {
          sameTag = false;
        }
        if (sameTag1)
        {
          sameTag1 = false;
        }
        if (sameTag2)
        {
          sameTag2 = false;
        }
      }

    }

  }
  
}



