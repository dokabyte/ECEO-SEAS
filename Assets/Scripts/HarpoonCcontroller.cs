using System.Collections;
using UnityEngine;

public class HarpoonController : MonoBehaviour
{
    public Transform firePoint;
    public float harpoonSpeed = 20f;
    public GameObject harpoonPrefab;
    public AudioClip shootSound; // Adicione uma variável para o som de disparo

    private AudioSource audioSource;
    private bool canShoot = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Obtém o componente AudioSource
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component missing from this game object. Please add an AudioSource component.");
        }
    }

    void Update()
    {
        RotateHarpoonToMouse();

        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            ShootHarpoon();
        }
    }

    void RotateHarpoonToMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void ShootHarpoon()
    {
        canShoot = false;

        GameObject harpoon = Instantiate(harpoonPrefab, firePoint.position, transform.rotation);
        Rigidbody2D rb = harpoon.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * harpoonSpeed;

        if (audioSource != null && shootSound != null)
        {
            audioSource.PlayOneShot(shootSound); // Toca o som de disparo
        }
        else
        {
            Debug.LogError("Missing AudioSource or Shoot Sound. Please assign both in the Inspector.");
        }

        StartCoroutine(ResetShootCooldown());
    }

    IEnumerator ResetShootCooldown()
    {
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
    }
}
