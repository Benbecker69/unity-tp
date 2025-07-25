using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float vitesse = 5f;
    private Rigidbody rb;
    private GameManager gameManager;
    private Vector3 scaleOriginale;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        scaleOriginale = transform.localScale;
    }

    void Update()
    {
        
        if (transform.position.y < -5f)
        {
            if (gameManager != null)
                gameManager.GameOver();
            return;
        }

        
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

        
        if (mouvement.magnitude > 0.1f) 
        {
            
            float angleInclinaison = 15f;
            transform.rotation = Quaternion.Euler(vertical * angleInclinaison, 0, -horizontal * angleInclinaison);

            
            transform.localScale = scaleOriginale;
        }
        else 
        {

            float respiration = Mathf.Sin(Time.time * 3f) * 0.05f + 1f;
            transform.localScale = new Vector3(
                scaleOriginale.x * respiration,
                scaleOriginale.y,
                scaleOriginale.z * respiration
            );

          
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 5f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            
            Destroy(other.gameObject);

            
            if (gameManager != null)
                gameManager.CollecterObjet();
        }
    }

    void OnDisable()
    {

        if (transform != null && scaleOriginale != Vector3.zero)
        {
            transform.localScale = scaleOriginale;
            transform.rotation = Quaternion.identity;
        }
    }
}