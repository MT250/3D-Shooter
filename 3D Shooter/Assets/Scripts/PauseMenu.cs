using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void EndGame()
    {
        game_manager.instance.SaveData(game_manager.instance.score);
        SceneManager.LoadScene("Scenes/Menu");
    }

    public void ReturnToGame()
    {
        PlayerManager.instace.player.SetActive(true);

        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        game_manager.instance.pauseUI.SetActive(false);
    }
}
