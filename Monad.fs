namespace myFsharpProject
module internal Monad =
    open Product
    open Serialization
    open Encryption

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
            let prod1, decrypted1 = run <| FEncrypt(prod, formula)
            let elevated = fx decrypted1
            FEncrypt(prod1, elevated)