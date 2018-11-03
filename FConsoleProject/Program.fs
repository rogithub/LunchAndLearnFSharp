// Learn more about F# at http://fsharp.org

open System
open FConsole

[<EntryPoint>]
let main argv =
    //let list = RaceConditionTest.test 4 1000
    Monads.test()
    0 // return an integer exit code
