using System;
using UnityEditor;
using UnityEngine;

public class BumperHit : MonoBehaviour
{
    [SerializeField] private int scoreValue = 100;
    public static event Action<string, int> onBumperHit;
    
    private ParticleSystem ps;
    private void Start(){
        ps = GetComponent<ParticleSystem>();

        ps?.Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            onBumperHit?.Invoke(gameObject.tag, scoreValue);

            ps?.Stop();
            
            ps?.Play();
        }
    }
}
