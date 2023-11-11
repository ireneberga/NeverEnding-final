using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public Text textField;
    public Button showTextButton;
    private List<string> speechLines;
    private int currentLineIndex = 0;
    
    private void InitializeSpeechLines()
    {
        // Inizializza la lista e aggiungi le tue linee di discorso
        speechLines = new List<string>();
        speechLines.Add("Ciao, sono il tuo personaggio!");
        speechLines.Add("Benvenuto nel fantastico mondo del gioco!");
        speechLines.Add("Oggi affronteremo emozionanti avventure insieme!");
        // Aggiungi ulteriori linee di discorso qui...
    }
    
    public void ShowTextOnClick()
    {
        // Controlla se ci sono ancora linee nel discorso
        if (currentLineIndex < speechLines.Count)
        {
            // Mostra la prossima linea del discorso
            textField.text = speechLines[currentLineIndex];
            currentLineIndex++;
        }
        else
        {
            // Se il discorso è completo, passa alla scena 2
            SceneManager.LoadScene(2); // Assicurati che il nome della scena sia corretto
        }
        // Sostituisci con la frase che desideri visualizzare
        //string yourText = "Questa è la tua frase.";

        // Mostra la frase nella casella di testo
        //textField.text = yourText;
    }
}


