#r "System.Runtime.Serialization.dll"
#load "Serialization.fs"
#load "Encryption.fs"
#load "Product.fs"
#load "ProductMonad.fs"

open System
open Product
open ProductMonad

let item1 = { Name = "Water"; Percent = 80.0 }
let item2 = { Name = "Sugar"; Percent = 10.0 }
let item3 = { Name = "Coffee"; Percent = 10.0 }
let cupOfCoffe = Decrypted("Cup of Coffe", [|item1; item2; item3|])

let encrypted = toggleEncryption cupOfCoffe

let decripted1 = toggleEncryption encrypted

decripted1 = cupOfCoffe


