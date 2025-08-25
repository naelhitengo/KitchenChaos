using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private Transform tomatoPrefab;
    //[SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;

    public void Interact()
    {
        Debug.Log("Interact!");
        Transform tomatoTransform = Instantiate(tomatoPrefab, counterTopPoint);
        tomatoPrefab.localPosition = Vector3.zero;
    }

}
