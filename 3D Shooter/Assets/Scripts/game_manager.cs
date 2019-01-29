using UnityEngine;
using UnityEngine.UI;

public class game_manager : MonoBehaviour {

    #region Singleton
    public static game_manager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    [Header("Score")]
    public float score = 0f;
    public Text scoreText;
    public GameObject UI;
    [Space]
    [Header("End Game")]
    public GameObject EndGameMenu;
    public Text scoreTextEnd;

    public void AddScore(float addScore)
    {
        score += addScore;
    }

    public void Update()
    {
        //Draw score to UI
        scoreText.text = "SCORE: " + score.ToString("0");
    }

    public void EndGame()
    {
        scoreTextEnd.text = "SCORE: " + score.ToString("0");
        //Disable 
        UI.active = false;
        //Stop time
        Time.timeScale = 0;
        //Enable end game params
        EndGameMenu.active = true;
        PlayerManager.instace.player.active = false;
        Cursor.lockState = CursorLockMode.None;
    }

}
