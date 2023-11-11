using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class IntSpeech : MonoBehaviour
{
    public Text textField;
    //public Button showTextButton;
    private List<string>  speechLines;
    private int currentLineIndex = 0;
    
    private void InitializeSpeechLines()
    {
        // Inizializza la lista e aggiungi le tue linee di discorso
        speechLines = new List<string>();
        speechLines.Add("Hi I'm Falkor the Luck Dragon!");
        speechLines.Add("Welcome to Fantàsia, or better to say, what is left...");
        speechLines.Add("The Nothing is destroying this wonderful world");
        speechLines.Add("The Nothing is the emptiness that surrounds us. It's spreading because people have given up on hoping and forget their own dreams");
        speechLines.Add("In order to save Fantàsia from the Nothing you have to fight your interiors monsters");
        speechLines.Add("In the next page you have to choose the size of the interiors monsters according to the amount of negative influence that have on you");
        speechLines.Add("Later you will face different situations that will help you to fight them and finally save Fantàsia. Good luck my friend!");
        // Aggiungi ulteriori linee di discorso qui...
    }
    
    public void ShowTextOnClick()
    {
        // Controlla se ci sono ancora linee nel discorso
        if (currentLineIndex == 0)
        {
            InitializeSpeechLines();
            textField.text = speechLines[currentLineIndex];
            currentLineIndex++;
        }
        else if (currentLineIndex < speechLines.Count)
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


