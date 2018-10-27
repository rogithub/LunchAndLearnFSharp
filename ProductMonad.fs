module ProductMonad
open Product

type ProductMonad<'a> = 
    ProdMonad of (Product -> 'a * Product)

let runP (ProdMonad f) product = f product

let mapP f m =
    let transform product =
        let serializedProd, newProd = runP m product
        let result = f serializedProd
        (result, newProd)
    ProdMonad transform

let returnP m =
    let elevate product = 
        (m, product)
    ProdMonad elevate

let bindP f m =
    let transform product = 
        let serializedProd, newProduct = runP m product
        let newProdSerializer = f serializedProd 
        let newSerializedProd, newProduct2 = runP newProdSerializer newProduct 
        (newSerializedProd, newProduct2)
    ProdMonad transform

let applyP mf mx =
    let transform product = 
        let f,newProduct  = runP mf product 
        let x,newProduct2 = runP mx newProduct  
        let y = f x
        y, newProduct2    
    ProdMonad transform


 

