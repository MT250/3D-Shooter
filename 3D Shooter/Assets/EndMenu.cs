using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void End()
    {
        SaveScore();
        SceneManager.LoadScene("Scenes/Menu");
    }

    public void SaveScore()
    {
        //game_manager.instance.score
    }
}
