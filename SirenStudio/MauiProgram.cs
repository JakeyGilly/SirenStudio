using Plugin.Maui.Audio;
using SirenStudio.ViewModels;

namespace SirenStudio;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .AddAudio(
                playbackOptions =>
                {
#if IOS || MACCATALYST
					playbackOptions.Category = AVFoundation.AVAudioSessionCategory.Playback;
#endif
                },
                recordingOptions =>
                {
#if IOS || MACCATALYST
					recordingOptions.Category = AVFoundation.AVAudioSessionCategory.Record;
					recordingOptions.Mode = AVFoundation.AVAudioSessionMode.Default;
					recordingOptions.CategoryOptions = AVFoundation.AVAudioSessionCategoryOptions.MixWithOthers;
#endif
                })
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        
        RegisterPageRoute<MusicPlayerPage, MusicPlayerPageViewModel>(Routes.MusicPlayer.RouteName, builder.Services);

        return builder.Build();
    }

    static void RegisterPageRoute<TPage, TPageViewModel>(
        string route,
        IServiceCollection services)
        where TPage : ContentPage
        where TPageViewModel : BaseViewModel
    {
        Routing.RegisterRoute(route, typeof(TPage));

        services.AddTransient(typeof(TPage));
        services.AddTransient(typeof(TPageViewModel));
    }
}