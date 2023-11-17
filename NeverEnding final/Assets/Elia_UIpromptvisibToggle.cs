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
    public Canvas sentenceCanvas;
    private void Start()
    {
        ShowPrompt("");
        wordsToFind = new string[] { "WordDepression1", "WordDepression2", "WordDepression3" };
        wordsFound = 0;
        RectTransform rectTransform = cornerText.GetComponentInChildren<RectTransform>();

        // Imposta l'ancoraggio nell'angolo in basso a sinistra
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);

        // Imposta la posizione in base al pivot (0, 0 rappresenta l'angolo in basso a sinistra)
        rectTransform.anchoredPosition = new Vector2(0, 0);
        
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
                    hit.collider.gameObject.tag = "Untagged";
                    sentenceCanvas.enabled = true;
                    GameManager.instance.gameMode = 0;
                    Cursor.lockState = CursorLockMode.None;

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
        middleText.text = message;
    }
    void UpdateWordsFound(string message)
    {
        current_message = current_message + "\n" + message;
        cornerText.text = current_message;
    }
}

