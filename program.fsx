#r "System.Runtime.Serialization.dll"
#load "Serialization.fs"
#load "Encryption.fs"
#load "Product.fs"

open Product

let water = { Name="Water"; Percent=10.00 }
let sugar = { Name="Sugar"; Percent=10.00 }
let coffeeGrains = { Name="Coffe Grains"; Percent=80.00 }
let prodCofee = { Name="Coffee"; Formulation=[|water; coffeeGrains; sugar|]; FormulationEncrypted="" }

toString prodCofee |> fromString
