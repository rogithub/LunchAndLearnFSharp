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
                    
                    if (n%100000 = 0) then
                        printfn "%s | Job index %d: thread %d" msg n Thread.CurrentThread.ManagedThreadId                    

                    return! loop(n+1)           
                }
            loop 0)
        
        static member test count =
            let rec sendMessages index =
                if index = count then index
                else                    
                    let msg = sprintf "Message index %d: thread %d" index Thread.CurrentThread.ManagedThreadId
                    myJobProcessor.Post(msg)
                    sendMessages (index+1)
            
            let jobsCount = sendMessages 0            
            printfn ">> Done sending %d messages %s" jobsCount Environment.NewLine
            