using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CollisionControl : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;
    public PlayerController playerController;
    public int minScore;
    public Animator PlayerAnim;
    public GameObject Player;
    public GameObject FinishPanel;

    private void Start()
    {
        PlayerAnim = Player.GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("FinishLine"))
        {
            playerController.runningSpeed = 0;
            transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
            FinishPanel.SetActive(true);

            if (score >= minScore)
            {
                PlayerAnim.SetBool("Win", true);
            }
            else
            {
                PlayerAnim.SetBool("Lose", true);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddCoin()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }
}
