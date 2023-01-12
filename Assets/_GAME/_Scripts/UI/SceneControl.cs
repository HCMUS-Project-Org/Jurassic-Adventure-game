using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControl : MonoBehaviour
{
    public float delay;
    [SerializeField] private GameObject[] _scene;
    void Start()
    {
        for (int i = 0; i < 3; ++i)
        { StartCoroutine(LoadSceneAfterDelay(delay, _scene[i], _scene[i + 1])); Debug.Log(i); }
        
    }

    IEnumerator LoadSceneAfterDelay(float delay, GameObject CurrentScene, GameObject NextScene)
    {
        Debug.Log("a");
        yield return new WaitForSeconds(delay);
        
        CurrentScene.SetActive(false);
        NextScene.SetActive(true);
    }
}
