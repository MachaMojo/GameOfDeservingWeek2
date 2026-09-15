using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnder : MonoBehaviour
{
    private bool inRange = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange && FindObjectsByType<TicketCount>()[0].IsComplete()) {
            SceneManager.LoadScene("EndScreen");
        }
    }
    void OnTriggerEnter2D()
    {
        inRange = true;
    }
    void OnTriggerExit2D()
    {
        inRange = false;
    }
}
