using UnityEngine;

public class MineMovement : MonoBehaviour
{
   
    private float speed = 5f;
    private Vector3 direction = Vector3.left;
    private float deleteCoordinate = -20f;

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        
        if (transform.position.x <= deleteCoordinate)
        {
            Destroy(gameObject);
        }
        
    }
}
