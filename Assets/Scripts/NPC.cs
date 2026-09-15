using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject dialogueBox;
    public string [] CharacterLines;
    private int index = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject dialogueCanvas = Instantiate(dialogueBox, transform.position, transform.rotation);
            Dialogue dialogueScript = dialogueCanvas.GetComponentInChildren<Dialogue>();
            dialogueScript.lines = new string[CharacterLines.Length];
            foreach (string s in CharacterLines)
            {
                dialogueScript.lines[index] = CharacterLines[index];
                index++;
            }
            index = 0;
        }
    }
}
