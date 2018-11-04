namespace FConsole
module JobProcessor =     
    open System
    open System.Diagnostics
    open System.Threading    

    type MyJobProcessor () =         

        static let myJobProcessor = MailboxProcessor.Start(fun inbox ->
            let rec loop n =
                async {                     
                    let! msg = inbox.Receive()
                    
                    //Process job
                    printfn "%s | Job index %d: thread %d" msg n Thread.CurrentThread.ManagedThreadId
                    
                    //End Process

                    return! loop(n+1) 
                }
            loop 0)
        
        static member test count =
            let rec sendMessages index jobs =
                if index = count then jobs
                else                    
                    let msg = sprintf "Message index %d: thread %d" index Thread.CurrentThread.ManagedThreadId
                    let job = async { myJobProcessor.Post(msg) }
                    let newList = job::jobs
                    sendMessages (index+1) newList
            
            let jobs = sendMessages 0 []
            jobs |> Async.Parallel |> Async.RunSynchronously |> ignore
            printfn "Done sending %d messages %s" count Environment.NewLine
            