using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

    public GameObject PlatCoins;
    public int count = 3;

    public float timeBetSpawnMin = 1.25f;
    public float timeBetSpawnMax = 2.25f;
    private float timeBetSpawn;

    public float yMin = 0.5f;
    public float yMax = 1.5f;
    private float xPos = 20f;

    private GameObject[] Coi;
    private int currentIndex = 0;

    private Vector2 polPosition = new Vector2(0, -25);
    private float lastSpawnTime;

    // Start is called before the first frame update
    void Start() {
        Coi = new GameObject[count];

        for (int i = 0; i < count; i++) {
            Coi[i] = Instantiate(PlatCoins, polPosition, Quaternion.identity);
        }

        lastSpawnTime = 0f;
        timeBetSpawn = 0f;
    }

    // Update is called once per frame
    void Update() {
        if (GameManager.Instance.isGameover) {
            return;
        }

        if (Time.time >= lastSpawnTime + timeBetSpawn) {
            lastSpawnTime = Time.time;

            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);

            float yPos = Random.Range(yMin, yMax);

            Coi[currentIndex].SetActive(false);
            Coi[currentIndex].SetActive(true);

            Coi[currentIndex].transform.position = new Vector2(xPos, yPos);

            currentIndex++;
            /*
            if(currentIndex >= count) {
                currentIndex = 0;
            }
            */
            currentIndex %= count;

        }
    }
}
