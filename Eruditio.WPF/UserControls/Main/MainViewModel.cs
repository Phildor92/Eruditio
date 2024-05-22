using System.Reactive;
using System.Reactive.Linq;
using System.Reflection;
using Eruditio.WPF.UserControls.Home;
using ReactiveUI;
using Splat;

namespace Eruditio.WPF.UserControls.Main;

public class MainViewModel : ReactiveObject, IScreen
{
    public RoutingState Router { get; }
    public ReactiveCommand<Unit, IRoutableViewModel> GoNext { get; }
    public ReactiveCommand<Unit, IRoutableViewModel> GoBack { get; }
    
    public MainViewModel()
    {
        Router = new();
        
        Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetCallingAssembly());

        GoNext = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new HomeViewModel()));

        var canGoBack = this.WhenAnyValue(x => x.Router.NavigationStack.Count).Select(count => count > 0);
        GoBack = ReactiveCommand.CreateFromObservable(() => Router.NavigateBack.Execute(Unit.Default), canGoBack);
    }

}