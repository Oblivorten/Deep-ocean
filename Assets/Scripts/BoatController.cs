using UnityEngine;

public class BoatController : MonoBehaviour
{
    private int lifes = 3;
    private float speed = 5f;
    private int score = 0;
    
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector3 vector3 = new Vector3(xAxis, yAxis, 0f);
        transform.position += vector3 * speed * Time.deltaTime;
    }
}
