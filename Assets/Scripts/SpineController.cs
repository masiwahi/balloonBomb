using UnityEngine;

public class SpineController : MonoBehaviour
{
    public float speed = 30f;
    public float lifeTime = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("enemy"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
