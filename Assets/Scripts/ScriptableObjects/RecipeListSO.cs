using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu()]
// Dans le tuto, on a besoin que d'une liste donc on commente le createAssetMenu.
// Aussi comme il n'y en a qu'une , on le laise dans le dossier des RecipeSO
// et prefixé de l'underscore pour le faire apparaitre en haut de la liste.
public class RecipeListSO : ScriptableObject {
    public List<RecipeSO> recipeSOList;

}
