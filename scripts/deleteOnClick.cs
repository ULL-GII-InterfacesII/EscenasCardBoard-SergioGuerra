using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteOnClick : MonoBehaviour
{
  public int cubes = 0;

  public void delete() {
    Destroy(gameObject);
    cubes++;
  }
}
