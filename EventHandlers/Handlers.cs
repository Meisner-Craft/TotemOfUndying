using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.Arguments.ServerEvents;
using LabApi.Events.CustomHandlers;
using TotemOfUndying.Service;

namespace TotemOfUndying
{
    public class Handlers : CustomEventsHandler
    {
        // PLAYER
        public override void OnPlayerChangedItem(PlayerChangedItemEventArgs ev)
        {
            CustomItems.TakeCustomItem(ev.NewItem, ev.Player);
        }

        public override void OnPlayerDying(PlayerDyingEventArgs ev)
        {
            ev.IsAllowed =  RespawnService.PlayerRespawn(ev.Player);
        }


        // SERVERS
        public override void OnServerItemSpawned(ItemSpawnedEventArgs ev)
        {
            base.OnServerItemSpawned(ev);

            CustomItems.SortItemOnSpawn(ev);
        }
        
        public override void OnServerRoundRestarted()
        {
            base.OnServerRoundRestarted();

            CustomItems.AddCustomItem();
        }
        
        public override void OnServerRoundStarted()
        {
            base.OnServerRoundStarted();

            CustomItems.AddCustomItem();
        }

    }
}