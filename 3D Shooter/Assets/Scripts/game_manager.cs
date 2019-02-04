using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
    private float _topScore;
    [Space]
    [Header("Pause")]
    public GameObject pauseUI;
    public GameObject FPCCam;
    [Space]
    [Header("End Game")]
    public GameObject EndGameMenu;
    public Text scoreTextEnd;
    public Camera endCam;

    public void AddScore(float addScore)
    {
        score += addScore;
    }

    public void Start()
    {
        _topScore = passTopScore.instace.tScore;
        passTopScore.instace.SelfDestruct();

        Unpause();
    }

    public void Update()
    {
        //Draw score to UI
        scoreText.text = "SCORE: " + score.ToString("0");
        PauseGame();
    }

    public void PauseGame()
    {
        //Pause game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                Unpause();
            }
            else if (Time.timeScale == 1)
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        PlayerManager.instace.player.SetActive(false);

        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseUI.SetActive(true);
    }

    public void Unpause()
    {
        PlayerManager.instace.player.SetActive(true);

        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseUI.SetActive(false);
    }

    public void EndGame()
    {
        scoreTextEnd.text = "SCORE: " + score.ToString("0");
        //Disable UI

        UI.active = false;
        Instantiate(endCam, new Vector3(0,2,0), Quaternion.LookRotation(transform.forward));
        PlayerManager.instace.player.active = false;

        //Stop time

        Time.timeScale = 0;

        //Enable end game params

        EndGameMenu.active = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SaveData(score);
    }

    public void SaveData(float _score)
    {
        if (score > _topScore)
        { 
        BinaryFormatter formatter = new BinaryFormatter();

        string savePath = Application.persistentDataPath + "/top_score.data";
        FileStream fileStream = new FileStream(savePath, FileMode.Create);

        formatter.Serialize(fileStream, _score);
        fileStream.Close();
        }
    }

}
