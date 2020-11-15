module App

open Feliz
open Feliz.MaterialUI

let theme = Styles.createMuiTheme([
    theme.palette.primary Colors.blueGrey
])

let useStyles = Styles.makeStyles(fun styles theme ->
    {|
        root = styles.create [
            style.backgroundColor theme.palette.primary.dark
            // style.backgroundColor.aqua
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

let render () =
    Mui.themeProvider [
        themeProvider.theme theme
        themeProvider.children [
            themeTest()
        ]
    ]
