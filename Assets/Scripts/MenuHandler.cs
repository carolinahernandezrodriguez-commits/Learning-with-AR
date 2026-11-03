using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public void GoHome()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void GoMainScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
