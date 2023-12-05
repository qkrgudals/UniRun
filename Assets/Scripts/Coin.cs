using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject[] Coi;
    // Start is called before the first frame update
    private void OnEnable() {

        for (int i = 0; i < Coi.Length; i++) {
            if (Random.Range(0, 2) == 0) {
                Coi[i].SetActive(true);
            }
            else {
               Coi[i].SetActive(false);
            }
        }
    }
}
