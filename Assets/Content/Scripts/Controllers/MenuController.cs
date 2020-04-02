using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;

    #region Private
    private int totalScore = 0;
    #endregion

    private void OnEnable()
    {
        totalScore = PlayerPrefs.GetInt("hitCount", 0);
        score.text = "BallHit : " + totalScore;
    }

    public void LoadScene(int id)
    {
        if ((id + 1) > GameData.Instance.planets.Count) { return; }

        GameState.currentPlanetID = id;
        SceneManager.LoadSceneAsync(GameData.Instance.gameScene, LoadSceneMode.Single);
    }

    private static MenuController _instance;
    public static MenuController Instance
    {
        get
        {
            if (_instance == null) { _instance = FindObjectOfType<MenuController>(); }
            return _instance;
        }
    }
}