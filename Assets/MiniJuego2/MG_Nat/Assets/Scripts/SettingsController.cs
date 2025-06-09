using UnityEngine;

public class SettingsController : MonoBehaviour
{

    public GameObject PausaPanel;
    public GameObject SettingPanel; 

    public void settingOn()
    {
        PausaPanel.SetActive(false);
        SettingPanel.SetActive(true);
    }

    public void settingOff()
    {
        PausaPanel.SetActive(true);
        SettingPanel.SetActive(false);
    }
}
