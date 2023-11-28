using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;

public class InteractionPrompt : MonoBehaviour
{
    public float interactionRange = 5f;
    public KeyCode activateKey = KeyCode.E;
    public string[] wordsToFind;
    public int wordsFound;
    public TextMeshProUGUI cornerText;
    public TextMeshProUGUI middleText;
    private string current_message = "";
    public TMP_Dropdown drop1;
    public TMP_Dropdown drop2;
    public TMP_Dropdown drop3;
    private void Start()
    {
        ShowPrompt("");
        wordsToFind = new string[] { "WordDepression1", "WordDepression2", "WordDepression3" };
        wordsFound = 0;
        drop1.ClearOptions();
        drop1.AddOptions(new List<string>(wordsToFind));
        drop1.gameObject.SetActive(false);
        drop2.ClearOptions();
        drop2.AddOptions(new List<string>(wordsToFind));
        drop2.gameObject.SetActive(false);
        drop3.ClearOptions();
        drop3.AddOptions(new List<string>(wordsToFind));
        drop3.gameObject.SetActive(false);

    }
        private void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out hit, interactionRange))
        {
            // Check if the hit object is interactable (you might use tags or layers)
            if (hit.collider.CompareTag("wordContainer"))
            {
                ShowPrompt("Press E to Interact");
                if (Input.GetKey(activateKey))
                {
                    wordsFound += 1; 
                    hit.collider.gameObject.tag = "retrieved";
                    UpdateWordsFound(wordsToFind[wordsFound - 1]);
                }
            }
            else if (hit.collider.CompareTag("retrieved"))
            {
                ShowPrompt("You found this word already!");
            }
            else if (hit.collider.CompareTag("obstacle"))
            {
                ShowPrompt("You can't go this way!");
            }
            else if (hit.collider.CompareTag("speakable"))
            {
                ShowPrompt("Press E to speak!");
                if (Input.GetKey(activateKey))
                {
                    if (wordsFound == 3)
                    {
                        hit.collider.gameObject.tag = "Untagged";
                        drop1.gameObject.SetActive(true);
                        drop2.gameObject.SetActive(true);
                        drop3.gameObject.SetActive(true);
                        cornerText.gameObject.SetActive(false);
                        middleText.gameObject.SetActive(false);
                        Cursor.visible = true;
                        //Cursor.lockState = CursorLockMode.None;
                    }
                    else
                    {
                        ShowPrompt("You need to find more words!");
                    }


                }
            }
            else
            {
                ShowPrompt("");
            }
        }
        else
        {
            ShowPrompt("");
        }
        
    }

    void ShowPrompt(string message)
    {
        if (middleText != null && middleText.gameObject.activeSelf)
        {
            middleText.text = message;
        }
    }
    void UpdateWordsFound(string message)
    {
        if (cornerText != null && cornerText.gameObject.activeSelf)
        {
            current_message = current_message + "\n" + message;
            cornerText.text = current_message;
        }
    }
}

