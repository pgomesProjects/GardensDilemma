using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour
{

    public float bouncePower = 4000.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Bounce!");
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, bouncePower));
        }
    }


}
