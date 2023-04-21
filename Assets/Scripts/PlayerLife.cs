using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
  //Components 
  private Rigidbody2D rb;	//Reference for Rigidbody2D
  private Animator anim;	//Reference for Animator

  [SerializeField] private AudioSource deathSoundEffect;

  private void Start()
  {
    //Setting components
    rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
  }

  //Function for collision with Tramp
  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Trap"))
    {
      Die();
    }
  }

  //Death function
  private void Die()
  {
    deathSoundEffect.Play();
    rb.bodyType = RigidbodyType2D.Static; 
    anim.SetTrigger("death");
  }

  //Restart level function called directrly on the animation (animator event)
  private void RestartLevel()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
