module Encryption

open System
open System.Text

//https://stackoverflow.com/questions/13938137/convert-utf-8-to-base64-string

let encrypt (plainText:string) = 
    let bytes = Encoding.UTF8.GetBytes(plainText)
    let base64 = Convert.ToBase64String(bytes)
    base64

let decrypt (base64:string) =     
    let bytes = Convert.FromBase64String(base64)
    let str = Encoding.UTF8.GetString(bytes)
    str