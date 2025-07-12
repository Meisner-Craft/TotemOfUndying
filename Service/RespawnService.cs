using LabApi.Features.Console;
using LabApi.Features.Wrappers;

namespace TotemOfUndying.Service
{
    internal class RespawnService
    {
        internal static void GiveRespawnEffects(Player player)
        {
            // Выдача эффектов
            player.EnableEffect<CustomPlayerEffects.Invigorated>(1, PluginMain.Configuration.Config.BringDuration);
            player.EnableEffect<CustomPlayerEffects.SpawnProtected>(1, PluginMain.Configuration.Config.ProtetDuration);

            player.ArtificialHealth = PluginMain.Configuration.Config.AHP; // AHP постоянное
            player.Health = PluginMain.Configuration.Config.HP; // HP
        }

        internal static bool PlayerRespawn(Player player)
        {

            for (int index = 0; index < ObjectsService.CustomItems.Count; index++)
            {
                // Получаем текущий кортеж
                var currentItem = ObjectsService.CustomItems[index]; 

                // Проверка, на наличие предмета в списке кастомных, и кол-во использований
                if (player.CurrentItem.Serial == ObjectsService.CustomItems[index].Item1 && ObjectsService.CustomItems[index].Item2 > 0)
                {
                    // Создаем новый кортеж отнимая использование
                    ObjectsService.CustomItems[index] = (currentItem.Item1, currentItem.Item2-1);

                    // Выдача эффектов
                    GiveRespawnEffects(player);

                    // Бродкаст об воскрешении
                    player.SendBroadcast("Воскрес!", 2);

                    // Деббаг вывод о воскрешении
                    if (PluginMain.Configuration.Config.DebugUndying)
                        Logger.Debug($"Воскрешения от {ObjectsService.CustomItems[index].Item1}, осталось {ObjectsService.CustomItems[index].Item2}");

                    // Отмена смерти
                    return false;
                }
            }

            // Смерть игрока
            return true;
        }
    }
}
