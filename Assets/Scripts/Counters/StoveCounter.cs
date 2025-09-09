using UnityEngine;

public class StoveCounter
 : BaseCounter
{
    [SerializeField] private FryingRecipeSO[] fryingRecipeSOArray;

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
                    //Player Carrying something that can be Fried.
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



    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSo)
    {
        FryingRecipeSO fryinggRecipeSO = GetFryingRecipeSOWithInput(inputKitchenObjectSo);
        return fryinggRecipeSO != null;
    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSo)
    {
        FryingRecipeSO fryinggRecipeSO = GetFryingRecipeSOWithInput(inputKitchenObjectSo);
        if (fryinggRecipeSO != null)
        {
            return fryinggRecipeSO.output;
        }
        else
        {
            return null;
        }
    }

    private FryingRecipeSO GetFryingRecipeSOWithInput(KitchenObjectSO inputKitchenObjectSo)
    {
        foreach (FryingRecipeSO fryinggRecipeSO in fryingRecipeSOArray)
        {
            if (fryinggRecipeSO.input == inputKitchenObjectSo)
            {
                return fryinggRecipeSO;
            }
        }
        return null;
    }



}
