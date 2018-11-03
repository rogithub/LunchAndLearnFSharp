// Learn more about F# at http://fsharp.org

open System
open FConsole

[<EntryPoint>]
let main argv =
    RaceConditionTest.test
    
    printfn "Hello World from F#!"
    0 // return an integer exit code
