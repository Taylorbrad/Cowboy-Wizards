using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

  public int timeToLive;
  public Transform bulletTransform;
  bool dieOrNo;
    // Start is called before the first frame update
    void Start()
    {
      if (gameObject.name.Contains("(Clone)"))
      {
        dieOrNo = true;
      }
      else
      {
        dieOrNo = false;
      }
    }

    // Update is called once per frame
    void Update()
    {

      if (dieOrNo)
      {
        --timeToLive;
      }

        if (timeToLive < 1 && dieOrNo)
        {
          Destroy(gameObject);
        }
    }
}
