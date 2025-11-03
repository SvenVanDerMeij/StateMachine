using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DustBlock : MonoBehaviour
{
    private GameObject _player;

    [SerializeField] private GameObject Schrapnel1;
    [SerializeField] private GameObject Schrapnel2;
    [SerializeField] private GameObject Schrapnel3;
    [SerializeField] private GameObject Schrapnel4;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(CheckLeftRight() ? -0.45f : 0.45f, 0, 0);
        
        if (Mathf.Abs(transform.position.x - _player.transform.position.x) < 0.2)
        {
            Instantiate(Schrapnel1, transform.position, Quaternion.identity);
            Instantiate(Schrapnel2, transform.position, Quaternion.identity);
            Instantiate(Schrapnel3, transform.position, Quaternion.identity);
            Instantiate(Schrapnel4, transform.position, Quaternion.identity);
            Destroy(gameObject);
            
        }
        
    }
    private bool CheckLeftRight()
    {
        //Vector2Distance.
        return transform.position.x >= _player.transform.position.x;
    }
}
