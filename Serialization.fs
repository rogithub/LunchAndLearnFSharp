module Serialization
open System.Runtime.Serialization
open System.Runtime.Serialization.Json
open System.IO
open System.Text
open System.Xml
open System.Xml.Serialization

let toString = System.Text.Encoding.ASCII.GetString
let toBytes (x : string) = System.Text.Encoding.ASCII.GetBytes x

let serializeXml<'a> (x : 'a) =
    let xmlSerializer = new DataContractSerializer(typedefof<'a>)

    use stream = new MemoryStream()
    xmlSerializer.WriteObject(stream, x)
    toString <| stream.ToArray()

let deserializeXml<'a> (xml : string) =
    let xmlSerializer = new DataContractSerializer(typedefof<'a>)

    use stream = new MemoryStream(toBytes xml)
    xmlSerializer.ReadObject(stream) :?> 'a

let serializeJson<'a> (x : 'a) = 
    let jsonSerializer = new DataContractJsonSerializer(typedefof<'a>)

    use stream = new MemoryStream()
    jsonSerializer.WriteObject(stream, x)
    toString <| stream.ToArray()

let deserialiseJson<'a> (json : string) =
    let jsonSerializer = new DataContractJsonSerializer(typedefof<'a>)

    use stream = new MemoryStream(toBytes json)
    jsonSerializer.ReadObject(stream) :?> 'a
