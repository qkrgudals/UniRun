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
            Debug.LogWarning("씬에 두개 이상의 게임 매니저가 존재 합니다!");
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
