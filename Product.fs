module Product
open Serialization
open Encryption

[<CLIMutable>]
type FormulaItem = { Name: string; Percent: float; }

type Product =
    | Decrypted of Name: string * Formulation: FormulaItem[]
    | Encrypted of Name: string * Formulation: string


let toggleEncryption product =
    match product with
    | Decrypted (name, formulation) -> 
        let data = formulation |> serializeJson |> encrypt
        Encrypted(name, data)

    | Encrypted (name, formulation) -> 
        let data = decrypt formulation |> deserialiseJson<FormulaItem[]>
        Decrypted(name, data)    

    
