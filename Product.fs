module Product
open Serialization
open Encryption

[<CLIMutable>]
type FormulaItem = string * float

type Encrypted = { Id: int; Name: string; Formulation: string }
type Decrypted = { Id: int; Name: string; Formulation: FormulaItem[] }

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


let encryptProd (prod:Decrypted) =
    let encryptedFormula = prod.Formulation |> serializeJson |> encrypt
    { Encrypted.Id = prod.Id; Name = prod.Name; Formulation = encryptedFormula }

let decryptProd (prod:Encrypted) =
    let decryptedFormula = decrypt prod.Formulation |> deserialiseJson<FormulaItem[]>
    { Decrypted.Id = prod.Id; Name = prod.Name; Formulation = decryptedFormula } 

