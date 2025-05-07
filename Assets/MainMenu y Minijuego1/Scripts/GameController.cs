using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private void Awake(){
        PlayerPrefs.DeleteAll();
    }

    private void Start(){
        PlayerPrefs.DeleteAll();
    }
// -------------------------------------------------------------------------------------
    // Menu Principal
    public void ActiveMenuScene(){
        SceneManager.LoadScene("MenuScene"); 
    }

    public void ActiveMenuPageScene(){
        SceneManager.LoadScene("MenuPageScene"); 
    }

    public void ActiveLoginScene(){
        SceneManager.LoadScene("LoginScene"); 
    }

    public void ActiveSettingScene(){
        SceneManager.LoadScene("SettingScene"); 
    }

    public void ActiveLeaderboardScene(){
        SceneManager.LoadScene("LeaderboardScene"); 
    }

    // Minijuego 1: Diego -> Casher
    public void ActiveInstructionCajaScene()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("InstructionCajaScene"); 
    }

    public void ActiveCasherScene()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("CasherScene"); 
    }

    // Borrar despues del Sprint 1 (Preguntarle a Saldaña)
     public void ActivePapasScene()
    {
        SceneManager.LoadScene("PapasScene"); 
    }

     public void ActiveBookScene()
    {
        SceneManager.LoadScene("BookScene"); 
    }
    public void ActiveCashWinScene(){ 
        SceneManager.LoadScene("EndingScene");
    }

    public void CashWinScene(){
        PlayerPrefs.SetInt("winlose", 1); 
        ActiveCashWinScene();
    }

    public void CashLoseScene(){
        PlayerPrefs.SetInt("winlose", 0); 
        ActiveCashLoseScene();
    }

    public void ActiveCashLoseScene(){
        SceneManager.LoadScene("EndingScene");
    }

// -------------------------------------------------------------------------------------
    // Minijuego 2: Nat -> Ordenar
    public void ActiveGameScene()
    {
        SceneManager.LoadScene("GameScene"); 
    }

    public void ActiveWinScene(){
        SceneManager.LoadScene("EndScene"); 
    }

    public void WinScene(){
        PlayerPrefs.SetInt("winlose", 1); 
        ActiveWinScene();
    }

    public void LoseScene(){
        PlayerPrefs.SetInt("winlose", 0); 
        ActiveLoseScene();
    }

    public void ActiveLoseScene(){
        SceneManager.LoadScene("EndScene"); 
    }

// -------------------------------------------------------------------------------------
    // Borrar esto despues del SPRINT 1 (Preguntarle a Saldaña antes de hacerlo)
    // Minijuego 3: Angel -> Memoria
     public void ActiveInstructionsScene(){
        SceneManager.LoadScene("Instructions"); 
    }
}
