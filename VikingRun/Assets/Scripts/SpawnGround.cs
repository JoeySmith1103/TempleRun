using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnGround : MonoBehaviour
{
    [SerializeField] private GameObject ground;
    Vector3 nextSpawn;
    private System.Random rand = new System.Random();
    private int forward = 5;
    private int left = 0, right = 0;

    private int randNum() {
        if (forward != 0) {
            forward--;
            int hole = rand.Next(1, 9);
            if (hole == 1)
                return 4;
            return 1;
        }
        if (right != 0) {
            right--;
            int hole = rand.Next(1, 9);
            if (hole == 1)
                return 5;
            return 3;
        }
        if (left != 0) {
            left--;
            int hole = rand.Next(1, 9);
            if (hole == 2)
                return 6;
            return 2;
        }
        int temp = rand.Next(1, 15);
        if (temp <= 10 && temp >= 1) {
            forward = 5;
            return 1;
        }
        else if (temp >= 11 && temp <= 12) {
            left = 5;
            return 2;
        }
        else {
            right = 5;
            return 3;
        }
    }
    public void spawnGround() {
        int rnd = randNum();
        GameObject temp = Instantiate(ground, nextSpawn, Quaternion.identity);
        nextSpawn = temp.transform.GetChild(rnd).transform.position;
    }

    // Start is called before the first frame update
    void Start() {
        for (int i = 0; i < 45; i++)
            spawnGround();
    }

    // Update is called once per frame
    void Update() {

    }
}
