namespace myFsharpProject
module Product =

    [<CLIMutable>]
    type FormulaItem = string * float

    type Product = { Id: int; Name: string; }

    //https://hackernoon.com/a-monad-writer-for-f-26aa987e4a3a
    type Encryptor<'prod, 'formula> = FEncrypt of 'prod * 'formula