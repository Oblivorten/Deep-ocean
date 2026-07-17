using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoatController : MonoBehaviour
{
    private int lifes = 3;
    private float speed = 5f;
    private int score = 0;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverPanel;

    private void Start()
    {
        UpdateText();
        gameOverPanel.SetActive(false);

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

        if (other.CompareTag("Treasure"))
        {
            AddScore();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Booster"))
        {
            AddBooster();
            Destroy(other.gameObject);
        }

        if(other.CompareTag("Healer"))
        {
            Heal();
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

    private void AddScore()
    {
        score++;
        UpdateText();
    }

    private void AddBooster()
    {
        speed += 2f;
    }

    private void Heal()
    {
        if (lifes < 3)
        {
            lifes++;
            UpdateText();
        } else
        {
            return;
        }
    }

    private void UpdateText()
    {
        hpText.text = "HP: " + lifes;
        scoreText.text = "Очки: " + score;
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
