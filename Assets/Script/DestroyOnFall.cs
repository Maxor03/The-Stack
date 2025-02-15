using UnityEngine;

public class DestroyOnFall : MonoBehaviour
{
   
    
    void Update()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
