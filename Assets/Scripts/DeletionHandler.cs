using UnityEngine;

public class DeletionHandler : MonoBehaviour
{
    public GameObject gb;
    private void Update()
    {
        //update is better for non-physcis calcs
        if (gb != null && gb.transform.position.y < -5.5f)
        {
            Destroy(gb);
        }
    }
}
