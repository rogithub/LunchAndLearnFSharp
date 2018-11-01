namespace myFsharpProject
module Product =
    open System
    open Encryption
    open Serialization

    type Component = { Name: string; Percent: float }
    type SharedProduct = {  Id: int; Name: string; Formula: string }
    
    //https://hackernoon.com/a-monad-writer-for-f-26aa987e4a3a
    type Encryptor<'prod, 'formula> = FEncrypt of 'prod * 'formula

    let encryptFormula formula = 
        let encryptedFormula = formula |> serializeJson |> encryptText
        encryptedFormula

    let decryptFormula formula =
        let decryptedFormula = decryptText formula |> deserialiseJson<Component[]>
        decryptedFormula