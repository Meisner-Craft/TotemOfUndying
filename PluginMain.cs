using LabApi.Events.CustomHandlers;
using LabApi.Loader.Features.Plugins;


namespace TotemOfUndying
{
    public class PluginMain:Plugin<Config>
    {
        public override string Name { get; } = "TotemOfUndying";
        public override string Description { get; } = "Meisner's plugin";
        public override string Author { get; } = "Meisner";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredApiVersion { get; } = new Version();

        public static PluginMain Configuration { get; set; } = null;
 
        public Handlers Startup { get; set; }
        
        public override void Enable()
        {
            Configuration = this;
            Startup = new Handlers();

            CustomHandlersManager.RegisterEventsHandler(Startup);
        }
        
        public override void Disable()
        {
            Configuration = null;
            CustomHandlersManager.UnregisterEventsHandler(Startup);
        } 
    }
}