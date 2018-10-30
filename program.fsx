#r "System.Runtime.Serialization.dll"
#load "Serialization.fs"
#load "Encryption.fs"
#load "Product.fs"

open System
open Product

let cupOfCoffe = encryptProd { Id = 1; Name = "Cup of Coffe"; Formulation = [| ("Water", 80.0); ("Sugar", 10.0); ("Coffee", 10.0) |]; }
let orangeJuice = encryptProd { Id = 2; Name = "Orange Juice"; Formulation = [| ("Water", 80.0); ("Vitamins", 10.0); ("Orange", 10.0) |]; }
let laptop = encryptProd { Id = 3; Name = "Laptop"; Formulation = [| ("Plastic", 80.0); ("Hard Disk", 10.0 ); ("RAM", 10.0) |]; }

bind (cupOfCoffe, cupOfCoffe.Formulation)
