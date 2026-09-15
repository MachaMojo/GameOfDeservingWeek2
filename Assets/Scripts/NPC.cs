using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject errorBox;
    public string Name;
    public string [] CharacterLines;
    public string [] AltCharacterLines;
    private int index = 0;
    private bool inRange = false;
    private bool isTalking = false;
    private bool gotTicket = false;
    private Dialogue dialogueScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.T)) && inRange && !isTalking)
        {
            isTalking = true;
            GameObject dialogueCanvas = Instantiate(dialogueBox, transform.position, transform.rotation);
            dialogueScript = dialogueCanvas.GetComponentInChildren<Dialogue>();
            dialogueCanvas.GetComponentInChildren<NPCName>().Name = Name;
            if (Input.GetKeyDown(KeyCode.E) && !gotTicket) {
                dialogueScript.lines = new string[CharacterLines.Length];
                foreach (string s in CharacterLines)
                {
                    dialogueScript.lines[index] = CharacterLines[index];
                    index++;
                }
            }
            else if (Input.GetKeyDown(KeyCode.E) && gotTicket)
            {
                dialogueScript.lines = new string[AltCharacterLines.Length];
                foreach (string s in AltCharacterLines)
                {
                    dialogueScript.lines[index] = AltCharacterLines[index];
                    index++;
                }
            }
            else if (Input.GetKeyDown(KeyCode.T) && !gotTicket)
            {
                if (FindObjectsByType<TicketCount>()[0].AddToCounter())
                {
                    gotTicket = true;
                    dialogueScript.lines = new string[AltCharacterLines.Length];
                    foreach (string s in AltCharacterLines)
                    {
                        dialogueScript.lines[index] = AltCharacterLines[index];
                        index++;
                    }  
                }
            }
            else
            {
                dialogueCanvas.GetComponentInChildren<NPCName>().Name = "Scientist";
                dialogueScript.lines = new string[1];
                dialogueScript.lines[0] = "You have already given that one a ticket.";
            }
            index = 0;
        }
        if (dialogueScript == null || !dialogueScript.isActiveAndEnabled)
        {
            isTalking = false;
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
