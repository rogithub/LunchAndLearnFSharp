module Product
open Serialization
open Encryption

[<CLIMutable>]
type FormulaItem = { Name: string; Percent: float; }

[<CLIMutable>] 
type Product = { Name: string; Formulation: FormulaItem[]; FormulationEncrypted: string; }


let toString (p: Product) =         
    let serializeProd (prod:Product) = serializeXml prod    
    let serializeFormula (f:FormulaItem[]) = serializeJson f |> encrypt

    let newProd = { p with Formulation=[||]; FormulationEncrypted = serializeFormula p.Formulation }
    let xml = serializeProd newProd
    xml

let fromString (prodStr: string) =
    let p = deserializeXml<Product> prodStr   
    let formulation = decrypt p.FormulationEncrypted |> deserialiseJson<FormulaItem[]>

    let newProd = { p with Formulation=formulation; FormulationEncrypted = "" }
    newProd