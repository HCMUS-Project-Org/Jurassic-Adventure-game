using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    // public GameObject flag;
    Vector3 _spawnPoint;
    Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _spawnPoint = transform.position;   
        print(_spawnPoint); 
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController._isPlayerRevival)
        {
            transform.position = _spawnPoint;
            GameController._isPlayerRevival = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        print("checkpoint");
        var colliderGameObject = col.gameObject;

        if (colliderGameObject.CompareTag("CheckPoint"))
        {
            print("Save position");
            _spawnPoint = colliderGameObject.transform.position;
            print(_spawnPoint);
            Destroy(colliderGameObject);
        }
    }
}
