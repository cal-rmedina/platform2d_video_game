using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  //Varible to connect player-camera movements
  //"Player" dragged to the Transform of "Main Camera"
  [SerializeField] private Transform player;

  private void Update()
  {
    //Get "Player" position (x,y), "z" remains as the position already assigned
    transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
  }
}
