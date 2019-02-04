using UnityEngine;

public class passTopScore : MonoBehaviour
{
    #region Singleton
    public static passTopScore instace;
    private void Awake()
    {
        instace = this;

        DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    public float tScore;

    public void SelfDestruct()
    {
        Destroy(gameObject, .1f);
    }
}
