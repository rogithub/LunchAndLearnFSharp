namespace myFsharpProject
module Agents =
    //https://blogs.msdn.microsoft.com/dsyme/2010/02/15/async-and-parallel-design-patterns-in-f-agents/

    open myFsharpProject.Serialization
    open myFsharpProject.Encryption
    open myFsharpProject.Product

    type Message =
        | Encrypt of FormulaItem[] * AsyncReplyChannel<string>
        | Decrypt of string * AsyncReplyChannel<FormulaItem[]>

    let toEncryptedString (formula:FormulaItem[]) =
        let encryptedFormula = formula |> serializeJson |> encryptText
        encryptedFormula

    let toDecryptedArray (formula:string) =
        let decryptedFormula = decryptText formula |> deserialiseJson<FormulaItem[]>
        decryptedFormula

    
    let agent = MailboxProcessor<Message>.Start(fun inbox ->
        async { 
            while true do
                let! msg = inbox.Receive()
                match msg with
                    | Encrypt (formula, channel) -> channel.Reply <| toEncryptedString formula
                    | Decrypt (formula, channel) -> channel.Reply <| toDecryptedArray formula
        }
    )


// 1. Encrypt an array of prods.
// 2. Bind formulation of existing product with one
//    or more existing products.
// 3. Query encrypted formulations for properties.

 