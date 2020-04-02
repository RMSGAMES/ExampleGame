using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private GameController gameController;

    #region Private
    private int hitCount;
    private float forceSensitivity;
    private Rigidbody2D _rigidbody;

    private Vector2? _forceDirection;
    #endregion

    private void Awake()
    {
        hitCount = PlayerPrefs.GetInt("hitCount", 0);
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();

        forceSensitivity = GameData.Instance.GetCurrentPlanet().gravity / 2;
    }

    private void Update()
    {
        _forceDirection = gameController.inputController.GetInputDirection();
        if (_forceDirection != null)
        {
            Vector2 direction = (Vector2)_forceDirection;
            _rigidbody.AddForce(new Vector2(direction.x - transform.position.x, direction.y - transform.position.y).normalized * forceSensitivity, ForceMode2D.Force);
        }
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("hitCount", hitCount);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        hitCount++;

        if (coll.gameObject.CompareTag("Ground"))
        {
            CameraShake.Shake(0.5f, 0.075f, CameraShake.ShakeMode.XY);
        }
    }
}