using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public  static GameManager Instance;

    public bool isGameover = false;
    public TextMeshProUGUI scoreText;
    public GameObject gameoverUI;

    private int score = 0;
    private void Awake() {
      if(Instance == null) {
            Instance = this;
        }
        else {
            Debug.LogWarning("���� �ΰ� �̻��� ���� �Ŵ����� ���� �մϴ�!");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameover && Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene(0);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void AddScore(int newScore) {
        if (!isGameover) {
            score += newScore;
            scoreText.text = "Score: " + score;
        }
    }

    public void OnPlayerDead() {
        isGameover = true;
        gameoverUI.SetActive(true);
    }
}
