using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
  //Counter for fruits collected
  private int fruits = 0;

  //Text linked to the "Player" script 
  [SerializeField] private Text fruitsText;

  [SerializeField] private AudioSource collectionSoundEffect;

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("Fruit"))
    {
      //Play AudioSource once it is collected
      collectionSoundEffect.Play();

      //Destroy the object once it is collected
      Destroy(collision.gameObject);
      fruits++;
      //Update Fruits text
      fruitsText.text = "Fruits: "+fruits;
    }
  }
}
