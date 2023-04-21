using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
  //Just one audioSource in "Finish" object (no "SerializeField" needed)
  private AudioSource finishSound;

  private bool levelCompleted = false;

  private void Start()
  {
    finishSound = GetComponent<AudioSource>();
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    //Conditional for object colliding with "Player" and levelCompleted is false
    if (collision.gameObject.name == "Player" && !levelCompleted)
    {
      finishSound.Play();
      levelCompleted = true;
      //Delay of 2 seconds for the level change
      Invoke("CompleteLevel",2f);
    }
  }

  //Funtion to move to next level (add + 1 current scene)
  private void CompleteLevel()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }
}
