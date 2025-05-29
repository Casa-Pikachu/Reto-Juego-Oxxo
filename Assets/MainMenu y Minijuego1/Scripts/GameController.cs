using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private void Awake(){
    }

    private void Start(){
    }

    // Método para guardar la escena previa y cargar una nueva escena
    public void LoadSceneWithPrevious(int sceneIndex)
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("previousScene" + sceneIndex, currentScene); // Guarda la escena actual como "previa"
        SceneManager.LoadScene(sceneIndex); // Carga la nueva escena
    }

    // Método para cargar la escena previa
    public void LoadPreviousScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int previousScene = PlayerPrefs.GetInt("previousScene" + currentScene, currentScene); // Recupera la escena previa
        SceneManager.LoadScene(previousScene); // Carga la escena previa
    }

    // Menu Principal
    public void ActiveLoginScene(){
        LoadSceneWithPrevious(0); // Índice de LoginScene
    }

    public void ActiveMenuPageScene(){
        LoadSceneWithPrevious(1); // Índice de MenuPageScene
    }

    public void ActiveSettingScene(){
        LoadSceneWithPrevious(2); // Índice de SettingScene
    }

    public void ActiveLeaderboardScene(){
        LoadSceneWithPrevious(3); // Índice de LeaderboardScene
    }

    public void ActiveMenuScene(){
        LoadSceneWithPrevious(4); // Índice de MenuScene
    }

    public void ActivePauseScene(){
        LoadSceneWithPrevious(10); // Índice de PauseScene
    }

    public void ActiveComputerScene()
    {
        LoadSceneWithPrevious(11);  // Índice de ComputerScene
    }

    public void ActiveShopScene()
    {
        LoadSceneWithPrevious(12);  // Índice de ShopScene
    }

    // Minijuego 1: Diego -> Casher
    public void ActiveInstructionCajaScene()
    {
        PlayerPrefs.DeleteAll();
        LoadSceneWithPrevious(5); // Índice de InstructionCajaScene
    }

    public void ActiveCasherScene()
    {
        LoadSceneWithPrevious(6);  // Índice de CasherScene
    }

    // Borrar despues del Sprint 1 (Preguntarle a Saldaña)
    public void ActivePapasScene()
    {
        LoadSceneWithPrevious(7);  // Índice de PapasScene
    }

    public void ActiveBookScene()
    {
        LoadSceneWithPrevious(8);  // Índice de BookScene
    }

    public void ActiveCashWinScene(){ 
        //LoadSceneWithPrevious(9); // Índice de EndingScene
        PlayerPrefs.SetInt("winlose", 1); 
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
        //LoadSceneWithPrevious(9); // Índice de EndingScene
        PlayerPrefs.SetInt("winlose", 0); 
        SceneManager.LoadScene("EndingScene");
    }

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

    // Borrar esto despues del SPRINT 1 (Preguntarle a Saldaña antes de hacerlo)
    // Minijuego 3: Angel -> Memoria
    public void ActiveInstructionsScene(){
        SceneManager.LoadScene("Instructions"); 
    }
}
