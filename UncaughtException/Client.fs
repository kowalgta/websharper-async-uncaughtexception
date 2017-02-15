namespace UncaughtException

open WebSharper
open WebSharper.JavaScript
open WebSharper.JQuery
open WebSharper.UI.Next
open WebSharper.UI.Next.Client

[<JavaScript>]
module Client =    
    type IndexTemplate = Templating.Template<"index.html">

    let Main =
        JQuery.Of("#main").Empty().Ignore

        let viewWithException = 
            View.Const "result" 
            |> View.Map (fun x -> failwith "I've failed"; x)

        IndexTemplate.Main.Doc(Test = viewWithException)
        |> Doc.RunById "main"