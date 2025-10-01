# Variantes de `csharp_new_line_before_open_brace`

Ce tableau décrit toutes les valeurs possibles pour la règle
`csharp_new_line_before_open_brace` dans `.editorconfig`.

  ----------------------------------------------------------------------------------------------------------------------------------------------------------
  Valeur                  S'applique à...  Exemple avec retour à la ligne                             Exemple sans retour (collé)
  ----------------------- ---------------- ---------------------------------------------------------- ------------------------------------------------------
  **all**                 Tous les         `csharp if (x) {     DoSomething(); }`                     ---
                          éléments listés                                                             
                          ci-dessous                                                                  

  **none**                Aucun élément    ---                                                        `csharp if (x) {     DoSomething(); }`

  **types**               classes,         `csharp class MyClass { }`                                 `csharp class MyClass { }`
                          structs,                                                                    
                          interfaces,                                                                 
                          enums                                                                       

  **methods**             méthodes,        `csharp void Foo() { }`                                    `csharp void Foo() { }`
                          constructeurs,                                                              
                          destructeurs                                                                

  **properties**          propriétés,      `csharp int MyProp {     get;     set; }`                  `csharp int MyProp {     get;     set; }`
                          indexers,                                                                   
                          accessors                                                                   

  **control_blocks**      if, else, for,   `csharp if (x) {     DoSomething(); }`                     `csharp if (x) {     DoSomething(); }`
                          foreach, while,                                                             
                          do, try, catch,                                                             
                          finally, using,                                                             
                          lock                                                                        

  **anonymous_methods**   délégués         `csharp var d = delegate() {     return 1; };`             `csharp var d = delegate() {     return 1; };`
                          anonymes                                                                    

  **lambdas**             lambdas avec     `csharp Func<int> f = () => {     return 1; };`            `csharp Func<int> f = () => {     return 1; };`
                          bloc                                                                        

  **local_functions**     fonctions        `csharp void Bar() {     void Inner()     {     } }`       `csharp void Bar() {     void Inner() {     } }`
                          locales (C# 7+)                                                             

  **accessors**           accesseurs `get` `csharp int X {     get     {         return 0;     } }`   `csharp int X {     get {         return 0;     } }`
                          / `set` / `init`                                                            
  ----------------------------------------------------------------------------------------------------------------------------------------------------------

------------------------------------------------------------------------

## Notes

-   On peut **combiner plusieurs valeurs** séparées par des virgules :

    ``` ini
    csharp_new_line_before_open_brace = types, methods
    ```

-   `all` = équivalent à
    `types, methods, properties, control_blocks, anonymous_methods, lambdas, local_functions, accessors`.\

-   `none` = aucun retour à la ligne (style compact).
