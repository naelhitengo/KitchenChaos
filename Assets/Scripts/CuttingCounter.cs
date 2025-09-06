using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecipeSO[] cuttingRecipeSOArray;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // There is no KitchenObject here.
            if (player.HasKitchenObject())
            {
                // Player is carrying something.
                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
                {
                    //Player Carrying something that can be cut.
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                }
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
            }
            else
            {
                //Player is not carrying anything.
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    public override void InteractAlternate(Player player)
    {
        if (HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO()))
        {
            // There is a KitchenObject here AND it can be cut.
            KitchenObjectSO outputKitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());
            GetKitchenObject().DestroySelf();

            KitchenObject.SpawnKitchenObject(outputKitchenObjectSO, this);
        }
    }

    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSo)
    {
        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray)
        {
            if (cuttingRecipeSO.input == inputKitchenObjectSo)
            {
                return true;
            }
        }
        return false;
    }
    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSo)
    {
        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray)
        {
            if (cuttingRecipeSO.input == inputKitchenObjectSo)
            {
                return cuttingRecipeSO.output;
            }
        }
        return null;
    }

}
