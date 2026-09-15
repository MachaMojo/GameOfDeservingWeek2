using UnityEngine;
using TMPro;

public class NPCName : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string Name;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Name == null)
        {
            textComponent.text = "";
        }
        else
        {
            textComponent.text = Name;
        }
    }
}
