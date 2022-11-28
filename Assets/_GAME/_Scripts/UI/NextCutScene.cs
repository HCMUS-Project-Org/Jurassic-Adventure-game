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
    private string fullText;
    [SerializeField] TMPro.TextMeshProUGUI sceneText;
    [SerializeField] GameObject currentCutScene;
    [SerializeField] GameObject nextCutScene;

    void Awake() 
    {
        sceneText = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();    
        fullText =  sceneText.GetComponent<TypeWriterEffect>().fullText;
    }

    private void NextScene() {
        // load next cutscene
        if (nextCutScene)  {
            currentCutScene.SetActive(false);
            nextCutScene.SetActive(true);    
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        clickTime++;
        
        if (clickTime == 1) {
            // stop TypeWriterEffect script
            sceneText.GetComponent<TypeWriterEffect>().StopTypeWriterCorountine();

            if (fullText.Equals(sceneText.text)) {
                NextScene();
            }
            else 
            {
                sceneText.text = fullText;
                
                // stop sound
                GameObject.Find("Voice").GetComponent<AudioSource>().enabled = false;
            }
            
        } else {
            NextScene();
        }
    }
}
