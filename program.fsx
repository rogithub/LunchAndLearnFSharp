#r "System.Runtime.Serialization.dll"
#load "Serialization.fs"
#load "Encryption.fs"
#load "Product.fs"
#load "ProdSerializer.fs"

open System
open Product
open Serialization
open ProdSerializer

let rand = Random()
let beverages = [|"Wine"; "Beer"; "Yogurth"; "Coffee"; "Soft drink"; "Orange Juice"; "Wiskey"; "Lemonade"|]
let ingredients = [|"Water"; "Alcohol"; "Flavor"; "Sugar"; "Milk"; "Vitamin A"; "Row Malt"; "Coffe Grains"; "Calcium Carbonate"; "Yeast"; "Vanilla extract"|]

let rec getElementFromArray (arr:'a[]) =
    let newVal = rand.Next(0, arr.Length);
    arr.[newVal]

let arrayGenerator () =    
    seq { 0 .. rand.Next(0, 9) .. 20 } |> Seq.toArray

let ingredientsGenerator =
    arrayGenerator() |> Array.map (fun x -> { Name=getElementFromArray ingredients; Percent=(float x)} )

let productGenerator amount =        
    [ for i in 0 .. amount -> i] |> List.map (fun x -> { Name=getElementFromArray beverages; Formulation=ingredientsGenerator; FormulationEncrypted="" } )
    
let productGeneratorJson amount =        
    let products = productGenerator amount
    products |> List.map (fun p -> serializeJson p) 
    
    
    
    
//|> List.fold (fun strBuilder prodStr -> strBuilder.append(prodStr)) new StringBuilder()
///let water = { Name="Water"; Percent=10.00 }
///let sugar = { Name="Sugar"; Percent=10.00 }
///let coffeeGrains = { Name="Coffe Grains"; Percent=80.00 }
///let prodCofee = { Name="Coffee"; Formulation=[|water; coffeeGrains; sugar|]; FormulationEncrypted="" }

///toString prodCofee |> fromString
