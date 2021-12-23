using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerMove playerMove;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = GameObject.FindObjectOfType<PlayerMove>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Player") {
            playerMove.die();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
