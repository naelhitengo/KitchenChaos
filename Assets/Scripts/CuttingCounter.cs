using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecipeSO[] cuttingRecipeSOArray;
    private int cuttingProgress;

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
                    cuttingProgress = 0;
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
            cuttingProgress++;

            CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());

            if (cuttingProgress >= cuttingRecipeSO.cuttingProgressMax)
            {
                KitchenObjectSO outputKitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());

                GetKitchenObject().DestroySelf();

                KitchenObject.SpawnKitchenObject(outputKitchenObjectSO, this);
            }
        }
    }

    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSo)
    {
        CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(inputKitchenObjectSo);
        return cuttingRecipeSO != null;
    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSo)
    {
        CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(inputKitchenObjectSo);
        if (cuttingRecipeSO != null)
        {
            return cuttingRecipeSO.output;
        }
        else
        {
            return null;
        }
    }

    private CuttingRecipeSO GetCuttingRecipeSOWithInput(KitchenObjectSO inputKitchenObjectSo)
    {
        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray)
        {
            if (cuttingRecipeSO.input == inputKitchenObjectSo)
            {
                return cuttingRecipeSO;
            }
        }
        return null;
    }

}
