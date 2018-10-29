#r "System.Runtime.Serialization.dll"
#load "Serialization.fs"
#load "Encryption.fs"
#load "Product.fs"
#load "ProductMonad.fs"
#load "Agents.fs"

open System
open Product
open ProductMonad
open Agents


let cupOfCoffe = { Id = 1; Name = "Cup of Coffe"; Formulation = [| ("Water", 80.0); ("Sugar", 10.0); ("Coffee", 10.0) |]; FormulaEncrypted = "" }
let orangeJuice = { Id = 2; Name = "Orange Juice"; Formulation = [| ("Water", 80.0); ("Vitamins", 10.0); ("Orange", 10.0) |]; FormulaEncrypted = "" }
let laptop = { Id = 3; Name = "Laptop"; Formulation = [| ("Plastic", 80.0); ("Hard Disk", 10.0 ); ("RAM", 10.0) |]; FormulaEncrypted = "" }

let encrypted = encryptFormulation <| cupOfCoffe.Formulation
let decripted1 = decryptFormulation <| encrypted

decripted1 = cupOfCoffe.Formulation


