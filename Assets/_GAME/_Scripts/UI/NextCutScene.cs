using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class NextCutScene : MonoBehaviour, IPointerDownHandler
{
    private int clickTime = 0;
    [SerializeField] TMPro.TextMeshProUGUI sceneText;
    private string fullText;

    void Awake() 
    {
        sceneText = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();    
        fullText =  sceneText.GetComponent<TypeWriterEffect>().fullText;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        clickTime++;
        Debug.Log("ClickyButton" + clickTime);
        string s = sceneText.text;
        if (clickTime == 1) {

            // disable TypeWriterEffect script
        sceneText.GetComponent<TypeWriterEffect>().enabled = false;
        sceneText.text= "ddddddddddddddd";

        Debug.Log("full:" + fullText);
            Debug.Log("Disable " + sceneText.GetComponent<TypeWriterEffect>());
            // s = sceneText.GetComponent().fullText;
            // Debug.Log("TextObj" + s);

        }
        Debug.Log("TextObj" + s);

    }

   
}
