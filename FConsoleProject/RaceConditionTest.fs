namespace FConsole
module RaceConditionTest = 
    open System
    open System.Diagnostics
    open System.Threading

    /// Add numbers to list
    let addUpTo count (sleep:int) =
        let wait value = async { 
            Thread.Sleep sleep
            return value
        }
        let list = seq { for i in 0 .. (count - 1) -> wait i } |> Async.Parallel |> Async.RunSynchronously |> List.ofSeq
        printfn "List length: %d Expected: %d" list.Length count
        list

    let (>>=) m f = 
        let cores = Environment.ProcessorCount;
        let threadId = Thread.CurrentThread.ManagedThreadId
        let watch = new Stopwatch()
        watch.Start()
        let result = f m
        printfn "Cores: %d, ThreadId: %d, Timing: %dms" cores threadId watch.ElapsedMilliseconds
        result
        
    let test count sleep =
        sleep >>= addUpTo count

    