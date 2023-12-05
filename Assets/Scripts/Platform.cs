using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] obtacles;
    private bool stepped = false;
    // Start is called before the first frame update
    private void OnEnable() {
        
        stepped = false;

        for(int i=0; i<obtacles.Length; i++) {
            if(Random.Range(0,6) == 0) {
                obtacles[i].SetActive(true);
            }
            else {
                obtacles[i].SetActive(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.tag == "Player" && !stepped) {
            stepped=true;
            GameManager.Instance.AddScore(1);
        }
    }
}
