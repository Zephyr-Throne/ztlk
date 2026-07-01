namespace ZTLK

open Avalonia
open Avalonia.Controls.ApplicationLifetimes
open Avalonia.Themes.Fluent
open Avalonia.FuncUI.Hosts
open Avalonia.Controls
open Avalonia.FuncUI
open Avalonia.FuncUI.DSL
open Avalonia.Layout

module Main =
    let view () = 
        Component(fun ctx -> 
            let state = ctx.useState 0

            Grid.create [
                Grid.rowDefinitions "auto,*,auto"
                Grid.columnDefinitions "auto,*,auto"
                
                Grid.children [
                    Menu.create [
                        Grid.row 0
                        Grid.column 0 
                         
                        Menu.viewItems [
                            MenuItem.create [
                                MenuItem.header "File"
                                MenuItem.viewItems [
                                    MenuItem.create [
                                        MenuItem.header "Open"
                                    ]

                                    MenuItem.create [
                                        MenuItem.header "Close"
                                    ]

                                    MenuItem.create [
                                        MenuItem.header "Exit"
                                    ]
                                ]
                            ]

                            MenuItem.create [
                                MenuItem.header "Edit"
                                MenuItem.viewItems [
                                    MenuItem.create [
                                        MenuItem.header "Select All"
                                    ]

                                    MenuItem.create [
                                        MenuItem.header "Undo"
                                    ]

                                    MenuItem.create [
                                        MenuItem.header "Redo"
                                    ]
                                ]
                            ]

                            MenuItem.create [
                                MenuItem.header "View"
                                MenuItem.viewItems [
                                    MenuItem.create [
                                        MenuItem.header "Pan"
                                    ]

                                    MenuItem.create [
                                        MenuItem.header "Zoom"
                                    ]
                                ]
                            ]
                        ]
                    ]
                ] 
            ] 
        )

type MainWindow() =
    inherit HostWindow()
    do
        base.Title <- "ZTLK"
        base.Content <- Main.view ()

type App() = 
    inherit Application()
    
    override this.Initialize (): unit = 
        this.Styles.Add (FluentTheme())
        this.RequestedThemeVariant <- Styling.ThemeVariant.Dark
        base.Initialize()

    override this.OnFrameworkInitializationCompleted (): unit = 
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime as desktopLifetime ->
            desktopLifetime.MainWindow <- MainWindow()
        | _ -> ()

        base.OnFrameworkInitializationCompleted()

module Program =

    [<EntryPoint>]
    let main(args: string[]) =
        AppBuilder
            .Configure<App>()
            .UsePlatformDetect()
            .UseSkia()
            .StartWithClassicDesktopLifetime(args)