using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFunction : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject OptionsMenu;
    [SerializeField] private GameObject PlayMenu;

    void Start()
    {
        OptionsMenu.SetActive(false);
        PlayMenu.SetActive(false);
    }
    
    public void OnPlay()
    {
        MainMenu.SetActive(false);
        PlayMenu.SetActive(true);
    }

    public void OnSettings()
    {
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void OnQuit()
    {
        Application.Quit();    
    }

    public void OnBack()
    {
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(false);
        PlayMenu.SetActive(false);
    }

    public void LevelOne()
    {
        SceneManager.LoadScene(1);
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene(2);
    }

    public void LevelThree()
    {
        SceneManager.LoadScene(3);
    }
}
