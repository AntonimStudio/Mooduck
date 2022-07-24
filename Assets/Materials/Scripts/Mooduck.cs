using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mooduck : MonoBehaviour
{
     public BoxCollider2D bc;


    public void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    public void Update()
    {
        
    }
}
