using System.ComponentModel;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // There is no KitchenObject here.
            if (player.HasKitchenObject())
            {
                // Player is carrying something.
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                //Player is not carrying anything.
            }
        }
        else
        {
            // There is a KitchenObject here.
            if (player.HasKitchenObject())
            {
                // Player is carrying something.
                Debug.Log("Player is carrying something.");
                if (player.GetKitchenObject().TryGetPlate( out PlateKitchenObject plateKitchenObject))
                {
                    // Player is holding a Plate.
                    Debug.Log("Player is holding a Plate.");
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                        Debug.Log("GetKitchenObject().DestroySelf();");
                    }
                }
            }
            else
            {
                //Player is not carrying anything.
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

}
