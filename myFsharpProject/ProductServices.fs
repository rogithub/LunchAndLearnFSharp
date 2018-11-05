namespace myFsharpProject
module Product =

    open myFsharpProject.BusinessObjects
    open myFsharpProject.EncryptionComponent

    type Services() =

        member this.GetOne(id: int) =
            let fromDb = Async.RunSynchronously ( Database.getById id )
            fromDb

        member this.GetMany(ids: int[]) =
            let mapped = Array.map (fun id -> Database.getById id) ids
            let result = mapped |> Async.Parallel |> Async.RunSynchronously
            result

        member this.Create(info: CreateNew) =
            let encrypted = encryptFormula info.Formula
            let shared = { SharedProduct.Id = info.Id; Name = info.Name; Formula = Async.RunSynchronously(encrypted) }
            shared

        member this.Create(info: CreateFrom) =
            let formulas =  info.Existing |> Array.map (fun e -> e.Formula)  |> decryptParallel |> Array.concat

            let newFormula = Array.append formulas info.Formula
            let encrypted = encryptFormula newFormula
            let shared = { SharedProduct.Id = info.Id; Name = info.Name; Formula = Async.RunSynchronously encrypted }
            shared

        member this.Query(info: QueryInfo) =
            let { Predicate = predicate; Formula = formula } = info
            let decrypted = decryptFormula formula |> Async.RunSynchronously
            let found = Array.filter predicate decrypted
            let result =  found.Length > 0
            result