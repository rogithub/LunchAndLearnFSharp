namespace myFsharpProject
module internal Monad =
    open myFsharpProject.Agents
    open myFsharpProject.Product

    let encryptFormula (formula:FormulaItem[]) =
        let reply = agent.PostAndReply(fun replyChannel -> Encrypt ( formula, replyChannel ))
        reply

    let decryptFormula (formula:string) =
        let reply = agent.PostAndReply(fun replyChannel -> Decrypt ( formula, replyChannel ))
        reply

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