namespace myFsharpProject
module Services =

    open myFsharpProject.Product
    open myFsharpProject.EncryptionAgent
    open myFsharpProject.Database

    type Message =
        | GetFromDb of int * AsyncReplyChannel<SharedProduct>
        | Create of CreateNew * AsyncReplyChannel<SharedProduct>
        | Merge of CreateFrom * AsyncReplyChannel<SharedProduct>
        | Query of QueryInfo * AsyncReplyChannel<bool>

    type JobProcessor() =

        member this.mailbox = MailboxProcessor<Message>.Start(fun inbox ->

            let rec loop () = async {
                let! msg = inbox.Receive()
                match msg with
                    | GetFromDb (id, channel) ->
                        let fromDb = Database.getById(id)
                        channel.Reply fromDb

                    | Create (newInfo, channel) ->
                        let encrypted = encryptFormula newInfo.Formula
                        let shared = { SharedProduct.Id = newInfo.Id; Name = newInfo.Name; Formula = encrypted }
                        channel.Reply shared

                    | Merge (fromInfo, channel) ->
                        let formulas = fromInfo.Existing |> Array.collect (fun e -> decryptFormula e.Formula)
                        let newFormula = Array.append formulas fromInfo.Formula
                        let encrypted = encryptFormula newFormula
                        let shared = { SharedProduct.Id = fromInfo.Id; Name = fromInfo.Name; Formula = encrypted }
                        channel.Reply shared

                    | Query (queryInfo, channel) ->
                        let { Predicate = predicate; Formula = formula } = queryInfo
                        let decrypted = decryptFormula formula
                        let found = Array.filter predicate decrypted
                        let result =  found.Length > 0
                        channel.Reply result
            }
            loop ()
        )

        member this.GetOne(id: int) =
            this.mailbox.PostAndReply( fun replyChannel -> ( GetFromDb(id, replyChannel) ))

        member this.Create(info: CreateNew) =
            this.mailbox.PostAndReply( fun replyChannel -> ( Create(info, replyChannel) ))

        member this.Create(info: CreateFrom) =
            this.mailbox.PostAndReply( fun replyChannel -> ( Merge(info, replyChannel) ))

        member this.Query(info: QueryInfo) =
            this.mailbox.PostAndReply( fun replyChannel -> ( Query(info, replyChannel) ))