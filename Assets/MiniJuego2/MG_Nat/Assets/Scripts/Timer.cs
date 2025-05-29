using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [Header("Timer UI references : ")]
    [SerializeField] private Image uiFillImage;
    //[SerializeField] private Text uiText;

    // [SerializeField] private GameController gameController;

    public int Duration { get; private set; }

    public int remainingDuration;

    private void Awake(){
        RestTimer();
    }

    private void RestTimer()
    {
        //uiText.text = "00:00";
        uiFillImage.fillAmount = 0f;
        Duration = remainingDuration = 0;
    }

    public Timer SetDuration(int seconds){
        Duration = remainingDuration = seconds;
        return this;
    }

    public void Begin()
    {
        // StopAllCoroutines();
        StartCoroutine(UpdateTimer());
        PlayerPrefs.SetInt("Time", Duration);
    }

    private IEnumerator UpdateTimer (){
        while (remainingDuration > 0){
            UpdateUI(remainingDuration);
            remainingDuration--;
            PlayerPrefs.SetInt("Time", remainingDuration);
            yield return new WaitForSeconds(1f);
        }

        End();
    }

    private void UpdateUI (int seconds){
        //uiText.text = string.Format ("{0}:{1}", seconds / 60 , seconds % 60); 
        uiFillImage.fillAmount = Mathf.InverseLerp (0, Duration, seconds);
    }

    public void End()
    {
        RestTimer();
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
