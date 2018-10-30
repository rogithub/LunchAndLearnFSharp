#r "System.Runtime.Serialization.dll"
#load "Serialization.fs"
#load "Encryption.fs"
#load "Product.fs"

open System
open Product

let cupOfCoffe = ({ Id = 1; Name = "Cup of Coffee" }, [| ("Water", 80.0); ("Sugar", 10.0); ("Coffee", 10.0) |]) 
let orangeJuice = ({ Id = 2; Name = "Orange Juice" }, [| ("Water", 80.0); ("Vitamins", 10.0); ("Orange", 10.0) |])
let laptop = ({ Id = 3; Name = "Laptop" }, [| ("Plastic", 80.0); ("Hard Disk", 10.0 ); ("RAM", 10.0) |])


lift cupOfCoffe
