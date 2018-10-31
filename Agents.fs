namespace myFsharpProject
module Agents =
    //https://blogs.msdn.microsoft.com/dsyme/2010/02/15/async-and-parallel-design-patterns-in-f-agents/

    type Agent<'T> = MailboxProcessor<'T>

    let iteratingAgent job =
        Agent.Start(fun inbox ->
            async { 
                while true do
                let! msg = inbox.Receive()
                do! job msg 
            })

    (*
    let agent1 = iteratingAgent (fun msg -> async { do printfn "got message '%s'" msg });;
    agent1.Post "hola";;
    *)

 