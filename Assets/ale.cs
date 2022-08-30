using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ale : MonoBehaviour
{
    [SerializeField] int _scoreValue;
    Score _score;

    private void Start()
    {
       _score = GameObject.FindObjectOfType<Score>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        //MetHode 1 -Tag
        //if (collision.attachedRigidbody.gameObject.CompareTag("Player"))
        //{
        //    Debug.Log("UN JOUEUR !");
        //}

        //Methode 2
        PlayerTag foundTag = collision.attachedRigidbody.GetComponent<PlayerTag>();
        if(foundTag != null)
        {
            Debug.Log("Un joueur aussi");
            GameObject.Destroy(gameObject);

            _score.AddScore(_scoreValue);

        }
    }
}
