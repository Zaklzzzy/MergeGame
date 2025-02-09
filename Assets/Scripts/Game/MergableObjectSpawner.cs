using UnityEngine;

public class MergableObjectSpawner : MonoBehaviour
{
    public static MergableObjectSpawner Instance { get; private set; }


    [SerializeField] private GameObject[] _prefabs;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public GameObject Spawn(int type)
    {
        return _prefabs[type];
    }
}
