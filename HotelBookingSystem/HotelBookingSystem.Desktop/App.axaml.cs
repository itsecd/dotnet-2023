using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Shapes;
using Avalonia.Markup.Xaml;
using HotelBookingSystem.Desktop.ViewModels;
using HotelBookingSystem.Desktop.Views;
using HotelBookingSystem.Server.Dto;
using Splat;
using System;

namespace HotelBookingSystem.Desktop;
public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HotelGetDto, HotelViewModel>();
                cfg.CreateMap<HotelViewModel, HotelPostDto>();

                cfg.CreateMap<RoomGetDto, RoomViewModel>();
                cfg.CreateMap<RoomViewModel, RoomPostDto>();

                cfg.CreateMap<LodgerGetDto, LodgerViewModel>();
                cfg.CreateMap<LodgerViewModel, LodgerPostDto>();

                cfg.CreateMap<BookedRoomsGetDto, BookedRoomsViewModel>();
                cfg.CreateMap<BookedRoomsViewModel, BookedRoomsPostDto>();
            });

            try
            {
                config.AssertConfigurationIsValid();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            Locator.CurrentMutable.RegisterConstant(new ApiWrapper());
            Locator.CurrentMutable.RegisterConstant(config.CreateMapper(), typeof(IMapper));

            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}