using TMPro;
using UnityEngine;

public class Silo : MonoBehaviour
{
    [Header("Silo Inputs")] // Custom inputs from the player ( in the inspector )
    public string siloNameInput;
    public int siloFillInput;
    public string tagInput;

    [Header("Technical")] // Required functional objects
    public TextMeshPro siloText;

    private int currentFill; // Current silo contents
    void Start()
    {
        siloText.text = siloNameInput + " " + currentFill + " / " + siloFillInput;
    }
    private void OnTriggerEnter(Collider other) // OnTriggerEnter if meets requirements it is deposited
    {
        if (!(currentFill > siloFillInput) && other.gameObject.CompareTag(tagInput))
        {
            currentFill++;
            siloText.text = siloNameInput + " " + currentFill + " / " + siloFillInput;
            Destroy(other.gameObject);
        }
        else
        {
            Debug.Log("Wrong Game Object Collided or Full");
            Debug.Log(other);
        }
    }

    public void ResetSiloFill()
    {
        currentFill = 0;
        siloText.text = siloNameInput + " " + currentFill + " / " + siloFillInput;
    }
}
