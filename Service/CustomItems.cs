using LabApi.Events.Arguments.ServerEvents;
using LabApi.Features.Console;
using LabApi.Features.Wrappers;

namespace TotemOfUndying.Service
{
    internal class CustomItems
    {
        internal static void SortItemOnSpawn(ItemSpawnedEventArgs item)
        {
            // Дебаг всех предметов
            if (PluginMain.Configuration.Config.DebugAllItem)
            {
                Logger.Debug($"[СПАВН ПРЕДМЕТА] " +
                $"Serial: {item.Pickup.Serial}, " +
                $"Type: {item.Pickup.Type}, ");
            }

            // Отбираем только нужные предметы
            if (item.Pickup.Type.Equals(PluginMain.Configuration.Config.TotemItem))
            {
                // Вставляем предмет в массив
                ObjectsService.AllItems.Add((item.Pickup.Serial));

                // Вывод отобранных предметов
                if (PluginMain.Configuration.Config.DebugCustomItem)
                {
                    Logger.Debug($"[ДОБАВЛЕНИЕ] " +
                    $"Serial: {item.Pickup.Serial}, " +
                    $"Type: {item.Pickup.Type}, " +
                    $"Spawn in {item.Pickup.Room}");
                }
            }
        }

        internal static void AddCustomItem()
        {
            // Перемешивание массива
            ObjectsService.AllItems = ObjectsService.AllItems.OrderBy(x => ObjectsService.Rand.Next()).ToList();

            // Проверка перед очисткой CustomItems
            if (ObjectsService.CustomItems.Count > 0)
            {
                // Логирование об очистке
                Logger.Debug("Очистка старых тотемов");
            }

            // Очистка массива CustomItems
            ObjectsService.CustomItems.Clear();

            // Берем первые n элементов из перемешанного списка и добавляем их в CustomItems
            for (int i = 0; i < PluginMain.Configuration.Config.TotemCount; i++)
            {
                // Вставляем Серийник, и Кол-во использований
                ObjectsService.CustomItems.Add((ObjectsService.AllItems[i], PluginMain.Configuration.Config.SevesCount));
            }

            // Вывод зарандомленных предметов
            foreach (var CustomItem in ObjectsService.CustomItems)
            {
                if (PluginMain.Configuration.Config.DebugUndying)
                    Logger.Debug($"Рандомно выпал предмет с серийником {CustomItem.Item1}, осталось {CustomItem.Item2}");
            }
        }

        internal static void TakeCustomItem(Item? item, Player player)
        {
            // Проверка на пустоту
            if (item == null) return;

            // Перебор всех кастом предметов
            foreach (var CustomItem in ObjectsService.CustomItems)
            {
                //Сравнивание текущего предмета с кастомным
                if (item.Serial == CustomItem.Item1 && CustomItem.Item2 > 0)
                {
                    //Нашли додеп
                    player.SendHint($"Тотем = {CustomItem.Item1}, осталось = {CustomItem.Item2}");
                }
            }
        }

        internal static void GiveCustomItem(Player player)
        {
            // Выдаем игроку тотем, и получаем объект предмета
            Item GivenItem = player.AddItem(PluginMain.Configuration.Config.TotemItem);

            // Вставляем Серийник, и Кол-во использований
            ObjectsService.CustomItems.Add((GivenItem.Serial, PluginMain.Configuration.Config.SevesCount));
        }
    }
}
