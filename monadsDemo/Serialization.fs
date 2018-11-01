namespace myFsharpProject
module internal Serialization =
    open System.Runtime.Serialization
    open System.Runtime.Serialization.Json
    open System.IO

    let toString = System.Text.Encoding.ASCII.GetString
    let toBytes (x : string) = System.Text.Encoding.ASCII.GetBytes x

    let serializeJson<'a> (x : 'a) =
        let jsonSerializer = new DataContractJsonSerializer(typedefof<'a>)

        use stream = new MemoryStream()
        jsonSerializer.WriteObject(stream, x)
        toString <| stream.ToArray()

    let deserialiseJson<'a> (json : string) =
        let jsonSerializer = new DataContractJsonSerializer(typedefof<'a>)

        use stream = new MemoryStream(toBytes json)
        jsonSerializer.ReadObject(stream) :?> 'a
