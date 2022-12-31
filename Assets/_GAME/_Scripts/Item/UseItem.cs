using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    [SerializeField] private KeyCode onKey;
    // [SerializeField] private ItemSlot item;

    private void Update()
    {
        if (Input.GetKeyDown(onKey))
        {
            Use();
        }
    }

    private void Use()
    {
        if (transform.childCount == 1)
        {
            transform.GetComponentInChildren<Item>().Use();
        }
    }
}