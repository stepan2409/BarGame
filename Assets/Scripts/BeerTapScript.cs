using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerTapScript : MonoBehaviour
{
  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      other.gameObject.GetComponent<PlayerMoving>().RefillBottle();
    }
  }

  /*private void OnCollisionEnter(Collision collision)
  {
    if (collision.collider.gameObject.CompareTag("Player"))
    {
      collision.collider.gameObject.GetComponent<PlayerMoving>().RefillBottle();
    }
  }*/
}
