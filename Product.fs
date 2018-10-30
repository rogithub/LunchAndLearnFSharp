module Product
open Serialization
open Encryption

[<CLIMutable>]
type FormulaItem = string * float

type Product = { Id: int; Name: string; }

//https://hackernoon.com/a-monad-writer-for-f-26aa987e4a3a
type Encryptor<'prod, 'formula> = FEncrypt of 'prod * 'formula

let encryptFormula (formula:FormulaItem[]) =
    let encryptedFormula = formula |> serializeJson |> encryptText
    encryptedFormula

let decryptFormula (formula:string) =
    let decryptedFormula = decryptText formula |> deserialiseJson<FormulaItem[]>
    decryptedFormula

let bind = function
    | (prod, formula) -> FEncrypt(prod, encryptFormula formula)

let run = function
    | FEncrypt(prod, formula) -> (prod, decryptFormula formula)

let map f = function
    | FEncrypt(prod, formula) ->
        let mappedProd = f (prod)
        FEncrypt(mappedProd, formula)

let flatMap fx = function
    | FEncrypt(prod, formula) ->
        let prod1, decrypted = run <| FEncrypt(prod, formula)
        let encrypted = fx decrypted
        FEncrypt(prod, encrypted)