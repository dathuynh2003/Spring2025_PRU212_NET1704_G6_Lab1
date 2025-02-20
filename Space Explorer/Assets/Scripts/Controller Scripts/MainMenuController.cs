using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject infoPanel;

    private void Start()
    {
        mainPanel.SetActive(true);
        infoPanel.SetActive(false);
    }
    public void PlayGameButton()
    {
        Application.LoadLevel("GamePlay");
    }
    public void QuitGameButton() 
    {
        Application.Quit();
    }
    public void InfoButton()
    {
        mainPanel.SetActive(false );
        infoPanel.SetActive(true);
    }
    public void BackBtton()
    {
        mainPanel.SetActive(true);
        infoPanel.SetActive(false);
    }

}
