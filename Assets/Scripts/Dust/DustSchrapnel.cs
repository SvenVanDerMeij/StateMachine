using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustSchrapnel : MonoBehaviour
{
    [SerializeField] private float HorSpeed;
    [SerializeField] private float VerSpeed;
    // Start is called before the first frame update
    private float killtimer = 2;

    // Update is called once per frame
    void FixedUpdate()
    {
        killtimer -= Time.deltaTime;
        transform.position += new Vector3( HorSpeed, VerSpeed, 0);
        if (killtimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
