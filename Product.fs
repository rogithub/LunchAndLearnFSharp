module Product
open Serialization
open Encryption

[<CLIMutable>]
type FormulaItem = string * float

type Product = { Id: int; Name: string; }

type Encryptor<'prod, 'formula> = FEncryptor of 'prod * 'formula

let bind = function 
    | (prod, formula) -> FEncryptor(prod, formula)

let run = function
    | FEncryptor(prod, formula) -> (prod, formula)

let map fx = function
    | FEncryptor(prod, formula) -> FEncryptor(fx prod, formula)

let flatMap fx = function
    | FEncryptor(prod, formula) -> 
        let (prod, new_formula) = run (fx prod)
        FEncryptor(prod, Array.append formula new_formula)


let encryptFormula (formula:FormulaItem[]) =
    let encryptedFormula = formula |> serializeJson |> encrypt
    encryptedFormula

let decryptFormula (formula:string) =
    let decryptedFormula = decrypt formula |> deserialiseJson<FormulaItem[]>
    decryptedFormula

let lift (prod, formula) = bind (prod, encryptFormula(formula))
