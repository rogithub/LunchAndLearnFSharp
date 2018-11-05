namespace myFsharpProject
module internal EncryptionComponent =    

    open myFsharpProject.Serialization
    open myFsharpProject.Encryption
    open myFsharpProject.BusinessObjects


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
