using TMPro;
using UnityEngine;

public class CSVToTextTest : MonoBehaviour
{
    [SerializeField] private TextAsset textAssetData;
    [SerializeField] private TMP_InputField textInput;
    
    [SerializeField] private TextMeshProUGUI nameNPC;
    [SerializeField] private TextMeshProUGUI dialogueText;
    
    private string _text;
    
    private void Update() => _text = textInput.text;

    public void Search()
    {
        string[] data = textAssetData.text.Split(new string[] {",", "\n"}, System.StringSplitOptions.None);

        for (int i = 0; i < data.Length; i++)
        {
            if (_text == data[i])
            {
                nameNPC.text = data[i + 1];
                dialogueText.text = data[i + 2];
            }
        }
    }
}
