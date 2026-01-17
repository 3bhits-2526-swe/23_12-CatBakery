using UnityEngine;

public class NudelholzZiehen : MonoBehaviour
{

    public Vector3 startPos;
    public Collider2D Teig;
    public bool aufTeig1;
    public bool aufTeig2;
    public GameObject LebkuchenteigAufPlattePhase1; 
    public GameObject LebkuchenteigAufPlattePhase2; 
    public GameObject LebkuchenteigAufPlattePhase3; 

    void Start()
    {
        startPos= transform.position;
    }
    void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position= new Vector3(mousePos.x, mousePos.y,-2);
        if (GameManager.Instance.phase==2)
        {
            if (aufTeig1)
            {
                GameManager.Instance.phase+=1;
                LebkuchenteigAufPlattePhase1.SetActive(false);
                LebkuchenteigAufPlattePhase2.SetActive(true);
            }
        }
        if (GameManager.Instance.phase==3)
        {
            if (aufTeig2)
            {
                GameManager.Instance.phase+=1;
                LebkuchenteigAufPlattePhase2.SetActive(false);
                LebkuchenteigAufPlattePhase3.SetActive(true);
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
            if (GameManager.Instance.phase==2)
            {
                aufTeig1=true;
            }else
            {
                aufTeig2=true;
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    { 
        if (other.CompareTag("Platte"))
        {
            if (GameManager.Instance.phase==2)
            {
                aufTeig1=false;
            }else
            {
                aufTeig2=false;
            }
        }
    }
}
