#load ".fake/build.fsx/intellisense.fsx"
open Fake.Core
open Fake.DotNet
open Fake.IO
open Fake.IO.Globbing.Operators
open BlackFox.Fake

let fable = DotNet.exec id "fable"

let clean = BuildTask.create "Clean" [] {
    !! "src/**/bin"
    ++ "src/**/obj"
    ++ "out"
    |> Shell.cleanDirs 
}

BuildTask.create "Restore" [clean] {
    !! "src/**/*.*proj"
    |> Seq.iter (DotNet.restore id)
}

BuildTask.create "Start" [] {
    fable "watch src/App --outDir out --run webpack-dev-server" |> ignore
}

BuildTask.create "Build" [] {
    fable "watch src/App --outDir out --run webpack" |> ignore
}

let _default = BuildTask.createEmpty "Default" []

BuildTask.runOrDefault _default
