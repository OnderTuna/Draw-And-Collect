using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CizgiCiz : MonoBehaviour
{
    public GameObject LinePrefab; //Cizgi ornegi.
    public GameObject Cizgi; //Ornek cizgiyi aktar.

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public List<Vector2> ParmakPosListesi; //Parmagin hareketini surekli kontrol et.
    public List<GameObject> Cizgiler;
    int CizmeHakki;
    [SerializeField] private TextMeshProUGUI CizgiHakText;

    private void Start()
    {
        CizmeHakki = 3;
        CizgiHakText.text = CizmeHakki.ToString();
    }

    void Update()
    {
        if(CizmeHakki!=0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                CizgiUzunlugu();
            }
            if (Input.GetMouseButton(0))
            {
                Vector2 ParmakPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (Vector2.Distance(ParmakPos, ParmakPosListesi[^1]) > .1f)
                CizgiGunceller(ParmakPos);
            }
        }
        
        if(Cizgiler.Count!= 0 && CizmeHakki != 0) //Cizgiler listemde eleman olmasi cizgi cizilmeye baslandi.
        {
            if (Input.GetMouseButtonUp(0))
            {
                CizmeHakki--;
                CizgiHakText.text = CizmeHakki.ToString();
            }
        }
    }

    void CizgiUzunlugu()
    {
        Cizgi = Instantiate(LinePrefab, Vector2.zero, Quaternion.identity);
        Cizgiler.Add(Cizgi);
        lineRenderer = Cizgi.GetComponent<LineRenderer>();
        edgeCollider = Cizgi.GetComponent<EdgeCollider2D>();
        ParmakPosListesi.Clear(); //Ekranda tekrar cizgi olusturabiliriz.
        ParmakPosListesi.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition)); //x, y koordinatlari. Cift.
        ParmakPosListesi.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.SetPosition(0, ParmakPosListesi[0]); //Cizgi uzunlugu.
        lineRenderer.SetPosition(1, ParmakPosListesi[1]);
        edgeCollider.points = ParmakPosListesi.ToArray();
    }

    void CizgiGunceller(Vector2 GuncelParmakPos)
    {
        ParmakPosListesi.Add(GuncelParmakPos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, GuncelParmakPos);
        edgeCollider.points = ParmakPosListesi.ToArray();
    }

    public void DevamEt()
    {
        if(TopAtar.AtilanTopSayisi == 0)
        {
            foreach (var item in Cizgiler)
            {
                Destroy(item.gameObject);
            }
            Cizgiler.Clear();
            CizmeHakki = 3;
            CizgiHakText.text = CizmeHakki.ToString();
        }        
    }
}
