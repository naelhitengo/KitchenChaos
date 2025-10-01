# Guide `.editorconfig` pour C

Ce document détaille les principales règles d'un fichier `.editorconfig`
pour C# et leurs alternatives possibles.

------------------------------------------------------------------------

## Racine

``` ini
root = true
```

-   Indique que ce fichier `.editorconfig` est la **racine**.\
-   Si absent, VS / VS Code peut chercher des règles plus haut dans
    l'arborescence.

------------------------------------------------------------------------

## Indentation

``` ini
[*.cs]
indent_style = space
indent_size = 4
```

-   `indent_style` :
    -   `space` → indentation avec espaces (standard C#).\
    -   `tab` → indentation avec tabulations.
-   `indent_size` :
    -   `4` → style .NET / Visual Studio (par défaut).\
    -   `2` → plus compact (souvent JS/TS).

------------------------------------------------------------------------

## Organisation des `using`

``` ini
dotnet_sort_system_directives_first = true
```

-   `true` → place les `using System.*` en haut.\
-   `false` → ne force pas l'ordre.

------------------------------------------------------------------------

## Règles de formatage

### Nouvelle ligne avant les accolades

``` ini
csharp_new_line_before_open_brace = all
```

-   `all` → accolade sur nouvelle ligne (style VS).\
-   `none` → accolade collée (style K&R).\
-   `methods`, `types`, `properties`... → granularité fine.

### Indentation des `case`

``` ini
csharp_indent_case_contents = true
```

-   `true` → contenu des `case` indenté.\
-   `false` → pas d'indentation supplémentaire.

### Indentation des labels `case`

``` ini
csharp_indent_switch_labels = true
```

-   `true` → `case` indentés dans le `switch`.\
-   `false` → alignés avec `switch`.

------------------------------------------------------------------------

## Utilisation de `this.`

``` ini
dotnet_style_qualification_for_field = false:suggestion
dotnet_style_qualification_for_property = false:suggestion
dotnet_style_qualification_for_method = false:suggestion
```

-   `true` → impose `this.` partout.\
-   `false` → pas de `this.` sauf ambiguïté.\
-   Gravité :
    -   `suggestion` → simple recommandation.\
    -   `warning` → avertissement dans l'IDE.\
    -   `error` → erreur de build possible.

------------------------------------------------------------------------

## Exemples complets

### Style Visual Studio (par défaut)

``` ini
root = true

[*.cs]
indent_style = space
indent_size = 4

dotnet_sort_system_directives_first = true

csharp_new_line_before_open_brace = all
csharp_indent_case_contents = true
csharp_indent_switch_labels = true

dotnet_style_qualification_for_field = false:suggestion
dotnet_style_qualification_for_property = false:suggestion
dotnet_style_qualification_for_method = false:suggestion
```

### Style compact (alternatif)

``` ini
root = true

[*.cs]
indent_style = space
indent_size = 2

dotnet_sort_system_directives_first = false

csharp_new_line_before_open_brace = none
csharp_indent_case_contents = false
csharp_indent_switch_labels = false

dotnet_style_qualification_for_field = true:error
dotnet_style_qualification_for_property = true:error
dotnet_style_qualification_for_method = true:error
```
