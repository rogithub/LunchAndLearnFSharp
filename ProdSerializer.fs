module ProdSerializer
open Product
open Serialization
open Encryption

let toXmlString (p: Product) =         
    let serializeProd (prod:Product) = serializeXml prod    
    let serializeFormula (f:FormulaItem[]) = serializeJson f |> encrypt

    let newProd = { p with Formulation=[||]; FormulationEncrypted = serializeFormula p.Formulation }
    let xml = serializeProd newProd
    xml

let fromXmlString (prodStr: string) =
    let p = deserializeXml<Product> prodStr   
    let formulation = decrypt p.FormulationEncrypted |> deserialiseJson<FormulaItem[]>

    let newProd = { p with Formulation=formulation; FormulationEncrypted = "" }
    newProd

/// ProductSerializer monad: receives a product and returns a string serialized product.
type ProductSerializer = 
    ProdSerializer of (Product -> string)

let runSerialization (ProdSerializer f) product = f product

let mapSerialization f prodSerializer =
    let transform product =
        let strSerializedProd = runSerialization prodSerializer product
        let result = f strSerializedProd
        result
    ProdSerializer transform

let returnXmlSerialization product =
    ProdSerializer toXmlString


/// ProductDeserializer monad: receives a string and returns a product.
type ProductDeserializer = 
    ProdDeserializer of (string -> Product)

let runDeserialization (ProdDeserializer f) strProduct = f strProduct

let mapDeserialization f prodDeserializer =
    let transform strProduct =
        let product = runDeserialization prodDeserializer strProduct
        let result = f product
        result
    ProdDeserializer transform

let returnXmlDeserialization xmlProduct =
    ProdDeserializer fromXmlString

