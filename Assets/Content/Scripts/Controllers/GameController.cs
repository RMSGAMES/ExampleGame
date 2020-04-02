using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Private
    private GameData _gameData;
    private Camera _camera;
    #endregion

    [HideInInspector] public InputController inputController;

    private void Awake()
    {
        _gameData = GameData.Instance;
        _camera = Camera.main;

#if UNITY_EDITOR
        inputController = gameObject.AddComponent<MouseController>();
#endif

#if UNITY_ANDROID && !UNITY_EDITOR
		inputController = gameObject.AddComponent<TouchController>();
#endif

        SetupPlanet(GameData.Instance.GetCurrentPlanet());
    }

    private void SetupPlanet(PlanetInfo info)
    {
        _camera.backgroundColor = info.color;
        Physics2D.gravity = new Vector2(0, -info.gravity);
    }

    private void Update()
    {
        if (inputController.GetButtonBack())
        {
            SceneManager.LoadSceneAsync(_gameData.menuScene, LoadSceneMode.Single);
        }
    }
}
