using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
public class TypeWriterEffect : MonoBehaviour {

	private Coroutine gameCoroutine = null;
	
	private string currentText = "";
	
	public string fullText;
	
	public float duration = 13f;


	// Use this for initialization
	void Start () {
		gameCoroutine = StartCoroutine(ShowText());
	}


	public void StopTypeWriterCorountine() {
		if (gameCoroutine != null)
				StopCoroutine (gameCoroutine);
	}


	IEnumerator ShowText() {
		float delay = duration/fullText.Length;

		for (int i = 0; i < fullText.Length; i++) {
			currentText = fullText.Substring(0,i);

			this.GetComponent<TextMeshProUGUI>().text = currentText;

			yield return new WaitForSeconds(delay);
		}
	}
}
