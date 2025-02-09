using UnityEngine;
using UnityEngine.InputSystem;

public enum ObjectType
{
    ExtraSmall,
    Small,
    Meduim,
    Large,
    ExtraLarge
};

public class ObjectsController : MonoBehaviour
{
    public static ObjectsController Instance { get; private set; }

    [SerializeField] private Transform _leftBorder;
    [SerializeField] private Transform _rightBorder;

    private InputSystem_Actions _inputActions;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        _inputActions = new InputSystem_Actions();
        _inputActions.Enable();
    }

    private void Update()
    {
        MoveObjectSpawner();
    }

    private void MoveObjectSpawner()
    {
        var input = Camera.main.ScreenToWorldPoint(_inputActions.UI.Point.ReadValue<Vector2>());

        var xPos = Mathf.Clamp(input.x, _leftBorder.position.x + 0.3f, _rightBorder.position.x - 0.3f);

        gameObject.transform.position = new Vector2(xPos, gameObject.transform.position.y);
    }

    public void DropObject(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("DropObjects");
            var obj = gameObject.GetComponentInChildren<Rigidbody2D>();
            if (obj != null)
            {
                obj.constraints = RigidbodyConstraints2D.None;
                obj.transform.parent = null;

                var newObject = Random.Range(0, 4);
                var spawned = Instantiate(MergableObjectSpawner.Instance.Spawn(newObject), gameObject.transform);
                spawned.transform.localPosition = new Vector3(0f, 0f, 0f);
            }
        }
    }
}
