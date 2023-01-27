using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    public GameObject jumpscare;
    public CameraShake cameraShake;
    public AudioSource scream;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movmentVector = movementValue.Get<Vector2>();

        movementX = movmentVector.x;
        movementY = movmentVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 9)
        {
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement*speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }

        else if (other.gameObject.CompareTag("jumpscare"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();

            Debug.Log("jumpscare");

            jumpscare.SetActive(true);
            StartCoroutine(cameraShake.Shake(1f, 8f));
            scream.Play();
            StartCoroutine(SetJumpscare());
            
        }
    }

    IEnumerator SetJumpscare()
    {
        yield return new WaitForSeconds(1.0f);
        jumpscare.SetActive(false);
    }
}
