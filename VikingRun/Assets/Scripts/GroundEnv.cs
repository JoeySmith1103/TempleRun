using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnv : MonoBehaviour
{
    SpawnGround groundSpawner;
    public GameObject obstacle; 
    public GameObject shieldPrefab;
    private System.Random rand = new System.Random();

    private bool hasObstacle() {
        int temp = rand.Next(1, 16);
        if (temp == 1) return true;
        else return false;
    }
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<SpawnGround>();
        spawnObstacles();
        spawnShields();
    }

    private void OnTriggerExit(Collider other) {
        groundSpawner.spawnGround();
        Destroy(gameObject, 2);
    }

    void spawnShields() {
        int shields = 1;
        for (int i = 0; i < shields; i++) {
            GameObject temp = Instantiate(shieldPrefab, transform);
            temp.transform.position = randPos(GetComponent<Collider>());
        }
    }

    void spawnObstacles() {
        if (hasObstacle() == false) return;
        int obstacles = UnityEngine.Random.Range(7, 10);
        Transform spawnPos = transform.GetChild(obstacles).transform;
        Instantiate(obstacle, spawnPos.position, Quaternion.identity, transform);
    }

    Vector3 randPos(Collider collider) {
        float rangeX, rangeY, rangeZ;
        rangeX = UnityEngine.Random.Range(collider.bounds.min.x, collider.bounds.max.x);
        rangeY = UnityEngine.Random.Range(collider.bounds.min.y, collider.bounds.max.y);
        rangeZ = UnityEngine.Random.Range(collider.bounds.min.z, collider.bounds.max.z);
        Vector3 position = new Vector3(rangeX, rangeY, rangeZ);
        if (position != collider.ClosestPoint(position))
            position = randPos(collider);
        
        position.y = 1;
        return position;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
