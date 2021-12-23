using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float turn = -90f;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<Obstacle>() != null) {
            Destroy(gameObject);
            return;
        }

        if (other.gameObject.name != "Player") return;

        CountScore.score += 10;
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, turn * Time.deltaTime, 0);
    }
}
