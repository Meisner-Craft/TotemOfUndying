using CommandSystem;
using LabApi.Features.Wrappers;
using TotemOfUndying.Service;

[CommandHandler(typeof(RemoteAdminCommandHandler))]

public class Commands : CommandSystem.ICommand
{
    public string Command { get; } = "totem_add";
    public string[] Aliases { get; } = { };
    public string Description { get; } = "Add you totem";

    bool CommandSystem.ICommand.Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        Player player = Player.Get(sender);

        CustomItems.GiveCustomItem(player);

        // Вывод в консоль
        response = $"Give totem to {player.Nickname}";

        // Завершаем метод
        return true;
    }
}
