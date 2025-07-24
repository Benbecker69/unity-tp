using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float vitesse = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
       
        float horizontal = 0f;
        float vertical = 0f;

        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            horizontal = -1f;
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            horizontal = 1f;

        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            vertical = 1f;
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            vertical = -1f;

       
        Vector3 mouvement = new Vector3(horizontal, 0f, vertical);
        rb.linearVelocity = new Vector3(mouvement.x * vitesse, rb.linearVelocity.y, mouvement.z * vitesse);
    }
}