using UnityEngine;

public class MergableObject : MonoBehaviour
{
    [SerializeField] private ObjectType _objectType;

    public ObjectType Type => _objectType;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var mergeObj = collision.gameObject.GetComponent<MergableObject>();
        if (mergeObj != null)
        {
            if (mergeObj.Type == _objectType)
            {
                Debug.Log("Types Equal");
                //Destroy(collision.gameObject);
                //Destroy(gameObject);
            }
        }
    }
}
