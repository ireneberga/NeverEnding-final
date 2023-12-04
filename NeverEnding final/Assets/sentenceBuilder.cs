using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sentenceBuilder : MonoBehaviour
{
    public string[] wordsToFind;
    private string[] options1;
    private string[] options2;
    private string[] options3;
    public TMP_Dropdown drop1;
    public TMP_Dropdown drop2;
    public TMP_Dropdown drop3;
    public TMP_Text outputSentenceText;
    private string[] rightWords;
    public Button Button;
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Button.enabled = false;
        options1 = new string[] { "          ","surrender", "resilience", "reluctance" };
        options2 = new string[] { "          ","apathy", "resignation", "determination" };
        options3 = new string[] { "          ","habits", "cinicism", "pessimism" };
        drop1.ClearOptions();
        drop1.AddOptions(new List<string>(options1));
        drop2.ClearOptions();
        drop2.AddOptions(new List<string>(options2));
        drop3.ClearOptions();
        drop3.AddOptions(new List<string>(options3));
        drop1.onValueChanged.AddListener(delegate { UpdateSentence(); });
        drop2.onValueChanged.AddListener(delegate { UpdateSentence(); });
        drop3.onValueChanged.AddListener(delegate { UpdateSentence(); });
        Button.onClick.AddListener(delegate { ChangeScene(); });
        rightWords = new string[] { "resilience", "determination", "habits" };
        UpdateSentence();
    }
    void UpdateSentence()
    {
        string firstWord = drop1.options[drop1.value].text;
        string secondWord = drop2.options[drop2.value].text;
        string thirdWord = drop3.options[drop3.value].text;

        string sentence = $"Despite facing challenges, you have shown incredible {firstWord}  in your journey. Your commitment to seeking support is a powerful demonstration of your {secondWord} for a brighter future. Embracing positive {thirdWord} , such as gratitude and self-compassion, can significantly contribute to your overall well-being.";
        outputSentenceText.text = sentence;
        if (firstWord == rightWords[0] && secondWord == rightWords[1] && thirdWord == rightWords[2])
        {
            Button.enabled = true;
            drop1.gameObject.SetActive(false);
            drop2.gameObject.SetActive(false);
            drop3.gameObject.SetActive(false);
        }
            
    }
    void ChangeScene()
    {
        //SceneManager.LoadScene("PALUDE", LoadSceneMode.Single);
        SceneManager.LoadScene("PALUDE", LoadSceneMode.Single);
    }
}
