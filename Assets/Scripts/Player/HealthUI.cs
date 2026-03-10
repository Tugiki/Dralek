using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    public Image heartPrefab; // Kalp prefabý, Unity Editor üzerinden atanacak
    public Sprite fullHeartSprite; // Dolu kalp sprite'ý, Unity Editor üzerinden atanacak
    public Sprite emptyHeartSprite; // Boþ kalp sprite'ý, Unity Editor üzerinden atanacak

    private List<Image> hearts = new List<Image>(); // Kalp UI elemanlarýný tutacak liste

    public void SetMaxHearts( int  maxHearts)
    {
        foreach( Image heart in hearts)
        {
            Destroy(heart.gameObject); // Eski kalp UI elemanlarýný temizle
        }
        hearts.Clear(); // Listeyi temizle

        for (int i = 0; i < maxHearts; i++)
        {
            Image newHeart = Instantiate(heartPrefab, transform); // Kalp prefabýný UI'ya ekle
            newHeart.sprite = fullHeartSprite; // Baþlangýçta tüm kalpler dolu olarak ayarlanýr
            newHeart.color = Color.red; // Kalp rengini kýrmýzý yap
            hearts.Add(newHeart); // Kalp UI elemanýný listeye ekle
        }
    }

    public void UpdateHearts(int currentHealth)
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeartSprite; // Mevcut saðlýk kadar kalbi dolu yap
                hearts[i].color = Color.red; // Dolu kalpler kýrmýzý renkte gösterilir
            }
            else
            {
                hearts[i].sprite = emptyHeartSprite; // Kalan kalpleri boþ yap
                hearts[i].color = Color.white; // Boþ kalpler beyaz renkte gösterilir
            }
        }
    }




}
