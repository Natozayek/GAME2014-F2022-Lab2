using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 2.0f;
    public Boundary boundary;
    public float verticalPosition;
    public bool usingMobileInput = false;
    public ScoreManager scoreManager;
    public GameObject bulletPrefab;

    private float _fireRate = 0.25f;
    private float _canFire = -1f;

    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();

        transform.position = new Vector2(0.0f, verticalPosition);
        camera = Camera.main;

        // Platform Detection for input
        usingMobileInput = Application.platform == RuntimePlatform.Android ||
                           Application.platform == RuntimePlatform.IPhonePlayer;
    }

    // Update is called once per frame
    void Update()
    {
        if (usingMobileInput)
        {
            GetMobileInput();
        }
        else
        {
            GetConventionalInput();
        }
        
        Move();


        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }
    }

    void GetConventionalInput()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        transform.position += new Vector3(x, 0, 0);
    }

    void GetMobileInput()
    {

        foreach (Touch touch in Input.touches)
        {
            var destination = camera.ScreenToWorldPoint(touch.position);
            transform.position = Vector2.Lerp(transform.position, destination, Time.deltaTime * speed);
        }
    }

    void Move()
    {
        float clampedXPosition = Mathf.Clamp(transform.position.x, boundary.min, boundary.max);
        transform.position = new Vector2(clampedXPosition, verticalPosition);
    }

    void FireLaser()
    {
        _canFire = Time.time + _fireRate;

      
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
        
    }
}
