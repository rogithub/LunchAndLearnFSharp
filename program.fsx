#r "System.Runtime.Serialization.dll"
#load "Serialization.fs"
#load "Encryption.fs"
#load "Product.fs"
open Product
let water = { Name="Water"; Percent=10.10 }
let grains = { Name="Coffe Grains"; Percent=80.10 }
let prod = { Name="Coffee"; Formulation=[|water; grains|]; FormulationEncrypted="" }
toString prod |> fromString
