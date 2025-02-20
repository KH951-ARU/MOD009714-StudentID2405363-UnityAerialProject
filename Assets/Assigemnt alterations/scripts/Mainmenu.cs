using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void StartGame()
    {
        SceneManager.LoadScene("Game Mode");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
