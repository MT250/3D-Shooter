using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main_Menu : MonoBehaviour {

    public Text topScore;

    public void Start()
    {
        LoadScore();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Scenes/Arena");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadScore()
    {
        string dataPath = Application.persistentDataPath + "/top_score.data";
        if (File.Exists(dataPath))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fStream = new FileStream(dataPath, FileMode.Open);

            var loadScore = binaryFormatter.Deserialize(fStream);
            
            topScore.text = "TOP SCORE: " + loadScore.ToString();
            passTopScore.instace.tScore = float.Parse(loadScore.ToString());

            fStream.Close();
        }
        else
        {
            Debug.LogError("Data file not found!");
        }
    }

}
