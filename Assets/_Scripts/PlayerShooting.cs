using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

    // PUBLIC VARIABLES FOR TESTING
    public Transform flashPoint;
    public GameObject muzzleFlash;
    public GameObject explosion;
    public GameObject bulletImpact;
    public AudioSource rifleShotSound;
    public Transform playerCam;

    private Transform _transform;

    // Use this for initialization
    void Start() {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame (for Physics)
    void FixedUpdate() {
        if (Input.GetButtonDown("Fire1")) {
            // show the MuzzleFlash at the FlashPoint without any rotation
            Instantiate(this.muzzleFlash, this.flashPoint.position, Quaternion.identity);

            RaycastHit hit;

            if (Physics.Raycast(playerCam.position, playerCam.forward, out hit)) {

                if (hit.transform.gameObject.CompareTag("Barrels")) {
                    Debug.Log(hit.transform.gameObject);
                    Instantiate(explosion, hit.transform.position, Quaternion.identity);
                    Destroy(hit.transform.gameObject);

                } else {
                    Instantiate(bulletImpact, hit.point, Quaternion.identity);
                }
            }

            // Play Rifle Sound
            this.rifleShotSound.Play();
        }
    }
}
