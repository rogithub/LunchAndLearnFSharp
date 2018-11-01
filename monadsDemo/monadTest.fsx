#r "System.Runtime.Serialization.dll"
#load "Serialization.fs"
#load "Encryption.fs"
#load "Product.fs"
#load "Database.fs"
#load "Monad.fs"
open System

open myFsharpProject.Product
open myFsharpProject.Database
open myFsharpProject.Monad

let cupOfCoffe = getById 0
let orangeJuice = getById 1
let laptop = getById 2

// BIND
let returnM prod = bind (prod, prod.Formula)
let lifted = returnM cupOfCoffe

// RUN
let runM elevated =
    let prod, formula = run elevated
    let decrypted = decryptFormula formula
    prod, decrypted

runM lifted

// MAP
let convertToString (prod) =
    prod |> sprintf "Product %A"

let mapped = map convertToString lifted

// FLAT-MAP
let appendItem (formula:string) =
    let decrypted = decryptFormula formula
    let newFormula = Array.append decrypted [| { Name= "Appended"; Percent = 10.10; } |]
    let encrypted = encryptFormula newFormula
    encrypted

let flattened = flatMap appendItem lifted