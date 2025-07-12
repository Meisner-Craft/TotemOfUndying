using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotemOfUndying.Service
{
    internal class ObjectsService
    {
        // Глобальный список всех предметов
        public static List<ushort> AllItems = new List<ushort>();

        // Список кастомных предметов
        public static List<(ushort, int)> CustomItems = new List<(ushort, int)>();

        // Объект для генерации случайных чисел
        public static System.Random Rand = new System.Random();
    }
}
