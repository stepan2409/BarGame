using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassSpawnController : MonoBehaviour
{
  public GameObject glassPrephab;

  public List<GameObject> spawnPoints = new List<GameObject>();

  public List<bool> isThereAGlass = new List<bool>();

  public int maxAtOnce;

  public float resetTime;
  void Start()
  {
    for (int i = 0; i < spawnPoints.Count; ++i)
    {
      isThereAGlass.Add(false);
    }
    for (int i = 0; i < maxAtOnce; ++i)
    {
      spawnGlass(randomSpawnPoint());
    }
  }

  int randomSpawnPoint()
  {
    for (;;)
    {
      int randomIndex = UnityEngine.Random.Range(0, spawnPoints.Count);
      if (isThereAGlass[randomIndex] == false)
      {
        isThereAGlass[randomIndex] = true;
        return randomIndex;
      }
    }
  }

  void spawnGlass (int spawnPointNumber)
  {
    GameObject spawnedGlass = Instantiate(glassPrephab, spawnPoints[spawnPointNumber].transform.position, Quaternion.identity);
    GlassScript script = spawnedGlass.GetComponent<GlassScript>();
    script.SetPointNumber(spawnPointNumber);
  }

  IEnumerator Waiting ()
  {
    yield return new WaitForSeconds(resetTime);
    //Debug.Log("Waited!");
    spawnGlass(randomSpawnPoint());
    //Debug.Log("Glass spawned!");
  }

  public void glassDestroyed(int pointNumber)
  {
    //Debug.Log("Glass Destroyed!");
    isThereAGlass[pointNumber] = false;
    //Debug.Log("isThereAGlass falsed!");
    StartCoroutine(Waiting());
  }
}
