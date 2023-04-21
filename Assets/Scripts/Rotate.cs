using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
  //Rotational speed: (speed*360) to get the rotation per second
  [SerializeField] private float speed = 2f;

  private void Update()
  {
    //Rotation on the z (xy-plane fixed)
    transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
  }
}
