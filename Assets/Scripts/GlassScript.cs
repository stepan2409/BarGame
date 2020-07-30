using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassScript : MonoBehaviour
{
  public int myPointNumber;

  private GameObject spawnController;

  public void SetPointNumber(int pointNumber)
  {
    myPointNumber = pointNumber;
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      if (other.gameObject.GetComponent<PlayerMoving>().amountOfBeer > 0)
      {
        other.gameObject.GetComponent<PlayerMoving>().DecreaseAmountOfBeer();
        spawnController = GameObject.FindGameObjectWithTag("GameController");
        GlassSpawnController controllerScript = spawnController.GetComponent<GlassSpawnController>();
        controllerScript.glassDestroyed(myPointNumber);
        Destroy(gameObject);
      }
    }
  }
}
