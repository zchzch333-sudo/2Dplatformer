
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LivesSystem : MonoBehaviour
{
    public int lives = 3;
    public TMP_Text livesText;

    private bool damaged = false;
    private bool isCoolingDown = false;

    void Start()
    {
        livesText.text = "Lives: " + lives;
    }

    void Update()
    {
        if (damaged == true && isCoolingDown == false)
        {
            lives--;
            livesText.text = "Lives: " + lives;

            isCoolingDown = true;

            if (lives <= 0)
            {
                SceneManager.LoadScene(
                    SceneManager.GetActiveScene().buildIndex
                );
            }
            else
            {
                Invoke("EndCooldown", 3f);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hazard"))
        {
            damaged = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Hazard"))
        {
            damaged = false;
        }
    }

    void EndCooldown()
    {
        isCoolingDown = false;
    }
}

