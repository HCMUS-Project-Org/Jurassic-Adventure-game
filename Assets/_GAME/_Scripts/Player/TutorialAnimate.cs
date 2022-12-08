using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAnimate : MonoBehaviour
{
    public Animator animator;
    public string parameter;
    public bool value;

    // Start is called before the first frame update
    void Start()
    {
            animator.SetBool(parameter, value);    
    }
}
