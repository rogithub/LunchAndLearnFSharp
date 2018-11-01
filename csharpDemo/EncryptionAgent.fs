namespace myFsharpProject
module internal EncryptionAgent =
    //https://blogs.msdn.microsoft.com/dsyme/2010/02/15/async-and-parallel-design-patterns-in-f-agents/

    open myFsharpProject.Serialization
    open myFsharpProject.Encryption
    open myFsharpProject.Product

    type Message =
        | Encrypt of Component[] * AsyncReplyChannel<string>
        | Decrypt of string * AsyncReplyChannel<Component[]>

    let agent = MailboxProcessor<Message>.Start(fun inbox ->
        async {
            while true do
                let! msg = inbox.Receive()
                match msg with
                    | Encrypt (formula, channel) ->
                        let encryptedFormula = formula |> serializeJson |> encryptText
                        channel.Reply encryptedFormula

                    | Decrypt (formula, channel) ->
                        let decryptedFormula = decryptText formula |> deserialiseJson<Component[]>
                        channel.Reply decryptedFormula
        }
    )

    let encryptFormula (formula:Component[]) =
        let reply = agent.PostAndReply(fun replyChannel -> Encrypt ( formula, replyChannel ))
        reply

    let decryptFormula (formula:string) =
        let reply = agent.PostAndReply(fun replyChannel -> Decrypt ( formula, replyChannel ))
        reply