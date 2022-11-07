using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TopAtar _TopAtar;
    [SerializeField] private CizgiCiz _CizgiCiz;
    [SerializeField] private TextMeshProUGUI[] ScoreText;
    [SerializeField] private GameObject Panel;
    int GirenTopSayisi;

    void Start()
    {
        GirenTopSayisi = 0;

        if (PlayerPrefs.HasKey("BestScore"))
        {
            ScoreText[0].text = PlayerPrefs.GetInt("BestScore").ToString();
        }
        else
        {
            PlayerPrefs.SetInt("BestScore", 0);
            ScoreText[0].text = PlayerPrefs.GetInt("BestScore").ToString();
        }
    }
        
    void Update()
    {
        
    }

    public void DevamEt()
    {
        _TopAtar.DevamEt();
        _CizgiCiz.DevamEt();
        GirenTopSayisi++;
    }

    public void OyunBitti()
    {
        ScoreText[0].text = PlayerPrefs.GetInt("BestScore").ToString();
        ScoreText[1].text = GirenTopSayisi.ToString();

        if (GirenTopSayisi > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", GirenTopSayisi);
            ScoreText[0].text = PlayerPrefs.GetInt("BestScore").ToString();
        }

        Panel.SetActive(true);
    }
}
