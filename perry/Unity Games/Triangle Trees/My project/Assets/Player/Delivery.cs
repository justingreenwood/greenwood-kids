using UnityEngine;

public class Delivery : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Goods"))
        {
            Debug.Log("Got the goods!");
        }
        else if (collision.CompareTag("DeliveryDestination"))
        {
            Debug.Log("Delivered the goods!");
        }
        else if (collision.CompareTag("Customer"))
        {
            Debug.Log("Oops!");
        }
    }

}
