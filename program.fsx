#r "System.Runtime.Serialization.dll"
#load "Serialization.fs"
#load "Encryption.fs"
#load "Product.fs"
#load "Monad.fs"
#load "Database.fs"
open System
open myFsharpProject.Serialization
open myFsharpProject.Encryption
open myFsharpProject.Product
open myFsharpProject.Monad
open myFsharpProject.Database

let cupOfCoffeE = getById 1;
cupOfCoffeE |> printfn "BIND: %A %s" <| Environment.NewLine


