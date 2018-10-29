module Product
open Serialization
open Encryption

[<CLIMutable>]
type FormulaItem = string * float

type Product = { Id: int; Name: string; Formulation: FormulaItem[]; FormulaEncrypted: string }

let encryptFormulation (formulation: FormulaItem[]) =
    let encryptedFormula = formulation |> serializeJson |> encrypt
    encryptedFormula
    

let decryptFormulation (formulation: string) =
    let decryptedFormula = decrypt formulation |> deserialiseJson<FormulaItem[]>
    decryptedFormula

