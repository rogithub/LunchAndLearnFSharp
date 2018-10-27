module XmlProdSerializer
open Product
open Serialization
open Encryption


/// XmlProdSerializer monad: receives a product and returns a string serialized product.
type ProdSerializer = 
    ProdSerializer of (Product -> string)

let toXml serializer = 
    let toXmlString (p: Product) =         
        let serializeProd (prod:Product) = serializeXml prod    
        let serializeFormula (f:FormulaItem[]) = serializeJson f |> encrypt

        let newProd = { p with Formulation=[||]; FormulationEncrypted = serializeFormula p.Formulation }
        let xml = serializeProd newProd
        xml
    ProdSerializer toXmlString

let runSerialization (ProdSerializer f) product = f product
let mapSerialization f prodSerializer =
    let transform product =
        let strSerializedProd = runSerialization prodSerializer product
        let result = f strSerializedProd
        result
    ProdSerializer transform


/// ProdDeserializer monad: receives a string and returns a product.
type ProdDeserializer = 
    ProdDeserializer of (string -> Product)

let toProduct serializer = 
    let fromXmlString (prodStr: string) =
        let p = deserializeXml<Product> prodStr   
        let formulation = decrypt p.FormulationEncrypted |> deserialiseJson<FormulaItem[]>

        let newProd = { p with Formulation=formulation; FormulationEncrypted = "" }
        newProd

    ProdDeserializer fromXmlString    


let runDeserialization (ProdDeserializer f) strProduct = f strProduct
let mapDeserialization f prodDeserializer =
    let transform strProduct =
        let product = runDeserialization prodDeserializer strProduct
        let result = f product
        result
    ProdDeserializer transform



