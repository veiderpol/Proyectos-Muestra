using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUG_SiguientePos : MonoBehaviour
{

    public GameObject Cortina;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Cortina.SetActive(true);
        }
    }
}
