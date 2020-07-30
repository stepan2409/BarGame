using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoving : MonoBehaviour
{
  public CharacterController controller;
  
  public float speed = 6.0f;

  public float turnSmoothTime = 0.1f;
  float turnSmoothVelocity;

  private Animator animator;

  public Text amountText;

  public int amountOfBeer;

  public int maximumCapacity;
  void Start()
  {
    animator = GetComponent<Animator>();
    amountOfBeer = maximumCapacity;
    printAmountOfBeer();
  }

  void Update()
  {
    float deltaX = Input.GetAxis("Horizontal");
    float deltaZ = Input.GetAxis("Vertical");
    Vector3 direction = new Vector3(deltaX, 0.0f, deltaZ);

    if (direction.magnitude >= 0.1f)
    {
      float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
      float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
      transform.rotation = Quaternion.Euler(0f, angle, 0f);

      animator.SetFloat("Movement", 1.0f);

      controller.Move(direction * speed * Time.deltaTime);
    } else
    {
      animator.SetFloat("Movement", 0.0f);
    }
  }

  public void DecreaseAmountOfBeer()
  {
    --amountOfBeer;
    printAmountOfBeer();
  }

  void printAmountOfBeer()
  {
    amountText.text = "Beer: " + amountOfBeer;
  }

  public void RefillBottle()
  {
    amountOfBeer = maximumCapacity;
    printAmountOfBeer();
  }
}
