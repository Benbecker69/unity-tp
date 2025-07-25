using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float tempsDeJeu = 45f;
    public TextMeshProUGUI timerText;
    public GameObject panelGameOver;
    public GameObject panelVictoire;

    private float tempsRestant;
    private int totalCollectibles;
    private int collectiblesRamasses = 0;
    private bool jeuTermine = false;

    void Start()
    {
        Time.timeScale = 1f; 
        tempsRestant = tempsDeJeu;
        totalCollectibles = GameObject.FindGameObjectsWithTag("Collectible").Length;

        
        if (panelGameOver) panelGameOver.SetActive(false);
        if (panelVictoire) panelVictoire.SetActive(false);
    }

    void Update()
    {
        if (!jeuTermine)
        {
            
            tempsRestant -= Time.deltaTime;

            
            if (timerText)
                timerText.text = "Temps: " + Mathf.Ceil(tempsRestant).ToString();

            
            if (tempsRestant <= 0)
            {
                GameOver();
            }
        }
    }

    public void CollecterObjet()
    {
        collectiblesRamasses++;

        
        if (collectiblesRamasses >= totalCollectibles)
        {
            Victoire();
        }
    }

    public void GameOver()
    {
        jeuTermine = true;
        if (panelGameOver) panelGameOver.SetActive(true);
        Time.timeScale = 0f; 
    }

    public void Victoire()
    {
        jeuTermine = true;
        if (panelVictoire) panelVictoire.SetActive(true);
        Time.timeScale = 0f; 
    }

    public void Recommencer()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("Jeu");
    }

    public void RetourMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("Menu");
    }
}