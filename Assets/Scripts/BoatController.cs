using TMPro;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    private int lifes = 3;
    private float speed = 5f;
    private int score = 0;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        UpdateText();
    }

    private void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector3 vector3 = new Vector3(xAxis, yAxis, 0f);
        transform.position += vector3 * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mine"))
        {
            TakeDamage();
            Destroy(other.gameObject);
        }
    }

    private void TakeDamage()
    {
        lifes--;
        if (lifes <= 0)
        {
            GameOver();
        }
        UpdateText();
    }

    private void UpdateText()
    {
        hpText.text = "HP: " + lifes;
        scoreText.text = "Очки: " + score;
    }

    private void GameOver()
    {
        return;
    }


}
