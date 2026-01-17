using System;
using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;

public class LebkuchenteigAufPlatte : MonoBehaviour
{
    public Vector3 startPos;
    public Collider2D platte;
    public bool aufPlatte;
    public GameObject LebkuchenteigAufPlattePhase1;    
    public GameObject LebkuchenteigInSchuessel;
    void Start()
    {
        startPos= transform.position;
    }
    void OnMouseDrag()
    {
        if (GameManager.Instance.phase==1)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position= new Vector3(mousePos.x, mousePos.y,-1);
        }
    }
    void OnMouseUp()
    {
        if (GameManager.Instance.phase==1)
        {
            if (aufPlatte)
            {
                GameManager.Instance.phase+=1;
                LebkuchenteigInSchuessel.SetActive(false);
                LebkuchenteigAufPlattePhase1.SetActive(true);
            }
            transform.position=startPos;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.CompareTag("Platte"))
        {
            aufPlatte=true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    { 
        if (other.CompareTag("Platte"))
        {
            aufPlatte=false;
        }
    }

}
