namespace FConsole
module RaceConditionTest = 
    open System
    open System.Diagnostics
    open System.Threading

    /// Add numbers to list
    let addUpTo count =
        let wait value = async { 
            Thread.Sleep 1000
            return value
        }
        seq { for i in 0 .. (count - 1) -> wait i } |> List.ofSeq |> Async.Parallel |> Async.RunSynchronously

    let test () = 
        let watch = new Stopwatch()
        watch.Start()
        let count = Environment.ProcessorCount;
        //let count = 1000000;

        let list = addUpTo count 
        printfn "The total count should be %d. The list count is %d. It took %d ms." count list.Length watch.ElapsedMilliseconds
        