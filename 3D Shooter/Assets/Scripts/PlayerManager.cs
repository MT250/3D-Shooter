using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager instace;

    private void Awake()
    {
        instace = this;
    }
    #endregion

    public GameObject player;
    public Text healthTextUI;
    public float playerHealth = 100f;

    [SerializeField]
    private float curPlayerHealth;

    private void Start()
    {
        curPlayerHealth = playerHealth;
    }

    private void FixedUpdate()
    {
        //Check HP
        if (curPlayerHealth <= 0)
        {
            curPlayerHealth = 0f;
            game_manager.instance.EndGame();
        }
        //Draw HP in UI text
        healthTextUI.text = (curPlayerHealth.ToString("0") + "%");
        //
    }

    public void TakeDamage(float _damage)
    {
        curPlayerHealth -= _damage;
    }

    public void Heal(float _healAmount)
    {
        if (curPlayerHealth == 100f)
        {
     
        }
        else if (curPlayerHealth  < 100f)
        {
            curPlayerHealth += _healAmount;
            if (curPlayerHealth > 100f) { curPlayerHealth = 100f; }
        }
    }
}
