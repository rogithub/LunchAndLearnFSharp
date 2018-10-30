module Product
open Serialization
open Encryption

[<CLIMutable>]
type FormulaItem = string * float

type Product = { Id: int; Name: string; }

type Encryptor<'prod, 'formula> = FEncrypt of 'prod * 'formula

let bind = function 
    | (prod, formula) -> FEncrypt(prod, formula)

let run = function
    | FEncrypt(prod, formula) -> (prod, formula)

let map fx = function
    | FEncrypt(prod, formula) -> FEncrypt(fx prod, formula)

let flatMap fx = function
    | FEncrypt(prod, formula) -> 
        let (prod, new_formula) = run (fx prod)
        FEncrypt(prod, Array.append formula new_formula)


let encryptFormula (formula:FormulaItem[]) =
    let encryptedFormula = formula |> serializeJson |> encryptText
    encryptedFormula

let decryptFormula (formula:string) =
    let decryptedFormula = decryptText formula |> deserialiseJson<FormulaItem[]>
    decryptedFormula

let lift (prod, formula) = bind (prod, encryptFormula(formula))
