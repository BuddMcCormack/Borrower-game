using UnityEngine;

public class CameraBind : MonoBehaviour
{

    public Transform camPosition;
    void Update()
    {
        transform.position = camPosition.position;
    }
}
