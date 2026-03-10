using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public HealthUI healthUI; // HealthUI referansý, Unity Editor üzerinden atanacak

    private SpriteRenderer spriteRenderer; // Oyuncunun SpriteRenderer'ý, hasar alýrken görsel efekt için kullanýlacak

    void Start()
    {
        currentHealth = maxHealth; // Baþlangýçta saðlýk maksimum deðere ayarlanýr
        healthUI.SetMaxHearts(maxHealth); // HealthUI'ya maksimum kalp sayýsýný bildir
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SlimeEnemy enemy = collision.GetComponent<SlimeEnemy>();  //SADECE SLIME ENEMY'YE ÇARPTIÐINDA HASAR ALIR BUNUN GÜNCELLENMESÝ GEREKLÝ
        if (enemy)
        {
            TakeDamage(enemy.damage); // Düþmana çarptýðýnda 1 hasar al
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage; // Saðlýktan hasarý çýkar
        healthUI.UpdateHearts(currentHealth); // HealthUI'ya güncellenmiþ saðlýk durumunu bildir

        if (currentHealth <= 0)
        {
             // Saðlýk sýfýr veya altýna düþtüðünde öl
        }
    }

    private IEnumerator FlashRed()
    {

    }
}
