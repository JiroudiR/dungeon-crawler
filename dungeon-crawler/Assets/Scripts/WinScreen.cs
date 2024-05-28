using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    public Text WINTEXT;
    [HideInInspector] public PickUpScript pickUp;

    void Start()
    {
        pickUp = FindObjectOfType<PickUpScript>().GetComponent<PickUpScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && pickUp.keyCollected == true)
        {
            WINTEXT.gameObject.SetActive(true);
        }
    }
}
