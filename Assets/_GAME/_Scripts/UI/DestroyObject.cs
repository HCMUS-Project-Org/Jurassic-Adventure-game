using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    [SerializeField] private List<string> objectName;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < objectName.Count; i++) {
            Destroy(GameObject.Find(objectName[i]));
        }
    }
}
