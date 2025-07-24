using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    public void RetourMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}