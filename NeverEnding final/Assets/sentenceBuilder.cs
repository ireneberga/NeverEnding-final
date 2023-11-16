using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System.Collections.Generic;


public class SentenceBuilder : MonoBehaviour
{
    public Dropdown subjectDropdown;
    public Dropdown verbDropdown;
    public Dropdown objectDropdown;
    public Text resultText;

    // Define arrays of predefined word choices for each part of the sentence
    private string[] subjects = { "The cat", "The dog", "A bird" };
    private string[] verbs = { "jumped", "slept", "flew" };
    private string[] objects = { "on the mat", "under the tree", "across the sky" };

    void Start()
    {
        // Populate Dropdown options with predefined choices
        subjectDropdown.AddOptions(new List<Dropdown.OptionData>(subjects.Select(s => new Dropdown.OptionData(s))));
        verbDropdown.AddOptions(new List<Dropdown.OptionData>(verbs.Select(v => new Dropdown.OptionData(v))));
        objectDropdown.AddOptions(new List<Dropdown.OptionData>(objects.Select(o => new Dropdown.OptionData(o))));

        // Add listeners to Dropdowns
        subjectDropdown.onValueChanged.AddListener(UpdateResultText);
        verbDropdown.onValueChanged.AddListener(UpdateResultText);
        objectDropdown.onValueChanged.AddListener(UpdateResultText);
    }

    void UpdateResultText(int value)
    {
        // Build and display the sentence based on the selected options
        string sentence = subjects[subjectDropdown.value] + " " +
                          verbs[verbDropdown.value] + " " +
                          objects[objectDropdown.value];

        resultText.text = "Result: " + sentence;
    }
}
