using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMinotaurArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        // start boss move
        if (col.CompareTag("Player"))
        {
            MinotaurController.locked = false;
            Destroy(gameObject);
        }
    }
}