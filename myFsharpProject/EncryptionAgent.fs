namespace myFsharpProject
module internal EncryptionAgent =
    //https://blogs.msdn.microsoft.com/dsyme/2010/02/15/async-and-parallel-design-patterns-in-f-agents/

    open myFsharpProject.Serialization
    open myFsharpProject.Encryption
    open myFsharpProject.Product


    let encryptFormula (formula:Component[]) = async {
        let encryptedFormula = formula |> serializeJson |> encryptText
        return encryptedFormula
    }

    let decryptFormula (formula:string) = async {
        let decryptedFormula = decryptText formula |> deserialiseJson<Component[]>
        return decryptedFormula
    }

    let encryptParallel (formula:Component[][]) =
        let mapped = Array.map (fun f -> encryptFormula  f) formula |> Async.Parallel |> Async.RunSynchronously
        mapped


    let decryptParallel (formula:string[]) =
        let mapped = Array.map (fun f -> decryptFormula  f ) formula |> Async.Parallel |> Async.RunSynchronously
        mapped
