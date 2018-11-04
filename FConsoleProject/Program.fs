// Learn more about F# at http://fsharp.org

open System
open FConsole

[<EntryPoint>]
let main argv =
    //let list = RaceConditionTest.test 4 1000
    Monads.test()
    //JobProcessor.MyJobProcessor.test 1000000
    0 // return an integer exit code
