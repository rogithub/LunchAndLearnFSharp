namespace myFsharpProject
module internal Monad =
    open myFsharpProject.Product

    let bind = function
        | (prod, formula) -> FEncrypt(prod, formula)

    let run = function
        | FEncrypt(prod, formula) -> (prod, formula)

    let map f = function
         | FEncrypt(prod, formula) ->
            let mappedProd = f (prod)
            FEncrypt(mappedProd, formula)

    let flatMap fx = function
        | FEncrypt(prod, formula) ->
            let prod1, decrypted1 = run <| FEncrypt(prod, formula)
            let elevated = fx decrypted1
            FEncrypt(prod1, elevated)