using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextButtonScript : MonoBehaviour
{
    public Text TutorialText;
    //public Button showTextButton;
    private List<string>  speechLines;
    private int currentLineIndex = 0;
    public GameObject heart1, heart2, heart3, layer1, layer2, layer3;
    private string mostro1 = "big anxia"; 
    public static bool flagtut = false;
    
    private void InitializeSpeechLines()
    {
        // Inizializza la lista e aggiungi le tue linee di discorso
        speechLines = new List<string>();
        speechLines.Add("In the following game the dragon will move up and down according to the rhythm of the breath, try to follow it with the arrows of your board");
        TutorialCharacterMovement.active = true;

        if (mostro1 == "small anxia ")
        {
            speechLines.Add("Now that you have understood how it works let's have five minutes of relaxation");
        }
        else if (mostro1 == "medium anxia")
        {
            speechLines.Add("If you press the the wrong arrow or the rhythm with which you press the arrows is wrong for too many times a warning will appear");
            speechLines.Add("Try to correct yourself and enjoy five minutes of relaxation ");
        }
        else if(mostro1 == "big anxia")
        {
            speechLines.Add("The lives that you have left are shown in the up left corner");
            TranslateObject(heart1);
            TranslateObject(heart2);
            TranslateObject(heart3);
            TranslateObject(layer1);
            TranslateObject(layer2);
            TranslateObject(layer3);
            speechLines.Add("If you press the the wrong arrow or the rhythm with which you press the arrows is wrong for too many times ahe number of lives that you have left will decreases");
            speechLines.Add("If you loose all your lives you will restart the five minutes of meditation");
            
        }


        // Aggiungi ulteriori linee di discorso qui...
    }
    
    public void ShowTextOnClick()
    {
        Debug.Log(currentLineIndex);
        // Controlla se ci sono ancora linee nel discorso
        if (currentLineIndex == 0)
        {
            InitializeSpeechLines();
            TutorialText.text = speechLines[currentLineIndex];
            currentLineIndex++;
        }
        else if (currentLineIndex < speechLines.Count)
        {
            // Mostra la prossima linea del discorso
            TutorialText.text = speechLines[currentLineIndex];
            currentLineIndex++;
        }
        else
        {
            // Se il discorso è completo, passa alla scena 2
            SceneManager.LoadScene(4); // Assicurati che il nome della scena sia corretto
        }
        // Sostituisci con la frase che desideri visualizzare
        //string yourText = "Questa è la tua frase.";

        // Mostra la frase nella casella di testo
        //textField.text = yourText;
    }
    
    void TranslateObject(GameObject obj)
    {
        if (obj != null)
        {
            // Traslazione di 240 unità verso destra
            obj.transform.Translate(Vector3.right * 600f);
        }
        else
        {
            Debug.LogWarning("Oggetto non assegnato.");
        }
    }
}

