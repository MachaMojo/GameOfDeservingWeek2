using UnityEngine;
using TMPro;

public class TicketCount : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public int limit = 0;
    private int count = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textComponent.text = count + "/" + limit;
    }

    public bool AddToCounter()
    {
        if (count < limit)
        {
            count++;
            textComponent.text = count + "/" + limit;
            return true;
        }
        else
        {
            return false;
        }

    }
    public bool IsComplete()
    {
        return count >= limit;
    }
}
