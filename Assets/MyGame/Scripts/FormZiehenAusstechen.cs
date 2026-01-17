using System;
using UnityEngine;

public class FormZiehenAusstechen : MonoBehaviour
{
    public Vector3 startPos;
    public Collider2D Teig;
    public bool aufTeig;
    public GameObject LebkuchenteigAufPlattePhase3; 
    public GameObject Lebkuchenhaus;     
    void Start()
    {
        startPos= transform.position;
    }
    void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position= new Vector3(mousePos.x, mousePos.y,-1);
        if (GameManager.Instance.phase==4)
        {
            if (aufTeig)
            {
                GameManager.Instance.phase+=1;
                LebkuchenteigAufPlattePhase3.SetActive(false);
                Lebkuchenhaus.SetActive(true);
            }
        }
    }
    void OnMouseUp()
    {
        transform.position=startPos;
    }
    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.CompareTag("Platte"))
        {
            aufTeig=true;

        }
    }
    void OnTriggerExit2D(Collider2D other)
    { 
        if (other.CompareTag("Platte"))
        {
            aufTeig=false;
        }
    }
}
