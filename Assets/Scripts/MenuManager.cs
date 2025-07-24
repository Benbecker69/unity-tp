using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Jouer()
    {
        SceneManager.LoadScene("Jeu");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Quitter()
    {
        Application.Quit();


#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}