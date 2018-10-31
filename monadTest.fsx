#r "System.Runtime.Serialization.dll"
#load "Serialization.fs"
#load "Encryption.fs"
#load "Product.fs"
#load "Monad.fs"
open System
open myFsharpProject.Product
open myFsharpProject.Monad


let cupOfCoffeE = FEncrypt ({Id = 1; Name = "Cup of Coffee";},"W3sibV9JdGVtMSI6IldhdGVyIiwibV9JdGVtMiI6ODB9LHsibV9JdGVtMSI6IlN1Z2FyIiwibV9JdGVtMiI6MTB9LHsibV9JdGVtMSI6IkNvZmZlZSIsIm1fSXRlbTIiOjEwfV0=")
let orangeJuiceE = FEncrypt ({Id = 2; Name = "Orange Juice";}, "W3sibV9JdGVtMSI6IldhdGVyIiwibV9JdGVtMiI6ODB9LHsibV9JdGVtMSI6IlZpdGFtaW5zIiwibV9JdGVtMiI6MTB9LHsibV9JdGVtMSI6Ik9yYW5nZSIsIm1fSXRlbTIiOjEwfV0=")
let laptopE = FEncrypt ({Id = 3; Name = "Laptop";}, "W3sibV9JdGVtMSI6IlBsYXN0aWMiLCJtX0l0ZW0yIjo4MH0seyJtX0l0ZW0xIjoiSGFyZCBEaXNrIiwibV9JdGVtMiI6MTB9LHsibV9JdGVtMSI6IlJBTSIsIm1fSXRlbTIiOjEwfV0=")

let cupOfCoffe = ({ Id = 1; Name = "Cup of Coffee" }, [| ("Water", 80.0); ("Sugar", 10.0); ("Coffee", 10.0) |])
let orangeJuice = ({ Id = 2; Name = "Orange Juice" }, [| ("Water", 80.0); ("Vitamins", 10.0); ("Orange", 10.0) |])
let laptop = ({ Id = 3; Name = "Laptop" }, [| ("Plastic", 80.0); ("Hard Disk", 10.0 ); ("RAM", 10.0) |])

// BIND
bind cupOfCoffe |> printfn "BIND: %A %s" <| System.Environment.NewLine

// RUN
run cupOfCoffeE |> printfn "RUN: %A %s" <| System.Environment.NewLine

// MAP
let convertToArray (prod:Product) =
    [|prod|]

let mapped = map convertToArray cupOfCoffeE

mapped |> printfn "MAP: %A %s" <| System.Environment.NewLine

// FLAT-MAP
let appendItem (formula:FormulaItem[]) =
    let newFormula = Array.append formula [| ("Convertir", 1.2) |]
    let encrypted = encryptFormula newFormula
    encrypted

let flattened = flatMap appendItem cupOfCoffeE

flattened |> printfn "FLAT: %A %s" <| System.Environment.NewLine

