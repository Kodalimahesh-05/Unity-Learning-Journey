using Unity.VisualScripting;
using UnityEngine;

public class Collectiblework : MonoBehaviour
{
    private void OnTriggerEnter(Collider Other)
    {
        if (Other.CompareTag("Player"))
        {
            Debug.Log("Player has collected the item!");
            Destroy(gameObject);
        }
    }
}
