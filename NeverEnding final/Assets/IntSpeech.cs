using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDialogue : MonoBehaviour
{
    public List<string> dialogueLines; // Elenco delle frasi del personaggio
    private int currentLine = 0; // Indice della frase corrente
    private bool isSpeaking = false; // Indica se il personaggio sta parlando
    public Text dialogueText; // Riferimento all'oggetto Text UI
    public Button nextButton; // Riferimento al pulsante "Next"

    void Start()
    {
        // Assicurati che i riferimenti siano assegnati nell'editor Unity.
        if (dialogueText == null)
        {
            Debug.LogError("Assegna un oggetto Text UI al campo 'dialogueText'.");
        }
        if (nextButton == null)
        {
            Debug.LogError("Assegna un oggetto Button al campo 'nextButton'.");
        }
        else
        {
            // Aggiungi un listener al pulsante "Next" per chiamare il metodo NextLine() quando viene premuto.
            nextButton.onClick.AddListener(NextLine);
        }
    }

    void Update()
    {
        // Controlla se il personaggio sta parlando
        if (isSpeaking)
        {
            // Mostra la frase corrente
            dialogueText.text = dialogueLines[currentLine];
        }
    }

    // Metodo per avviare il discorso del personaggio
    public void StartDialogue()
    {
        isSpeaking = true;
        currentLine = 0;
        dialogueText.text = string.Empty; // Resetta il testo all'inizio del dialogo
        // Imposta le frasi del dialogo qui
        dialogueLines = new List<string>
        {
            "Benvenuto nel mondo del gioco!",
            "Sono un personaggio e voglio dirti qualcosa.",
            "Ecco una frase di esempio.",
            "Puoi aggiungere ulteriori frasi qui.",
            "Quando il dialogo è completo, passeremo alla scena successiva."
        };
        NextLine(); // Avvia il primo dialogo
    }

    // Metodo per passare alla frase successiva
    private void NextLine()
    {
        currentLine++;

        // Controlla se ci sono altre frasi nel dialogo
        if (currentLine < dialogueLines.Count)
        {
            // Continua il discorso
        }
        else
        {
            // Fine del dialogo
            EndDialogue();
        }
    }

    // Metodo per terminare il dialogo
    private void EndDialogue()
    {
        isSpeaking = false;
        currentLine = 0;
        dialogueText.text = string.Empty; // Resetta il testo quando il dialogo è terminato
        // Esegui azioni aggiuntive quando il dialogo è terminato, ad esempio passare alla scena successiva.
    }
}
