using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
    
    [SerializeField] private GameObject[] _enemies;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _levelCompleteUI;
    [SerializeField] private GameObject _levelFailedUI;
    [SerializeField] private int _level;


    // Start is called before the first frame update
    void Start() {
        
    }


    // Update is called once per frame
    public void Restart() {
        Debug.Log("Restart level");
    }
}
