using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endMenu : MonoBehaviour
{
    public void backToMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void restart() {
        CountScore.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
