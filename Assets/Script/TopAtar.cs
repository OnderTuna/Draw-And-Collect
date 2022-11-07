using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopAtar : MonoBehaviour
{
    [SerializeField] private GameObject[] Toplar;
    [SerializeField] private GameObject[] KovaPoint;
    int AktifTopIndex;
    [SerializeField] private GameObject _TopAtar;
    [SerializeField] private GameObject Kova;
    bool Kilit;
    public static int AtilanTopSayisi;
    public static int TopAtisSayi;

    void Start()
    {
        TopAtisSayi = 0;
        AtilanTopSayisi = 0;
        StartCoroutine(TopAtisSistemi());
    }

    //void Update()
    //{
    //    //if(Input.GetKeyDown(KeyCode.Space))
    //    {
    //        //Toplar[AktifTopIndex].transform.position = _TopAtar.transform.position;
    //        //Toplar[AktifTopIndex].SetActive(true);

    //        //float _RandomAci = Random.Range(70f, 110f);
    //        //Vector3 Pos = Quaternion.AngleAxis(_RandomAci, Vector3.forward) * Vector3.right; //Bir aci olustur.
    //        //Toplar[AktifTopIndex].GetComponent<Rigidbody2D>().AddForce(Pos * 750);

    //        //if (AktifTopIndex == Toplar.Length - 1)
    //        //{
    //        //    AktifTopIndex = 0;
    //        //}
    //        //else
    //        //{
    //        //    AktifTopIndex++;
    //        //}

    //        //Invoke(nameof(KovayiOrtayaCikart), .5f);
    //    }
    //}

    //void KovayiOrtayaCikart()
    //{
    //    int randomSayi = Random.Range(0, KovaPoint.Length - 1);
    //    Kova.transform.position = KovaPoint[randomSayi].transform.position;
    //    Kova.SetActive(true);
    //}

    IEnumerator TopAtisSistemi()
    {
        while (true)
        {
            if (!Kilit)
            {
                yield return new WaitForSeconds(.5f);
                //Toplar[AktifTopIndex].transform.position = _TopAtar.transform.position;
                //Toplar[AktifTopIndex].SetActive(true);

                if (TopAtisSayi != 0 && TopAtisSayi % 5 == 0)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        //Toplar[AktifTopIndex].transform.position = _TopAtar.transform.position;
                        //Toplar[AktifTopIndex].SetActive(true);
                        //Toplar[AktifTopIndex].GetComponent<Rigidbody2D>().AddForce(750 * PosVer(AciVer(70, 110)));
                        //if (AktifTopIndex == Toplar.Length - 1)
                        //{
                        //    AktifTopIndex = 0;
                        //}
                        //else
                        //{
                        //    AktifTopIndex++;
                        //}

                        AtisIslem();
                    }
                    AtilanTopSayisi = 2;
                    TopAtisSayi++;
                }
                else
                {
                    //Toplar[AktifTopIndex].transform.position = _TopAtar.transform.position;
                    //Toplar[AktifTopIndex].SetActive(true);
                    //Toplar[AktifTopIndex].GetComponent<Rigidbody2D>().AddForce(750 * PosVer(AciVer(70, 110)));
                    //if (AktifTopIndex == Toplar.Length - 1)
                    //{
                    //    AktifTopIndex = 0;
                    //}
                    //else
                    //{
                    //    AktifTopIndex++;
                    //}

                    AtisIslem();

                    AtilanTopSayisi = 1;
                    TopAtisSayi++;
                }


                //float _RandomAci = Random.Range(70f, 110f);
                //Vector3 Pos = Quaternion.AngleAxis(_RandomAci, Vector3.forward) * Vector3.right; //Bir aci olustur.
                //Toplar[AktifTopIndex].GetComponent<Rigidbody2D>().AddForce(Pos * 750);

                if (AktifTopIndex == Toplar.Length - 1)
                {
                    AktifTopIndex = 0;
                }
                else
                {
                    AktifTopIndex++;
                }

                yield return new WaitForSeconds(.75f);
                int randomSayi = Random.Range(0, KovaPoint.Length - 1);
                Kova.transform.position = KovaPoint[randomSayi].transform.position;
                Kova.SetActive(true);
                Kilit = true;

                Invoke(nameof(TopuKontrolEt), 5f);
            }
            else
            {
                yield return null;
            }
        }
    }

    public void DevamEt()
    {
        if(AtilanTopSayisi == 1)
        {
            Kilit = false;
            Kova.SetActive(false);
            CancelInvoke();
            AtilanTopSayisi--;
        }
        else
        {
            AtilanTopSayisi--;
        }
    }

    void TopuKontrolEt() //Eger kilit true ise top girmeiyp sikisti, oyun bitti.
    {
        if(Kilit)
        {
            GetComponent<GameManager>().OyunBitti();
        }
    }

    float AciVer(float deger1, float deger2)
    {
        return Random.Range(deger1, deger2);
    }

    Vector3 PosVer(float deger1)
    {
        return Quaternion.AngleAxis(deger1, Vector3.forward) * Vector3.right;
    }

    void AtisIslem()
    {
        Toplar[AktifTopIndex].transform.position = _TopAtar.transform.position;
        Toplar[AktifTopIndex].SetActive(true);
        Toplar[AktifTopIndex].GetComponent<Rigidbody2D>().AddForce(750 * PosVer(AciVer(70, 110)));
        if (AktifTopIndex == Toplar.Length - 1)
        {
            AktifTopIndex = 0;
        }
        else
        {
            AktifTopIndex++;
        }
    }
}
