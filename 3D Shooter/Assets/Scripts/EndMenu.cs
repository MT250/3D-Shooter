using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void End()
    {
        game_manager.instance.SaveData(game_manager.instance.score);
        SceneManager.LoadScene("Scenes/Menu");
    }
}
