using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class FireController : MonoBehaviour
{
    public Transform aimTr;

    private int shootCount = 10;
    private int shootMax = 10;

    public float reloadTime = 2f;

    private float reloadCount = 0f;

    public Text ShootText;

    public GameObject bulletPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aimTr = GameObject.Find("AimSpot").GetComponent<Transform>();

        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (shootCount > 0)
            {
                Instantiate(bulletPrefab, aimTr.position, aimTr.rotation);
                shootCount--;
            }
        }

        if (shootCount < shootMax)
        {
            reloadCount += Time.deltaTime;

            if (reloadCount >= reloadTime)
            {
                shootCount++;
                reloadCount = 0f;
            }
        }

        UpdateShootText();
    }

    private void UpdateShootText()
    {
        ShootText.text = shootCount + " / " + shootMax;
    }
}
