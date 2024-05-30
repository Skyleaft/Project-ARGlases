using UnityEngine;

public class GlassSpawner : MonoBehaviour
{
    public void Spawn(GameObject obj)
    {
        if (transform.childCount > 0)
        {
            GameObject.Destroy(transform.GetChild(0).gameObject);
            Instantiate(obj, transform.position, transform.rotation, this.transform);
        }
        else
            Instantiate(obj, transform.position, transform.rotation, this.transform);
    }
}
