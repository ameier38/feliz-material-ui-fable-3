module App

open Feliz
open Feliz.MaterialUI

type State = string option

type Msg = string option

let init() = None

let update (state:State) (msg:Msg) = state

let theme = Styles.createMuiTheme([
    theme.palette.primary Colors.blueGrey
])

let useStyles = Styles.makeStyles(fun styles theme ->
    {|
        root = styles.create [
            style.backgroundColor theme.palette.primary.dark
        ]
    |}
)

let themeTest = 
    React.functionComponent<unit>(fun props ->
        let c = useStyles()
        Html.div [
            prop.className c.root
            prop.text "Hello"
        ]
    )

let render state dispatch =
    Mui.themeProvider [
        themeProvider.theme theme
        themeProvider.children [
            themeTest()
        ]
    ]
