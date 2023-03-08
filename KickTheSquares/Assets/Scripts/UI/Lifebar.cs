using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lifebar : MonoBehaviour
{
    public const string GameOverSceneName = "GameOver";
    
    [SerializeField] private int healthCountByDefault = 5;
    [SerializeField] private Image healthImage;
    
    private int _health;

    public int Health => _health;

    private void Awake()
    {
        _health = healthCountByDefault;

        DrawLifebar();
    }

    private void DrawLifebar()
    {
        var childCount = transform.childCount;
        
        if (childCount > 0)
        {
            for (int i = 0; i < childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
        
        for (int i = 0; i < _health; i++)
        {
            var heart = Instantiate(healthImage, transform);
            heart.transform.localScale = new Vector3(1, 1, 1);
        } 
    }

    private void Die()
    {
        SceneManager.LoadScene(GameOverSceneName);
    }
    
    public void TakeDamage()
    {
        _health -= 1;
        DrawLifebar();
        
        if (_health <= 0)
            Die();
    }
}
