namespace myFsharpProject
module Product =
    open System

    type Component = { Name: string; Percent: float }
    type SharedProduct = {  Id: int; Name: string; Formula: string }
    type CreateNew = {  Id: int; Name: string; Formula: Component[] }
    type CreateFrom = {  Id: int; Name: string; Formula: Component[]; Existing: SharedProduct[] }
    type QueryInfo = { Predicate: Component -> bool; Formula: string }

